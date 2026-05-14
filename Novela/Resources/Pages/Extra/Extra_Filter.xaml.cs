using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Bluetooth;
using CommunityToolkit.Maui.Views;
using Novela.Resources.Enums;
using Novela.Resources.Services;

namespace Novela.Resources.Pages.Extra;

public partial class Extra_Filter : Popup
{
    private List<RadioButton> status_buttons;
    Service_Auth auth = Service_Auth.Instance;

    public Extra_Filter()
    {
        InitializeComponent();

        auth.CurrentUser.selected_genres ??= new List<Book_Genre>();

        status_buttons = new List<RadioButton>()
        {
            button_all,
            button_draft,
            button_editing,
            button_finished
        };

        BindingContext = this;
        initialize_filter();
    }

    #region Filter

    public Book_Genre[] GenreOptions { get; } = Enum.GetValues<Book_Genre>();

    public void initialize_filter()
    {
        if (auth.CurrentUser.selected_status == null) button_all.IsChecked = true;
         else {
            switch (auth.CurrentUser.selected_status)
            {
                case Status.Draft:
                    button_draft.IsChecked = true;
                    break;
                case Status.Editing:
                    button_editing.IsChecked = true;
                    break;
                case Status.Finished:
                    button_finished.IsChecked = true;
                    break;
            }
        }
    }


public void on_statuschanged(object sender, CheckedChangedEventArgs e)
        {
            if (!e.Value) return;
            var radio = sender as RadioButton;

            if (radio == button_all) Service_Auth.Instance.CurrentUser.selected_status = null;
            else if (radio?.Value is string value) Service_Auth.Instance.CurrentUser.selected_status = Enum.Parse<Status>(value);
        }

        public void on_genretoggle(object sender, CheckedChangedEventArgs e)
        {
            var checkbox = (CheckBox)sender;
            var genre = (Book_Genre)checkbox.BindingContext;
            var genres = Service_Auth.Instance.CurrentUser.selected_genres;

            if (e.Value)
            {
                if(!genres.Contains(genre))genres.Add(genre);
            } else genres.Remove(genre);
        }

        public void on_genreloaded(object sender, EventArgs e)
        {
            var checkbox = (CheckBox)sender;
            var genre = (Book_Genre)checkbox.BindingContext;
            
            checkbox.IsChecked = auth.CurrentUser.selected_genres.Contains(genre) == true;
        }
    #endregion
    
    
    #region Button

    public void popup_save(object sender, EventArgs args)
    {
        Close(true);
    }

    public void filter_clear(object sender, EventArgs args)
    {
        Service_Auth.Instance.CurrentUser.selected_genres?.Clear();
        Service_Auth.Instance.CurrentUser.selected_genres = null;
        foreach (var radio in status_buttons) radio.IsChecked = false;

        button_all.IsChecked = true;
        
        Close(true);
    }
    #endregion
}

public class FilterData
{
    public List<Book_Genre>? book_genre { get; set; }
    public Status? book_status { get; set; }
}