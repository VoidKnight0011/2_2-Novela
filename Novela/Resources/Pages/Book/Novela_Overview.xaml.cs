using Novela.Resources.Enums;
using SQLite;
using Novela.Resources.Services;

namespace Novela.Resources.Pages.Book;

public partial class Novela_Overview : ContentView
{
    private readonly Service_Book _book_service;
    private readonly Service_Auth _auth_service;
    private Novela.Resources.Models.Book_Models.Book _currentBook;
    private byte[]? _selectedCoverData;
    
    public Novela_Overview()
    {
        InitializeComponent();
        _book_service = Service_Book.Instance;
        _auth_service = Service_Auth.Instance;
        _currentBook = _book_service.CurrentBook;
        
        BindingContext = this;
        Loaded += OnLoaded;
    }

    public void OnLoaded(object sender, EventArgs eventArgs)
    {
        book_title.Text = _currentBook.book_title;
        book_description.Text = _currentBook.book_description;
    }

    public Book_Genre[] GenreOptions { get; } = Enum.GetValues<Book_Genre>();

    private void on_cancel(object sender, EventArgs e) { }
    private void on_save(object sender, EventArgs e) { }
    private void on_addtheme(object sender, EventArgs e) { }

    private async void on_editcover(object sender, EventArgs e)
    {
        book_title.Text = "Works";
    }
}