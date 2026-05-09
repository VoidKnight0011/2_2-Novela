using CommunityToolkit.Maui.Behaviors;
using Novela.Resources.Services;

namespace Novela.Resources.Pages.Extra;

public partial class Book_Sidebar : ContentView
{
    private readonly Service_SidebarState _state;
    
    // Single data structure holding both Border and TouchBehavior references
    private readonly Dictionary<string, (Border border, TouchBehavior touch)> _navigationItems;
    
    public event EventHandler<bool> sidebar_toggled;
    public event EventHandler<string> section_toggle;

    public Book_Sidebar()
    {
        InitializeComponent();
        
        // Initialize navigation items dictionary with paired references
        _navigationItems = new Dictionary<string, (Border, TouchBehavior)>
        {
            ["overview"] = (border_overview, touch_overview),
            ["characters"] = (border_characters, touch_characters),
            ["timeline"] = (border_timeline, touch_timeline),
            ["manuscript"] = (border_manuscript, touch_manuscript),
            ["appendices"] = (border_appendices, touch_appendices)
        };
        
        _state = Service_SidebarState.Instance;
        _state.SidebarStateChanged += OnSidebarStateChanged;
        Loaded += OnLoaded;
    }

    private void OnLoaded(object sender, EventArgs e)
    {
        toggle_sidebar.Rotation = _state.Rotation;
        set_activeitem("overview");
    }

    private void OnSidebarStateChanged(object sender, bool isOpen)
    {
        sidebar_toggled?.Invoke(sender, isOpen);
    }

    public void set_activeitem(string itemName)
    {
        var inactive = Colors.Transparent;
        var active = Application.Current.RequestedTheme == AppTheme.Dark
            ? Color.FromArgb("#2C2C2C")
            : Color.FromArgb("#F0F0F0");

        // Reset all items to inactive - set BOTH border and touch behavior
        foreach (var (border, touch) in _navigationItems.Values)
        {
            border.BackgroundColor = inactive;
            touch.DefaultBackgroundColor = inactive;
        }

        // Set active item if it exists - set BOTH border and touch behavior
        if (_navigationItems.TryGetValue(itemName.ToLower(), out var activeItem))
        {
            activeItem.border.BackgroundColor = active;
            activeItem.touch.DefaultBackgroundColor = active;
        }
    }

    protected override void OnHandlerChanging(HandlerChangingEventArgs args)
    {
        if (args.NewHandler == null)
            _state.SidebarStateChanged -= OnSidebarStateChanged;
        base.OnHandlerChanging(args);
    }

    public async void on_togglesidebar(object sender, EventArgs e)
    {
        _state.Rotation = (_state.Rotation + 180) % 360;
        _state.SetState(!_state.IsSideBarOpen);

        double target = _state.IsSideBarOpen ? 150 : 60;
        var tcs = new TaskCompletionSource();

        new Animation(v => WidthRequest = v, Width, target)
            .Commit(this, "SidebarWidth", 16, 750, Easing.CubicInOut,
                (v, c) => tcs.SetResult());

        await Task.WhenAll(
            tcs.Task,
            toggle_sidebar.RotateToAsync(_state.Rotation, 750, Easing.CubicInOut)
        );
    }

    public void to_overview(object? sender, EventArgs e)
    {
        set_activeitem("overview");
        section_toggle?.Invoke(this, "overview");
    }

    public void to_characters(object? sender, EventArgs e)
    {
        set_activeitem("characters");
        section_toggle?.Invoke(this, "characters");
    }

    public void to_timeline(object? sender, EventArgs e)
    {
        set_activeitem("timeline");
        section_toggle?.Invoke(this, "timeline");
    }

    public void to_manuscript(object? sender, EventArgs e)
    {
        set_activeitem("manuscript");
        section_toggle?.Invoke(this, "manuscript");
    }

    public void to_appendices(object? sender, EventArgs e)
    {
        set_activeitem("appendices");
        section_toggle?.Invoke(this, "appendices");
    }

    public async void to_dashboard(object? sender, EventArgs e) => await Shell.Current.GoToAsync("//dashboard");
}
