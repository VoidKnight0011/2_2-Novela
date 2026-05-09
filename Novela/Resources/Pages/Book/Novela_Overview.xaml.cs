using Novela.Resources.Enums;

namespace Novela.Resources.Pages.Book;

public partial class Novela_Overview : ContentView
{
    public Novela_Overview()
    {
        InitializeComponent();
        BindingContext = this;
    }

    public Book_Genre[] GenreOptions { get; } = Enum.GetValues<Book_Genre>();

    private void on_cancel(object sender, EventArgs e) { }
    private void on_save(object sender, EventArgs e) { }
    private void on_addtheme(object sender, EventArgs e) { }
    private void on_changecover(object sender, EventArgs e) { }
}