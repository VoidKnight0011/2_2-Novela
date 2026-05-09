using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Novela.Resources.Services;

namespace Novela.Resources.Pages.Book;

public partial class Novela_Timeline : ContentView
{
    private readonly Service_SidebarState _sidebarState;
    
    public Novela_Timeline()
    {
        InitializeComponent();
        BindingContext = this;
    }
    
    #region Timeline Actions
    private void on_addevent(object sender, EventArgs e)
    {
        // TODO: Show popup to add timeline event
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