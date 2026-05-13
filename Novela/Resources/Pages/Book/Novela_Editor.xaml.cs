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
    public Novela_Editor()
    {
        InitializeComponent();
        
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsVisible = false });
        
        Sidebar.section_changed += on_togglesection;
        
        current_section("overview");
    }
    
    
    #region DashboardLayer#0
        private void to_settings (object sender, EventArgs e) { /* Y */ }
        private void to_about(object sender, EventArgs e) { /* Yes */ }
        private async void to_logout(object sender, EventArgs e) { await Shell.Current.GoToAsync("//auth"); }
    #endregion
    
    #region DashboardLayer#1
        public void on_togglesection(object sender, string section)
        {
            current_section(section);
        }
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
    #endregion
}