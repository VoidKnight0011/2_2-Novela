using Novela.Resources.Enums;
using Novela.Resources.Models.Book_Models;
using System.Collections.ObjectModel;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls.Shapes;
using Novela.Resources.Pages.Extra;

namespace Novela.Resources.Pages.Book;

public partial class Novela_Dashboard : ContentPage
{
    #region Dashboard
        public Novela_Dashboard()
        {
            InitializeComponent();
            Shell.SetNavBarIsVisible(this, true);
            InitializeTestBooks();
            BindingContext = this;
        }

        public ObservableCollection<Models.Book_Models.Book> testbooks { get; set; }

        private void InitializeTestBooks() {
        testbooks = new ObservableCollection<Models.Book_Models.Book>
        {
            new Models.Book_Models.Book
            {
                book_id = 1,
                book_title = "The Shadow Chronicles",
                book_description = "A dark fantasy adventure",
                Status = Status.Draft,
                book_genres = new List<Book_Genre> { Book_Genre.Fantasy, Book_Genre.Adventure }
            },
            new Models.Book_Models.Book
            {
                book_id = 2,
                book_title = "Echoes of Tomorrow",
                book_description = "A science fiction thriller",
                Status = Status.Editing,
                book_genres = new List<Book_Genre> { Book_Genre.SciFi }
            },
            new Models.Book_Models.Book
            {
                book_id = 3,
                book_title = "Whispers in the Dark",
                book_description = "A mystery novel",
                Status = Status.Draft,
                book_genres = new List<Book_Genre> { Book_Genre.Mystery }
            },
            new Models.Book_Models.Book
            {
                book_id = 4,
                book_title = "The Last Kingdom",
                book_description = "An epic historical tale",
                Status = Status.Finished,
                book_genres = new List<Book_Genre> { Book_Genre.Historical }
            },
            new Models.Book_Models.Book
            {
                book_id = 5,
                book_title = "Digital Dreams",
                book_description = "A cyberpunk adventure",
                Status = Status.Draft,
                book_genres = new List<Book_Genre> { Book_Genre.SciFi }
            },
            new Models.Book_Models.Book
            {
                book_id = 6,
                book_title = "Hearts Entwined",
                book_description = "A contemporary romance",
                Status = Status.Draft,
                book_genres = new List<Book_Genre> { Book_Genre.Romance }
            }
        };
    }
    #endregion
    
    #region DashboardLayer#0
        private void to_settings (object sender, EventArgs e)
        {

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
            await Shell.Current.GoToAsync("//overview");
        }
    #endregion
    
    #region Dashboard#4
        private async void to_addbook(object sender, EventArgs e)
        {
            var popup = new Extra_AddBook();
            
            var result = await this.ShowPopupAsync(popup);
        }
    #endregion
}