using System.ComponentModel;
using Novela.Resources.Enums;
using SQLite;

namespace Novela.Resources.Models.Book_Models;

[Table("Novela_User_Book")]
public class Book : INotifyPropertyChanged
{
    [PrimaryKey, AutoIncrement]
    public int book_id { get; set; }
    public int user_id {get; set;}
    
    [MaxLength(200)]
    public string book_title { get; set; }
    
    [MaxLength(2000)]
    public string? book_description { get; set; }
    
    public Status? book_status { get; set; }
    
    [Ignore]
    public List<Book_Genre> book_genres { get; set; } = new();
    public string book_genres_json { get; set; }
    
    [Ignore]
    public List<string> book_themes { get; set; } = new();
    public string book_themes_json { get; set; }

    [Ignore]
    public ImageSource book_cover 
    {
        get
        {
            if (!string.IsNullOrEmpty(book_cover_path) && File.Exists(book_cover_path)) return ImageSource.FromFile(book_cover_path);
            else return "placeholder_image.png";
        }
    }

    private string _book_cover_path;
    public string book_cover_path
    {
        get => _book_cover_path;
        set
        {
            if(book_cover_path == value) return;
            _book_cover_path = value;

            OnPropertyChanged(nameof(book_cover));
        }
    }
    
    [Ignore]
    public List<Book_Character> book_characters { get; set; } = new();
    [Ignore]
    public List<Book_Section> book_section { get; set; } = new();
        [Ignore]
        public List<Book_Chapter> book_chapters { get; set; } = new();

        [Ignore]
        public List<Book_Era> book_era { get; set; } = new();
    
    // [Ignore]
    // public Book_Appendix book_appendices { get; set; } = new();
    
    #region Helper
        public event PropertyChangedEventHandler? PropertyChanged;
        
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        
    #endregion    
}