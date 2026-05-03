using Novela.Resources.Enums;
using Novela.Resources.Models.Book_Models;

namespace Novela.Resources.Models;

public class User
{ 
    public int user_id { get; set; }
    public string user_name { get; set; }
    public string user_pass { get; set; }
    public List<Book> user_books { get; set; } = new();
    public User_Theme user_theme { get; set; } = User_Theme.Dark;
}