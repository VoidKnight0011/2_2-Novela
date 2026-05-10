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
    private readonly Service_Book _book_service;
    private readonly Service_Auth _auth_service;
    private Novela.Resources.Models.Book_Models.Book _currentBook;
    
    public Novela_Timeline()
    {
        InitializeComponent();
        _book_service = Service_Book.Instance;
        _auth_service = Service_Auth.Instance;
        _currentBook = _book_service.CurrentBook;
        
        BindingContext = this;
        // LoadBook();
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