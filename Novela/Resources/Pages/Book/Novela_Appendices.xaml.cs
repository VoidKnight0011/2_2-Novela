using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Novela.Resources.Services;

namespace Novela.Resources.Pages.Book;

public partial class Novela_Appendices : ContentPage
{
    private readonly Service_SidebarState _sidebarState;
    public Novela_Appendices()
    {
        InitializeComponent();
        _sidebarState = Service_SidebarState.Instance;
        
        Sidebar.set_activeitem("appendices");
        Sidebar.sidebar_toggled += on_togglesidebar;
        WidthRequest = _sidebarState.IsSideBarOpen ? 150 : 60;
    }
    private async void on_togglesidebar(object sender, bool isopen)
    {
        Sidebar.WidthRequest = isopen ? 150 : 60;
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
}