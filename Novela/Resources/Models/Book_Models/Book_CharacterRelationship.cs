using Novela.Resources.Enums;

namespace Novela.Resources.Models.Book_Models;

public class Book_CharacterRelationship
{
    public int relation_id { get; set; }
    public int char_id { get; set; }
    public List<Character_Relation> relation_ship { get; set; }
    public bool relation_ismutual { get; set; }
    public string relation_desc { get; set; }
}