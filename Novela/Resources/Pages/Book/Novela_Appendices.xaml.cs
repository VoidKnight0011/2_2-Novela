using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Novela.Resources.Services;

namespace Novela.Resources.Pages.Book;

public partial class Novela_Appendices : ContentView
{
    private readonly Service_SidebarState _sidebarState;
    
    public Novela_Appendices()
    {
        InitializeComponent();
        BindingContext = this;
    }
    
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