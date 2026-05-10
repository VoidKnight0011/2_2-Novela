using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Novela.Resources.Services;
using Novela.Resources.Models.Book_Models;

namespace Novela.Resources.Pages.Book;

public partial class Novela_Editor : ContentPage
{
    private readonly Service_Auth _auth_service;
    private readonly Service_Book _book_service;
    private Novela.Resources.Models.Book_Models.Book _currentBook;
    
    public Novela_Editor()
    {
        InitializeComponent();
        _book_service = Service_Book.Instance;
        _auth_service = Service_Auth.Instance;
        _currentBook = _auth_service.CurrentBook;
        
        Sidebar.section_toggle += on_togglesection;
        
        current_section("overview");
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        Sidebar.WidthRequest = Service_SidebarState.Instance.IsSideBarOpen ? 150 : 60;
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
    
    #region DashboardLayer#1
    private void current_section (string section)
    {
        Editor_ContentArea.Content = section switch
        {
            "overview"   => new Novela_Overview(_currentBook),
            "characters" => new Novela_Characters(_currentBook),
            "timeline"   => new Novela_Timeline(_currentBook),
            "manuscript" => new Novela_Manuscript(_currentBook),
            "appendices" => new Novela_Appendices(_currentBook),
            _            => new Novela_Overview(_currentBook)
        };
        
        Sidebar.set_activeitem(section);
    }

    public void on_togglesection(object sender, string section)
    {
        current_section(section);
    }
    #endregion
}