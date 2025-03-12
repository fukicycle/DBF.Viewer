using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using CCG51.DBF.Viewer.Domain.Entities;
using CCG51.DBF.Viewer.Domain.Helpers;
using CCG51.DBF.Viewer.Domain.ValueObjects;
using CCG51.DBF.Viewer.Infrastructure.LocalFiles;
using CCG51.DBF.Viewer.Wpf.ViewModels;
using Microsoft.Win32;

namespace CCG51.DBF.Viewer.Wpf.Commands;

public sealed class BrowseCommand : ICommand
{
    private readonly MainWindowViewModel _viewModel;

    public BrowseCommand(MainWindowViewModel viewModel)
    {
        _viewModel = viewModel;
        _viewModel.PropertyChanged += (s, e) => CanExecuteChanged?.Invoke(this, e);
    }

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public async void Execute(object? parameter)
    {
        var ofd = new OpenFileDialog() { Multiselect = true, Filter = "*.dbf|*.dbf" };
        if (ofd.ShowDialog() == true)
        {
            var reader = new DBFReader();
            foreach (var file in ofd.FileNames)
            {
                var dbfFile = new DBFFilePath(file);
                var result = await reader.ReadAsync(dbfFile);
                bool isLimit = false;
                _viewModel.TabItems = _viewModel.TabItems.Add(
                    new TabItem(
                        dbfFile,
                        GenerateDataTable(result.Headers, result.Values.ToDictionary(result.Headers),ref isLimit, 100),
                        new IsLimit(isLimit)));
            }
        }
    }

    private DataTable GenerateDataTable(string[] headers, IReadOnlyCollection<Dictionary<string, string?>> data, ref bool isLimit, int maxSize = int.MaxValue)
    {
        var table = new DataTable();
        var counter = 1;
        // 動的カラム追加
        foreach (var header in headers)
        {
            table.Columns.Add(header);
        }

        // データを `DataTable` に追加
        foreach (var rowItem in data)
        {
            if (counter > maxSize)
            {
                isLimit = true;
                break;
            }
            var row = table.NewRow();
            foreach (var colItem in rowItem)
            {
                row[colItem.Key] = colItem.Value;
            }
            table.Rows.Add(row);
            counter++;
        }
        return table;
    }
}
