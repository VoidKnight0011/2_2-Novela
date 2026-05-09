using System.Collections.ObjectModel;
using Novela.Resources.Services;

namespace Novela.Resources.Pages.Book;

public partial class Novela_Characters : ContentView
{
    

    public Novela_Characters()
    {
        InitializeComponent();
        BindingContext = this;
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