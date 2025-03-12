using System.Windows.Input;
using CCG51.DBF.Viewer.Wpf.ViewModels;

namespace CCG51.DBF.Viewer.Wpf.Commands;

public sealed class ClearCommand : ICommand
{
    private readonly MainWindowViewModel _viewModel;

    public ClearCommand(MainWindowViewModel viewModel)
    {
        _viewModel = viewModel;
        _viewModel.PropertyChanged += (s, e) => CanExecuteChanged?.Invoke(this, e);
    }

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        return _viewModel.TabItems.Any();
    }

    public void Execute(object? parameter)
    {
        _viewModel.TabItems = _viewModel.TabItems.Clear();
    }
}
