using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novela.Resources.Pages.Extra;

public partial class Book_Sidebar : ContentView
{
    public event EventHandler BackToLibraryClicked;
    public event EventHandler OverviewClicked;
    public event EventHandler CharactersClicked;
    public event EventHandler TimelineClicked;
    public event EventHandler ManuscriptClicked;
    public event EventHandler AppendicesClicked;
    
    public Book_Sidebar()
    {
        InitializeComponent();
    }

    public async void to_dashboard(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//dashboard");
    }
    
    public async void to_overview(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//overview");
    }
    
    public async void to_characters(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//characters");
    }
    
    public async void to_timeline(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//timeline");
    }
    
    public async void to_manuscript(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//manuscript");
    }

    public async void to_appendices(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//appendices");
    }
}