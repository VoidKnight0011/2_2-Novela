using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Views;
using Novela.Resources.Pages.Popups;

namespace Novela.Resources.Pages.Popups;

public partial class Extra_AddBook : Popup
{
    public Extra_AddBook()
    {
        InitializeComponent();
    }

    public void popup_close(object sender, EventArgs args)
    {
        Close();
    }

    public void popup_save(object sender, EventArgs args)
    {
        
    }
}