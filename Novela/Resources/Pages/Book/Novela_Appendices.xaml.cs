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
        BindingContext = this;
    }
    
    protected override void OnAppearing()
    {
        base.OnAppearing();
        Sidebar.WidthRequest = _sidebarState.IsSideBarOpen ? 150 : 60;
    }
    
    #region Sidebar
    public async void on_togglesidebar(object sender, bool isopen)
    {
        double sidebarWidth = isopen ? 150 : 60;

        var tcs = new TaskCompletionSource();

        var animation = new Animation(
            v => Sidebar.WidthRequest = v,
            Sidebar.Width,
            sidebarWidth);

        animation.Commit(
            this,
            "SidebarWidth",
            16,
            1000,
            Easing.CubicInOut,
            (v, c) => tcs.SetResult());

        await tcs.Task;
    }
    #endregion
    
    #region Appendix Tabs
    private void on_showcharacters(object sender, EventArgs e)
    {
        // TODO: Show characters list
    }
    
    private void on_showlocations(object sender, EventArgs e)
    {
        // TODO: Show locations list
    }
    
    private void on_showitems(object sender, EventArgs e)
    {
        // TODO: Show items list
    }
    #endregion
    
    #region Toolbar
    private void to_settings(object sender, EventArgs e) { }
    private void to_about(object sender, EventArgs e) { }
    private async void to_logout(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//auth");
    }
    #endregion
}