using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Views;
using Novela.Resources.Enums;
using Novela.Resources.Services;

namespace Novela.Resources.Pages.Extra;

public partial class Extra_Filter : Popup
{
    // private readonly Service_Auth _auth_service;
    // private readonly Service_Book _book_service;
    
    public Extra_Filter()
    {
        InitializeComponent();
        // _auth_service = Service_Auth.Instance;
        // _book_service = Service_Book.Instance;
    }

    public void popup_close(object sender, EventArgs args)
    {
        Close();
    }

    public void to_addbook(object sender, EventArgs args)
    {

        
        Close();
    }
}