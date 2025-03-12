using System.Collections.Immutable;
using System.Windows.Input;
using CCG51.DBF.Viewer.Domain.Entities;
using CCG51.DBF.Viewer.Wpf.Commands;

namespace CCG51.DBF.Viewer.Wpf.ViewModels;

public sealed class MainWindowViewModel : ViewModel
{
    private ImmutableList<TabItem> _tabItems = ImmutableList.Create<TabItem>();

    public MainWindowViewModel()
    {
        BrowseCommand = new BrowseCommand(this);
        ClearCommand = new ClearCommand(this);
    }

    public ImmutableList<TabItem> TabItems
    {
        get => _tabItems;
        set
        {
            SetProperty(ref _tabItems, value);
        }
    }

    public ICommand BrowseCommand { get; }
    public ICommand ClearCommand { get; }
}
