namespace Novela.Resources.Models.Book_Models;

public class Book_Appendix
{
    public int append_id { get; set; }
    public int book_id { get; set; }
    public List<Book_AppendixCategory> append_categories { get; set; } = new();
}