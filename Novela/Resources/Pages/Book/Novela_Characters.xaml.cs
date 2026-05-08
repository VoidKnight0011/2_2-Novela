using System.Collections.ObjectModel;
using Novela.Resources.Services;

namespace Novela.Resources.Pages.Book;

public partial class Novela_Characters : ContentPage
{
    private readonly Service_SidebarState _sidebarState;

    public ObservableCollection<CharacterEntry> Characters { get; } = [];

    public Novela_Characters()
    {
        InitializeComponent();
        _sidebarState = Service_SidebarState.Instance;

        Sidebar.set_activeitem("characters");
        Sidebar.sidebar_toggled += on_togglesidebar;
        BindingContext = this;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Sidebar.WidthRequest = _sidebarState.IsSideBarOpen ? 150 : 60;
    }
    
    #region DashboardLayer#0
    private void to_settings(object sender, EventArgs e) { }

    private void to_about(object sender, EventArgs e) { }

    private async void to_logout(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//auth");
    }
    #endregion

    #region CharactersLayer#1

    // Matches the animated version from Overview
    public async void on_togglesidebar(object sender, bool isopen)
    {
        double sidebarWidth = isopen ? 150 : 60;

        var tcs = new TaskCompletionSource();

        var animation = new Animation(
            v => Sidebar.WidthRequest = v,
            Sidebar.Width,
            sidebarWidth);

        animation.Commit(
            this,
            "SidebarWidth",
            16,
            1000,
            Easing.CubicInOut,
            (v, c) => tcs.SetResult());

        await tcs.Task;
    }

    private void on_addcharacter(object sender, EventArgs e)
    {
        var name = CharacterNameEntry.Text?.Trim();
        if (string.IsNullOrEmpty(name)) return;

        Characters.Add(new CharacterEntry
        {
            Name = name,
            Role = "Supporting",        // default; editable later
            Description = string.Empty
        });

        CharacterNameEntry.Text = string.Empty;
    }

    private void on_deletecharacter(object sender, EventArgs e)
    {
        if (sender is ImageButton btn && btn.CommandParameter is CharacterEntry target)
            Characters.Remove(target);
    }

    #endregion
}

// Simple model — move to its own file under Models/ when it grows
public class CharacterEntry
{
    public string Name        { get; set; } = string.Empty;
    public string Role        { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}