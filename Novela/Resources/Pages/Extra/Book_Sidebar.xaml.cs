using CommunityToolkit.Maui.Views;
using Novela.Resources.Services;

namespace Novela.Resources.Pages.Extra;

public partial class Book_Sidebar : ContentView
{
    private readonly Service_SidebarState _state;
    public event EventHandler<bool> sidebar_toggled;

    public Book_Sidebar()
    {
        InitializeComponent();

        _state = Service_SidebarState.Instance;
        _state.SidebarStateChanged += OnSidebarStateChanged;
        
        Loaded += OnLoaded;
    }

    private void OnLoaded(object sender, EventArgs e)
    {
        toggle_sidebar.Rotation = _state.Rotation;
    }

    public async void on_togglesidebar(object sender, EventArgs e)
    {
        _state.Rotation = (_state.Rotation + 180) % 360;
        _state.SetState(!_state.IsSideBarOpen);

        await toggle_sidebar.RotateToAsync(_state.Rotation, 750, Easing.CubicInOut);
    }

    private void OnSidebarStateChanged(object sender, bool isOpen)
    {
        sidebar_toggled?.Invoke(sender, isOpen);
    }
    

    public void set_activeitem(string itemName)
    {
        var inactive = Colors.Transparent;
        var active   = Application.Current.RequestedTheme == AppTheme.Dark
                           ? Color.FromArgb("#2C2C2C")
                           : Color.FromArgb("#F0F0F0");

        button_overview.BackgroundColor    = inactive;
        button_characters.BackgroundColor  = inactive;
        button_timeline.BackgroundColor    = inactive;
        button_manuscript.BackgroundColor  = inactive;
        button_appendices.BackgroundColor  = inactive;

        var target = itemName.ToLower() switch
        {
            "overview"    => button_overview,
            "characters"  => button_characters,
            "timeline"    => button_timeline,
            "manuscript"  => button_manuscript,
            "appendices"  => button_appendices,
            _             => null
        };

        if (target != null)
            target.BackgroundColor = active;
    }

    protected override void OnHandlerChanging(HandlerChangingEventArgs args)
    {
        if (args.NewHandler == null)
            _state.SidebarStateChanged -= OnSidebarStateChanged;

        base.OnHandlerChanging(args);
    }

    public async void to_dashboard(object? sender, EventArgs e)    => await Shell.Current.GoToAsync("//dashboard");
    public async void to_overview(object? sender, EventArgs e)     => await Shell.Current.GoToAsync("//overview");
    public async void to_characters(object? sender, EventArgs e)   => await Shell.Current.GoToAsync("//characters");
    public async void to_timeline(object? sender, EventArgs e)     => await Shell.Current.GoToAsync("//timeline");
    public async void to_manuscript(object? sender, EventArgs e)   => await Shell.Current.GoToAsync("//manuscript");
    public async void to_appendices(object? sender, EventArgs e)   => await Shell.Current.GoToAsync("//appendices");
}