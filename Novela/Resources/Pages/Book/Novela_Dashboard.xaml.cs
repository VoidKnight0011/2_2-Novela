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
    
    private async void to_editbook(object sender, EventArgs e)
    {
        var gesture = sender as TapGestureRecognizer;
        var border = gesture?.Parent as Border;
        var book = border?.BindingContext as Novela.Resources.Models.Book_Models.Book;

        if (book == null) return;

        _auth_service.CurrentBook = book;
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
            return result;
        }
    }
    #endregion
    
    #region EXTRA
    public static readonly FilterStatus[] StatusOptions = Enum.GetValues<FilterStatus>();
    public FilterStatus DefaultStatus = FilterStatus.All;
    #endregion
}

public enum FilterStatus
{
    All,
    Draft,
    Editing,
    Finished
}