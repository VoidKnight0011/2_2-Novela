using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novela.Resources.Pages.Book;

public partial class Novela_Characters : ContentPage
{
    public Novela_Characters()
    {
        InitializeComponent();
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