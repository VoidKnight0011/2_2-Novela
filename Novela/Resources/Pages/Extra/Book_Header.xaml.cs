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
    public Novela.Resources.Models.Book_Models.Book current_book { get; set; }
    public Book_Header()
    {
        InitializeComponent();
        _book_service = Service_Book.Instance;
        current_book =  _book_service.CurrentBook;

        BindingContext = this;
        Loaded += OnLoaded;
    }

    private void OnLoaded(object sender, EventArgs e)
    {
        current_book = _book_service.CurrentBook;
    }

    public async void edit_title(object sender, EventArgs e)
    {
        book_title_label.IsVisible = false;
        book_title_entry.IsVisible = true;
        book_title_entry.Focus();
    }

    public async void book_entry_unfocused(object sender, EventArgs e)
    {
        if (current_book != null)
        {
            current_book.book_title = book_title_entry.Text;
            _book_service.update_book(current_book);
            book_title_label.Text = current_book.book_title;
        }
        book_title_entry.IsVisible = false;
        book_title_label.IsVisible = true;
    }
}