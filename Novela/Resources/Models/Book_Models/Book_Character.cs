using Novela.Resources.Enums;
using SQLite;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace Novela.Resources.Models.Book_Models;

[Table("Novela_User_Book_Character")]
public class Book_Character
{ 
    [PrimaryKey, AutoIncrement]
    public int char_id  { get; set; }
    public int book_id { get; set; }
    
    [MaxLength(100)]
    public string char_name { get; set; }
    
    public Character_Role char_role { get; set; }
    
    [MaxLength(2000)]
    public string char_description { get; set; }
    
    public Status char_status { get; set; }
    
    [Ignore]
    public ImageSource character_design
    {
        get
        {
            if (!string.IsNullOrEmpty(character_cover_path) && File.Exists(character_cover_path)) return ImageSource.FromFile(character_cover_path);
            else return "placeholder_image.png";
        }
    }

    private string _character_cover_path;
    public string character_cover_path
    {
        get => _character_cover_path;
        set
        {
            if(_character_cover_path == value) return;
            _character_cover_path = value;

            OnPropertyChanged(nameof(character_cover_path));
        }
    }
    
    #region Helper
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    #endregion 
}