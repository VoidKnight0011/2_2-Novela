using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Views;
using SQLite;
using Novela.Resources.Services;
using Novela.Resources.Models.Book_Models;

namespace Novela.Resources.Pages.Extra;

public partial class Extra_EditBook : Popup
{
    private readonly Service_Auth _auth_service;
    private readonly Service_Book _book_service;
    private readonly Novela.Resources.Models.Book_Models.Book _currentbook;
    
    public Extra_EditBook(Novela.Resources.Models.Book_Models.Book book)
    {
        InitializeComponent();
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsVisible = false });
        
        _auth_service = Service_Auth.Instance;
        _book_service = Service_Book.Instance;
        _currentbook = book;
        
        LoadBook();
    }

    private void LoadBook()
    {
        book_title.Text = _currentbook.book_title;
        book_description.Text = _currentbook.book_description;
        
        // if (_currentbook.book_cover_data != null)
        // {
        //     _selectedCoverData = _currentBook.book_cover_data;
        //     CoverPreview.Source = _currentBook.CoverImage;
        // }
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
        _currentbook.book_title = book_title.Text;
        _currentbook.book_description = book_description.Text;
        _book_service.update_book(_currentbook);
        Close();
    }
}