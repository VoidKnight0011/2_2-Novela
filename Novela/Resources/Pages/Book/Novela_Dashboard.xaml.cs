using Novela.Resources.Enums;
using Novela.Resources.Models.Book_Models;
using System.Collections.ObjectModel;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls.Shapes;
using Novela.Resources.Pages.Extra;
using Novela.Resources.Services;

namespace Novela.Resources.Pages.Book;

public partial class Novela_Dashboard : ContentPage
{
    #region Dashboard
        private readonly Service_Auth _auth_service;
        private readonly Service_Book _book_service;
        public ObservableCollection<Models.Book_Models.Book> user_books { get; set; } = new();

        public Novela_Dashboard()
        {
            InitializeComponent();
            Shell.SetNavBarIsVisible(this, true);
            _auth_service = Service_Auth.Instance;
            _book_service = Service_Book.Instance;
            
            BindingContext = this;
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadBooks();
        }
    #endregion
    
    #region DashboardLayer#0
        private async void to_settings (object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//settings");
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
        public static readonly Status[] StatusOptions = Enum.GetValues<Status>();
        public const Status DefaultStatus = Status.Draft;
    #endregion

    #region DashboardLayer#3
        private async void book_options(object sender, EventArgs e)
        {
            var popup = new Extra_EditBook();
            
            var result = await this.ShowPopupAsync(popup);
        }
        
        private async void to_editbook(object sender, EventArgs e)
        { 
            await Shell.Current.GoToAsync("editor");
        }
    #endregion
    
    #region Dashboard#4

    private void LoadBooks()
    {
        if (_auth_service.CurrentUser == null) return;
        
        var books = _book_service.get_userbooks(_auth_service.CurrentUser.user_id);
        user_books.Clear();
        foreach (var b in books)
        {
            user_books.Add(b);
        }
    }
    
        private async void to_addbook(object sender, EventArgs e)
        {
            var popup = new Extra_AddBook();
            
            var result = await this.ShowPopupAsync(popup);
            LoadBooks();    
        }
    #endregion
}