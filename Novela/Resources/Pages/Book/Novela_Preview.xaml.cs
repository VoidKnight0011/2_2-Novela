using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Novela.Resources.Services;

namespace Novela.Resources.Pages.Book;

public partial class Novela_Preview : ContentView
{
    private readonly Service_Auth _auth_service;
    private readonly Service_Book _book_service;
    private readonly Novela.Resources.Models.Book_Models.Book CurrentBook;
    
    public Novela_Preview()
    {
        InitializeComponent();
        _auth_service = Service_Auth.Instance;
        _book_service = Service_Book.Instance;
        CurrentBook = _book_service.CurrentBook;
        
        BindingContext = this;
        
        Loaded += OnLoaded;
    }

    private void OnLoaded(object sender, EventArgs eventArgs)
    {
        book_cover.Source = CurrentBook.book_cover;
        book_title.Text = CurrentBook.book_title;
        user_name.Text = _auth_service.CurrentUser.user_name;
    }
    
}