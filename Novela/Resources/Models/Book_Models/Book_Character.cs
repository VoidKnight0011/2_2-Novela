using Novela.Resources.Enums;

namespace Novela.Resources.Models.Book_Models;

public class Book_Character
{ 
    public int char_id  { get; set; }
    public int book_id { get; set; }
    public string char_name { get; set; }
    // Char Image
    public Character_Role char_role { get; set; }
    public List<String> char_classification { get; set; }
    public string char_synopsis { get; set; }
    public Status char_status { get; set; }
    public List<Book_CharacterRelationship> char_relationships { get; set; }
}