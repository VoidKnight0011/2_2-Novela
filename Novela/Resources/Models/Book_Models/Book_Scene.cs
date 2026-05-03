using Novela.Resources.Enums;

namespace Novela.Resources.Models.Book_Models;

public class Book_Scene
{ 
    public int scene_id { get; set; }
    public string scene_title { get; set; }
    public string? scene_content { get; set; }
    public Book_Era? scene_category { get; set; }
    public Status scene_status { get; set; }
}