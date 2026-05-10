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
    
    public Novela_Overview(Novela.Resources.Models.Book_Models.Book book)
    {
        InitializeComponent();
        _book_service = Service_Book.Instance;
        _auth_service = Service_Auth.Instance;
        _currentBook = book;
        
        BindingContext = this;
        LoadBook();
    }

    public void LoadBook()
    {
        
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