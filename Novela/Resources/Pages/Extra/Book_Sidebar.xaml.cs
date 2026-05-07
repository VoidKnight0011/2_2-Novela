using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Views;
using Novela.Resources.Services;

namespace Novela.Resources.Pages.Extra;

public partial class Book_Sidebar : ContentView
{
    
    public Book_Sidebar()
    {
        InitializeComponent();
        _sidebarstate = Service_SidebarState.Instance;
        _sidebarstate.SidebarState = global_sidebarstate;
        toggle_sidebar.Rotation = _sidebarstate.rotation;
    }

    
    #region sidebar
    private readonly Service_SidebarState _sidebarstate;
    public event EventHandler<bool> sidebar_toggled;

    private void global_sidebarstate(object? sender, EventArgs e)
    {
        sidebar_toggled?.Invoke(sender, _sidebarstate.IsSideBarOpen);
    }

    public void on_togglesidebar(object sender, EventArgs e)
    {
        var state = Service_SidebarState.Instance;

        state.sidebar_state(!state.IsSideBarOpen);

        state.rotation = (state.rotation + 180) % 360;

        toggle_sidebar.Rotation = state.rotation;
    }

    public void set_activeitem(string itemName)
    {
        // Reset all
        button_overview.BackgroundColor = Colors.Transparent;
        button_characters.BackgroundColor = Colors.Transparent;
        button_timeline.BackgroundColor = Colors.Transparent;
        button_manuscript.BackgroundColor = Colors.Transparent;
        button_appendices.BackgroundColor = Colors.Transparent;

        // Highlight active
        var activeColor = Application.Current.RequestedTheme == AppTheme.Dark
            ? Color.FromArgb("#2C2C2C")
            : Color.FromArgb("#F0F0F0");

        switch (itemName.ToLower())
        {
            case "overview":
                button_overview.BackgroundColor = activeColor;
                break;
            case "characters":
                button_characters.BackgroundColor = activeColor;
                break;
            case "timeline":
                button_timeline.BackgroundColor = activeColor;
                break;
            case "manuscript":
                button_manuscript.BackgroundColor = activeColor;
                break;
            case "appendices":
                button_appendices.BackgroundColor = activeColor;
                break;
        }
    }
    #endregion

    #region SideBar_Items
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
    #endregion
}