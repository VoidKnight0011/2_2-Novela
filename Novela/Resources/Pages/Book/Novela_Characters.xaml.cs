using System.Collections.ObjectModel;
using Novela.Resources.Services;

namespace Novela.Resources.Pages.Book;

public partial class Novela_Characters : ContentView
{
    private readonly Service_Book _book_service;
    private readonly Service_Auth _auth_service;
    private Novela.Resources.Models.Book_Models.Book _currentBook;
    
    public Novela_Characters()
    {
        InitializeComponent();
        _book_service = Service_Book.Instance;
        _auth_service = Service_Auth.Instance;
        _currentBook = _book_service.CurrentBook;
        
        BindingContext = this;
        // LoadBook();
    }
    
    #region DashboardLayer#0
    private void to_settings(object sender, EventArgs e) { }

    private void to_about(object sender, EventArgs e) { }

    private async void to_logout(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//auth");
    }
    #endregion

    #region CharactersLayer#1
    

    private void on_addcharacter(object sender, EventArgs e)
    {

    }

    private void on_deletecharacter(object sender, EventArgs e)
    {

    }

    #endregion
}