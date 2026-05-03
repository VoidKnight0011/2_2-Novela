using Novela.Resources.Enums;

namespace Novela.Resources.Models.Book_Models;

public class Book
{
    public int book_id { get; set; }
    public string book_title { get; set; }
    public string? book_description { get; set; }
    public List<Book_Genre> book_genres { get; set; } = new();
    public List<string> book_themes { get; set; } = new();
    public Status Status { get; set; } = Status.Draft;
    
    public List<Book_Character> book_characters { get; set; } = new();
    public List<Book_Section> book_section { get; set; } = new();
    public List<Book_Era> book_era { get; set; } = new();
    public Book_Appendix book_appendices { get; set; } = new();
}