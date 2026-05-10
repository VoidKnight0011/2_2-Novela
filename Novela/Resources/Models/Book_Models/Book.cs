using Novela.Resources.Enums;
using SQLite;

namespace Novela.Resources.Models.Book_Models;

[Table("Novela_User_Books")]
public class Book
{
    [PrimaryKey, AutoIncrement]
    public int book_id { get; set; }
    
    public int user_id {get; set;}
    
    [MaxLength(200)]
    public string book_title { get; set; }
    
    [MaxLength(2000)]
    public string? book_description { get; set; }
    
    public Status book_status { get; set; } = Status.Draft;
    
    [Ignore]
    public List<Book_Genre> book_genres { get; set; } = new();
    public string book_genres_json { get; set; }
    
    [Ignore]
    public List<string> book_themes { get; set; } = new();
    public string book_themes_json { get; set; }

    [Ignore]
    public ImageSource book_cover => book_cover_data != null ? ImageSource.FromStream(() => new MemoryStream(book_cover_data)) : "placeholder_image.png";
    public byte[]? book_cover_data { get; set; }
    
    [Ignore]
    public List<Book_Character> book_characters { get; set; } = new();
    
    [Ignore]
    public List<Book_Section> book_section { get; set; } = new();
    
        [Ignore]
        public List<Book_Era> book_era { get; set; } = new();
    
    // [Ignore]
    // public Book_Appendix book_appendices { get; set; } = new();
}