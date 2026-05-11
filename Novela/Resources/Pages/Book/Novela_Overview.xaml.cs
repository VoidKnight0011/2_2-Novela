using Novela.Resources.Enums;
using SQLite;
using Novela.Resources.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Novela.Resources.Pages.Book;

public partial class Novela_Overview : ContentView, INotifyPropertyChanged
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

        if (_currentBook.book_cover != null)
        {
            _selectedCoverData = _currentBook.book_cover_data;
            book_cover.Source = ImageSource.FromStream(() => new MemoryStream(_currentBook.book_cover_data));
        }
    }

    public Book_Genre[] GenreOptions { get; } = Enum.GetValues<Book_Genre>();

    private async void on_delete(object sender, EventArgs e)
    {
        // await DisplayAlert("")
    }

    private async void on_save(object sender, EventArgs e)
    {
        _currentBook.book_title = book_title.Text;
        _currentBook.book_description = book_description.Text;
        _currentBook.book_cover_data = _selectedCoverData;
        
        _book_service.update_book(_currentBook);
        await Shell.Current.GoToAsync("..");
    }

    private async void on_editcover(object sender, EventArgs e)
    {
        var result = await FilePicker.Default.PickAsync(new PickOptions
        {
            PickerTitle = "Select Cover Image",
            FileTypes = FilePickerFileType.Images
        });

        if (result == null) return;

        using var stream = await result.OpenReadAsync();
        using var ms = new MemoryStream();

        await stream.CopyToAsync(ms);

        _selectedCoverData = ms.ToArray();
        
        book_cover.Source = ImageSource.FromStream(() => 
            new MemoryStream(_selectedCoverData));
    }
    
    public event PropertyChangedEventHandler PropertyChanged;
    
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}