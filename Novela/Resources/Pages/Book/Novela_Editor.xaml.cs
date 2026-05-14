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
        Novela_Header.section_changed += on_togglesection;
        
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
        private void current_section(string section)
        {
            Novela_Header.IsVisible = true;
            
            switch (section)
            {
                case "overview":
                    Novela_Editor_ContentArea.Content = new Novela_Overview();
                    break;
                case "characters":
                    var character_page = new Novela_Characters();
                    character_page.section_changed += on_togglesection;
                    Novela_Editor_ContentArea.Content = character_page;
                    break;
                case "timeline":
                    Novela_Editor_ContentArea.Content = new Novela_Timeline();
                    break;
                case "manuscript":
                    Novela_Editor_ContentArea.Content = new Novela_Manuscript();
                    break;
                case "appendices":
                    Novela_Editor_ContentArea.Content = new Novela_Appendices();
                    break;
                case "preview":
                    Novela_Header.IsVisible = false;
                    Novela_Editor_ContentArea.Content = new Novela_Preview();;
                    break;
                case "charprofile":
                    Novela_Editor_ContentArea.Content = new Novela_CharacterProfile();
                    section = "characters";
                    break;
                default:
                    Novela_Editor_ContentArea.Content = new Novela_Overview();
                    break;
            }

            Sidebar.set_activeitem(section);
        }
    #endregion
    
    
}