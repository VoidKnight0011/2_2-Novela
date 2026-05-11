using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Content;
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
        _currentBook =  _book_service.CurrentBook;

        BindingContext = this;
        Loaded += OnLoaded;
    }

    private void OnLoaded(object sender, EventArgs e)
    {
        _currentBook = _book_service.CurrentBook;
    }

    public async void edit_title(object sender, EventArgs e)
    {
        book_title_label.IsVisible = false;
        book_title_entry.IsVisible = true;
        book_title_entry.Focus();
    }

    public async void book_entry_unfocused(object sender, EventArgs e)
    {
        if (_currentBook != null)
        {
            _currentBook.book_title = book_title_entry.Text;
            _book_service.update_book(_currentBook);
            book_title_label.Text = _currentBook.book_title;
        }
        book_title_entry.IsVisible = false;
        book_title_label.IsVisible = true;
    }
}