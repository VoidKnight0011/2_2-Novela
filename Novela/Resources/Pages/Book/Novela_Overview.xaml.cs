using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Novela.Resources.Services;

namespace Novela.Resources.Pages.Book;

public partial class Novela_Overview : ContentPage
{
    private readonly Service_SidebarState _sidebarState;
    
    public Novela_Overview()
    {
        InitializeComponent();
        _sidebarState = Service_SidebarState.Instance;
        Sidebar.set_activeitem("overview");
        Sidebar.sidebar_toggled += on_togglesidebar;
        WidthRequest = _sidebarState.IsSideBarOpen ? 150 : 60;
    }
    
    #region DashboardLayer#0
    private void to_settings (object sender, EventArgs e)
    {

    }

    private void to_about(object sender, EventArgs e)
    {

    }

    private async void to_logout(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//auth");
    }
    #endregion
    
    #region OverviewLayer#1

    private async void on_togglesidebar(object sender, bool isopen)
    {
        Sidebar.WidthRequest = isopen ? 150 : 60;
    }
        
    // Cover image
    private void on_changecover(object sender, EventArgs e) { }

    // Save / Cancel
    private void on_cancel(object sender, EventArgs e) { }

    private void on_save(object sender, EventArgs e) { }

    // Themes
    private void on_addtheme(object sender, EventArgs e) { }

    private void on_removetheme(object sender, EventArgs e) { }
    #endregion
}