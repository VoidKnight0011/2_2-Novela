namespace Novela.Resources.Models.Book_Models;

public class Book_Era
{ 
    public int era_id { get; set; }
    public string era_name { get; set; }
    public string era_synopsis { get; set; }
    public List<Book_Event> Events { get; set; }
}