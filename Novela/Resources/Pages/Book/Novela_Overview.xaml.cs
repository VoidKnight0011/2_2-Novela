using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Novela.Resources.Services;
using Novela.Resources.Enums;

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
        BindingContext = this;
    }
    
    protected override void OnAppearing()
    {
        base.OnAppearing();
        Sidebar.WidthRequest = _sidebarState.IsSideBarOpen ? 150 : 60;
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
        
    // Cover image
    private void on_changecover(object sender, EventArgs e) { }

    // Save / Cancel
    private void on_cancel(object sender, EventArgs e) { }

    private void on_save(object sender, EventArgs e) { }

    // Themes
    private void on_addtheme(object sender, EventArgs e) { }

    private void on_removetheme(object sender, EventArgs e) { }
    #endregion
    
    #region DashboardLayer#1
        public Book_Genre[] GenreOptions { get; } = Enum.GetValues<Book_Genre>();
    #endregion
}