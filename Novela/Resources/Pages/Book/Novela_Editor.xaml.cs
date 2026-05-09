using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Novela.Resources.Services;

namespace Novela.Resources.Pages.Book;

public partial class Novela_Editor : ContentPage
{
    public Novela_Editor()
    {
        InitializeComponent();
        
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
            "overview"   => new Novela_Overview(),
            "characters" => new Novela_Characters(),
            "timeline"   => new Novela_Timeline(),
            "manuscript" => new Novela_Manuscript(),
            "appendices" => new Novela_Appendices(),
            _            => new Novela_Overview()
        };

        Sidebar.set_activeitem(section);
    }

    public void on_togglesection(object sender, string section)
    {
        current_section(section);
    }
    #endregion
}