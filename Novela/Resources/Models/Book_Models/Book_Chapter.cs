using Novela.Resources.Enums;
using SQLite;

namespace Novela.Resources.Models.Book_Models;

[Table("Novela_User_Book_Chapter")]
public class Book_Chapter
{ 
    [PrimaryKey, AutoIncrement]
    public int chap_id { get; set; }
    public int section_id { get; set; }
    
    public int chap_order { get; set; }
    
    [MaxLength(100)]
    public string chap_title { get; set; }
    
    public string chap_content { get; set; }
    
    public Status chap_status { get; set; }
}