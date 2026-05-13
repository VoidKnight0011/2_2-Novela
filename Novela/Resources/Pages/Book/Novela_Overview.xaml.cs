using Novela.Resources.Enums;
using SQLite;
using Novela.Resources.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using Novela.Resources.Helpers;

namespace Novela.Resources.Pages.Book;

public partial class Novela_Overview : ContentView, INotifyPropertyChanged
{
    #region Initialization
        private readonly Service_Book _book_service;
        private readonly Service_Auth _auth_service;
        public Novela.Resources.Models.Book_Models.Book CurrentBook { get; set; }
        private string _pathCover;
    
        
        public Novela_Overview()
        {
            InitializeComponent();
            _book_service = Service_Book.Instance;
            _auth_service = Service_Auth.Instance;
            CurrentBook = _book_service.CurrentBook;
            
            BindingContext = this;
            Loaded += OnLoaded;
        }

        public void OnLoaded(object sender, EventArgs eventArgs)
        {

            if (!string.IsNullOrEmpty(CurrentBook.book_cover_path))
            {
                _pathCover = CurrentBook.book_cover_path;
            }
            
            if(!string.IsNullOrEmpty(CurrentBook.book_genres_json)) CurrentBook.book_genres = JsonSerializer.Deserialize<List<Book_Genre>>(CurrentBook.book_genres_json) ?? new();
            
            OnPropertyChanged(nameof(GenreOptions));
        }
    #endregion

    #region Layer1:BookInfo
        private async void on_delete(object sender, EventArgs e)
        {
            bool result = await Application.Current.MainPage.DisplayAlert("Delete_Book", $"Are You Sure You Want to Delete {CurrentBook.book_title}?", "Delete", "Cancel");
            
            if (!result) return;
            
            _book_service.delete_book(CurrentBook.book_id);
            await Shell.Current.GoToAsync("..");
        }

        private async void on_save(object sender, EventArgs e)
        {
            CurrentBook.book_cover_path = _pathCover;
            CurrentBook.book_genres_json = JsonSerializer.Serialize(CurrentBook.book_genres);
            
            _book_service.update_book(CurrentBook);
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
            
            _pathCover = await Helper_Image.image_coversave(result, CurrentBook.book_id, _pathCover);
            
            CurrentBook.book_cover_path = _pathCover;
        }
    #endregion
    
    #region Layer2:BookStatus
        public List<Status> status_options { get; set; } = Enum.GetValues<Status>().ToList();

        public Status picked_status
        {
            get
            {
                return CurrentBook.book_status ?? Status.Draft;
            }
        }

    #endregion
    
    #region Layer3:Genre
        public Book_Genre[] GenreOptions { get; } = Enum.GetValues<Book_Genre>();
        
        public void on_genretoggle (object sender, CheckedChangedEventArgs e)
        {
            var genre = (Book_Genre)((CheckBox)sender).BindingContext;

            if (e.Value)
            {
                if(!CurrentBook.book_genres.Contains(genre)) CurrentBook.book_genres.Add(genre);
            } else  CurrentBook.book_genres.Remove(genre);
        }
        
        private void on_genreloaded(object sender, EventArgs e)
        {
            var checkbox = (CheckBox)sender;
            var genre = (Book_Genre)checkbox.BindingContext;
            checkbox.IsChecked = CurrentBook.book_genres.Contains(genre);
        }
    #endregion
    
    #region EXTRA
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    #endregion
}