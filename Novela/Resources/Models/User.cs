using Novela.Resources.Enums;
using Novela.Resources.Models.Book_Models;
using SQLite;

namespace Novela.Resources.Models;

[Table("Novela_Users")]
public class User
{ 
    [PrimaryKey, AutoIncrement]
    public int user_id { get; set; }
    
    [MaxLength(50), Unique]
    public string user_name { get; set; }
    
    [MaxLength(100)]
    public string user_pass { get; set; }
    
    [Ignore]
    public List<Book> user_books { get; set; } = new();
    
    public User_Theme user_theme { get; set; } = User_Theme.Dark;
    
    #region Extra
        [Ignore]
        public Status? selected_status { get; set; }
        [Ignore]
        public List<Book_Genre>? selected_genres { get; set; }

        public bool user_dashboard_orientation { get; set; } = true;

        #endregion
}