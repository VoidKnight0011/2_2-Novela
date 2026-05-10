using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Novela.Resources.Services;

namespace Novela.Resources.Pages.Extra;

public partial class Book_Header : ContentView
{
    private readonly Service_Book _book_service;
    private Novela.Resources.Models.Book_Models.Book _currentBook;
    public Book_Header()
    {
        InitializeComponent();
        _book_service = Service_Book.Instance;
    
        Loaded += OnLoaded;
    }

    private void OnLoaded(object sender, EventArgs e)
    {
        _currentBook = _book_service.CurrentBook;
        if (_currentBook != null)
            book_title.Text = _currentBook.book_title;
    }
}