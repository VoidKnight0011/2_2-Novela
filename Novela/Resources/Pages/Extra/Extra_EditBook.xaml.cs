using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Views;
using SQLite;
using Novela.Resources.Services;
using Novela.Resources.Models.Book_Models;
using Novela.Resources.Helpers;

namespace Novela.Resources.Pages.Extra;

public partial class Extra_EditBook : Popup
{
    private readonly Service_Auth _auth_service;
    private readonly Service_Book _book_service;
    public readonly Novela.Resources.Models.Book_Models.Book CurrentBook;
    private string _pathCover;
    
    public Extra_EditBook(Novela.Resources.Models.Book_Models.Book book)
    {
        InitializeComponent();
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsVisible = false });
        
        _auth_service = Service_Auth.Instance;
        _book_service = Service_Book.Instance;
        CurrentBook = book;
        _pathCover = CurrentBook.book_cover_path;
        
        BindingContext = CurrentBook;
    }
    
    private async void on_editcover(object sender, EventArgs e)
    {
        FileResult result = await FilePicker.Default.PickAsync(new PickOptions
        {
            PickerTitle = "Select Cover Image",
            FileTypes = FilePickerFileType.Images
        });

        if (result == null) return;
        
        _pathCover = await Helper_Image.image_coversave(result, CurrentBook.book_id, _pathCover);
        CurrentBook.book_cover_path = _pathCover;
    }
    
    public void popup_close(object sender, EventArgs args)
    {
        Close();
    }

    public void popup_save(object sender, EventArgs args)
    {
        CurrentBook.book_title = book_title.Text;
        CurrentBook.book_description = book_description.Text;
        if(CurrentBook.book_cover_path != _pathCover) CurrentBook.book_cover_path = _pathCover;
        _book_service.update_book(CurrentBook);
        Close();
    }
    
}