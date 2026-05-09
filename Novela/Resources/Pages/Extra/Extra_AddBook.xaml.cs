using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Views;
using Novela.Resources.Enums;
using Novela.Resources.Services;

namespace Novela.Resources.Pages.Extra;

public partial class Extra_AddBook : Popup
{
    private readonly Service_Auth _auth_service;
    private readonly Service_Book _book_service;
    public Extra_AddBook()
    {
        InitializeComponent();
    }

    public void popup_close(object sender, EventArgs args)
    {
        Close();
    }

    public void to_addbook(object sender, EventArgs args)
    {
        var new_book = new Models.Book_Models.Book()
        {
            user_id = _auth_service.CurrentUser.user_id,
            book_title = book_title.Text,
            book_description = book_desc.Text,
            book_status = Status.Draft
        };
            
        _book_service.create_book(new_book);    
        Close();
    }
}