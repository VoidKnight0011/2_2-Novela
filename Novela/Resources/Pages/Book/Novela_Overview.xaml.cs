using Novela.Resources.Enums;
using SQLite;
using Novela.Resources.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using SkiaSharp;

namespace Novela.Resources.Pages.Book;

public partial class Novela_Overview : ContentView, INotifyPropertyChanged
{
    #region Initialization
        private readonly Service_Book _book_service;
        private readonly Service_Auth _auth_service;
        private Novela.Resources.Models.Book_Models.Book _currentBook;
        private string _pathCover;
    
        
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

            if (!string.IsNullOrEmpty(_currentBook.book_cover_path))
            {
                _pathCover = _currentBook.book_cover_path;
                book_cover.Source = ImageSource.FromFile(_currentBook.book_cover_path);
            }
            
            if(!string.IsNullOrEmpty(_currentBook.book_genres_json)) _currentBook.book_genres = JsonSerializer.Deserialize<List<Book_Genre>>(_currentBook.book_genres_json) ?? new();
            
            OnPropertyChanged(nameof(GenreOptions));
        }
    #endregion

    #region Layer1:BookInfo
        private async void on_delete(object sender, EventArgs e)
        {
            await Application.Current.MainPage.DisplayAlert(
                "Notice",
                "This came from a ContentView",
                "OK");
        }

        private async void on_save(object sender, EventArgs e)
        {
            _currentBook.book_title = book_title.Text;
            _currentBook.book_description = book_description.Text;
            _currentBook.book_cover_path = _pathCover;
            _currentBook.book_genres_json = JsonSerializer.Serialize(_currentBook.book_genres);
            
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
            
            var coversDir = Path.Combine(FileSystem.AppDataDirectory, "covers");
            Directory.CreateDirectory(coversDir);
            
            var fileName = $"cover_{_currentBook.book_id}_{Guid.NewGuid()}.jpg";
            var destPath = Path.Combine(coversDir, fileName);
            
            using var stream = await result.OpenReadAsync();
            var compressedData = await CompressImage(stream);
            await File.WriteAllBytesAsync(destPath, compressedData);
            
            if (!string.IsNullOrEmpty(_pathCover) && File.Exists(_pathCover))
                File.Delete(_pathCover);

            _pathCover = destPath;
            book_cover.Source = ImageSource.FromFile(destPath);
        }
    #endregion
    
    #region Layer2:Genre
        public Book_Genre[] GenreOptions { get; } = Enum.GetValues<Book_Genre>();
        
        public void on_genretoggle (object sender, CheckedChangedEventArgs e)
        {
            var genre = (Book_Genre)((CheckBox)sender).BindingContext;

            if (e.Value)
            {
                if(!_currentBook.book_genres.Contains(genre)) _currentBook.book_genres.Add(genre);
            } else  _currentBook.book_genres.Remove(genre);
        }
        
        private void on_genreloaded(object sender, EventArgs e)
        {
            var checkbox = (CheckBox)sender;
            var genre = (Book_Genre)checkbox.BindingContext;
            checkbox.IsChecked = _currentBook.book_genres.Contains(genre);
        }
    #endregion
    
    #region EXTRA
    public event PropertyChangedEventHandler PropertyChanged;
    
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    // ADD THIS METHOD:
    private async Task<byte[]> CompressImage(Stream stream)
    {
        using var memoryStream = new MemoryStream();
        await stream.CopyToAsync(memoryStream);

        memoryStream.Position = 0;

        using var originalBitmap = SKBitmap.Decode(memoryStream);

        if (originalBitmap == null)
            throw new Exception("Failed to decode image.");

        const int maxSize = 1024;

        int originalWidth = originalBitmap.Width;
        int originalHeight = originalBitmap.Height;

        float ratio = Math.Min( (float)maxSize / originalWidth, (float)maxSize / originalHeight);

        ratio = Math.Min(ratio, 1f);

        int newWidth = (int)(originalWidth * ratio);
        int newHeight = (int)(originalHeight * ratio);

        using var resizedBitmap = originalBitmap.Resize( new SKImageInfo(newWidth, newHeight), SKFilterQuality.Medium );

        using var image = SKImage.FromBitmap(resizedBitmap);
        using var data = image.Encode(SKEncodedImageFormat.Jpeg, 75);

        return data.ToArray();
    }
    #endregion
}