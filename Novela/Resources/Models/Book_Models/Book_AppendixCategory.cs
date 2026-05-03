namespace Novela.Resources.Models.Book_Models;

public class Book_AppendixCategory
{
    public int ac_id { get; set; }
    public int append_id { get; set; }
    public string ac_title { get; set; }
    public int ac_order { get; set; }
    public List<Book_AppendixItem> ac_items { get; set; }
}