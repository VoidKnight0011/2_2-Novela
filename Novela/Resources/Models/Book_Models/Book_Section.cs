using SQLite;

namespace Novela.Resources.Models.Book_Models;

[Table("Novela_User_Book_Section")]
public class Book_Section
{
    [PrimaryKey, AutoIncrement]
    public int section_id { get; set; }
    public int book_id { get; set; }
    
    [MaxLength(100)]
    public string section_title  { get; set; }
    
    [Ignore]
    public List<Book_Chapter> section_chapters { get; set; }
}