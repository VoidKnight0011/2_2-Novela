using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Views;

namespace Novela.Resources.Pages.Extra;

public partial class Extra_EditBook : Popup
{
    public Extra_EditBook()
    {
        InitializeComponent();
    }

    public async void on_editcover(object sender, EventArgs args)
    {
        
    }
    
    public void popup_close(object sender, EventArgs args)
    {
        Close();
    }

    public void popup_save(object sender, EventArgs args)
    {
        
    }
}