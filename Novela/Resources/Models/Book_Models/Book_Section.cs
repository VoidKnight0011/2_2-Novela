namespace Novela.Resources.Models.Book_Models;

public class Book_Section
{
    public int section_id { get; set; }
    public string section_title  { get; set; }
    public List<Book_Chapter> section_chapters { get; set; }
}