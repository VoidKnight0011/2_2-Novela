using Novela.Resources.Enums;

namespace Novela.Resources.Models.Book_Models;

public class Book_Chapter
{ 
    public int chap_id { get; set; }
    public int section_id { get; set; }
    public string chap_title { get; set; }
    public string chap_synopsis { get; set; }
    public Status chap_status { get; set; }
    public int chap_order { get; set; }
    public string chap_ontent { get; set; }
    // public List<Book_Event> chap_events  { get; set; }
}