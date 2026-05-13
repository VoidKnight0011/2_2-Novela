using Novela.Resources.Pages.Book;

namespace Novela;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("editor", typeof(Novela_Editor));
        Routing.RegisterRoute("preview", typeof(Novela_Preview));
        Routing.RegisterRoute("charprofile", typeof(Novela_CharacterProfile));
    }
}