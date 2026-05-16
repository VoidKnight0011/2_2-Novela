using Novela.Resources.Enums;
using Novela.Resources.Models.Book_Models;
using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Views;
using Novela.Resources.Pages.Extra;
using Novela.Resources.Services;

namespace Novela.Resources.Pages.Book;

public partial class Novela_Dashboard : ContentPage
{
    private readonly Service_Auth _auth_service;
    private readonly Service_Book _book_service;
    
    private byte[]? _selectedCoverData;
    private ObservableCollection<Novela.Resources.Models.Book_Models.Book> _user_books { get; set; } = new();

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

    #region Header_Options
        private async void to_settings(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//settings");
        }

        private void to_about(object sender, EventArgs e) { }

        private async void to_logout(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//auth");
        }
        #endregion

    #region  Filter

    public void toggle_grid(object sender, EventArgs e)
    {
        _auth_service.CurrentUser.user_dashboard_orientation = !_auth_service.CurrentUser.user_dashboard_orientation;

        if(_auth_service.CurrentUser.user_dashboard_orientation)
        {
            books_collection_list.IsVisible = false;
            books_collection_grid.IsVisible = true;
        }
        else
        {
            books_collection_grid.IsVisible = false;
            books_collection_list.IsVisible = true;
        }
        
        grid_toggle.Source = _auth_service.CurrentUser.user_dashboard_orientation ? "icon_grid.png" : "icon_list.png";
    }

    #endregion

    #region Book_Card
        private async void book_options(object sender, EventArgs e)
        {
            var button = sender as ImageButton;
            var book = button?.CommandParameter as Novela.Resources.Models.Book_Models.Book;

            if (book == null) return;
            
            var popup = new Extra_EditBook(book);
            await this.ShowPopupAsync(popup);
            LoadBooks();
        }
        
        private async void to_filter(object sender, EventArgs e)
        {
            var popup = new Extra_Filter();
            var result = await this.ShowPopupAsync(popup);

            if (result != null) OnPropertyChanged(nameof(the_displayedbooks));
        }
        
        
        private async void to_editbook(object sender, TappedEventArgs e)
        {
            var book = (sender as BindableObject)?.BindingContext
             as Novela.Resources.Models.Book_Models.Book;

            if (book == null)
            {
                await DisplayAlert("Error", "Book is null", "OK");
                return;
            }

            _book_service.CurrentBook = book;
            await Shell.Current.GoToAsync("editor");
        }
        #endregion
    
    #region Book_Library
    private void LoadBooks()
    {
        if (_auth_service.CurrentUser == null) return;
        
        var books = _book_service.get_userbooks(_auth_service.CurrentUser.user_id);
        _user_books.Clear();
        foreach (var b in books)
        {
            if (!string.IsNullOrEmpty(b.book_genres_json)) b.book_genres = System.Text.Json.JsonSerializer.Deserialize<List<Book_Genre>>(b.book_genres_json);
            _user_books.Add(b);
        }
    }
    
    private async void to_addbook(object sender, EventArgs e)
    {
        var popup = new Extra_AddBook();
        var result = await this.ShowPopupAsync(popup);
        LoadBooks();    
    }

    public IEnumerable<Novela.Resources.Models.Book_Models.Book> the_displayedbooks
    {
        get
        {
            IEnumerable<Novela.Resources.Models.Book_Models.Book> result = _user_books;
            
            if(_auth_service.CurrentUser.selected_status != null) result = result.Where(b => b.book_status == _auth_service.CurrentUser.selected_status);
            
            if (_auth_service.CurrentUser.selected_genres?.Any() == true)
            {
                var selected = _auth_service.CurrentUser.selected_genres;
                result = result.Where(b => selected.All(g => b.book_genres.Contains(g)));
            }
            
            return result;
        }
    }
    #endregion
}