using CommunityToolkit.Maui.Behaviors;

namespace Novela.Resources.Pages.Extra;

public partial class Book_Sidebar : ContentView
{
    private readonly Dictionary<string, (Border border, TouchBehavior touch)> _navigationItems;
    
    private bool _sidebar_open = true;
    private double _sidebar_rotation = 0;
    public event EventHandler<string>? section_changed;

    public Book_Sidebar()
    {
        InitializeComponent();
        
        _navigationItems = new Dictionary<string, (Border, TouchBehavior)>
        {
            ["overview"] = (border_overview, touch_overview),
            ["characters"] = (border_characters, touch_characters),
            ["timeline"] = (border_timeline, touch_timeline),
            ["manuscript"] = (border_manuscript, touch_manuscript),
            ["appendices"] = (border_appendices, touch_appendices)
        };
        
        Loaded += OnLoaded;
    }

    private void OnLoaded(object sender, EventArgs e)
    {
        toggle_sidebar.Rotation = _sidebar_rotation;
        set_activeitem("overview");
    }
    

    public void set_activeitem(string sidebar_item)
    {
        var inactive = Colors.Transparent;
        var active = Application.Current.RequestedTheme == AppTheme.Dark ? Color.FromArgb("#2C2C2C") : Color.FromArgb("#F0F0F0");
        
        foreach (var (border, touch) in _navigationItems.Values)
        {
            border.BackgroundColor = inactive;
            touch.DefaultBackgroundColor = inactive;
        }
        
        if (_navigationItems.TryGetValue(sidebar_item.ToLower(), out var item))
        {
            item.border.BackgroundColor = active;
            item.touch.DefaultBackgroundColor = active;
        }
    }

    public async void on_togglesidebar(object sender, EventArgs e)
    {
        _sidebar_rotation = (_sidebar_rotation + 180) % 360;
        _sidebar_open = !_sidebar_open;

        double target = _sidebar_open ? 150 : 60;
        
        await Task.WhenAll(animate_sidebar(target), toggle_sidebar.RotateToAsync(_sidebar_rotation, 250, Easing.CubicInOut) );
    }

    public void to_overview(object? sender, EventArgs e) { section_changed?.Invoke(this, "overview"); }
    public void to_characters(object? sender, EventArgs e) { section_changed?.Invoke(this,"characters"); }
    public void to_timeline(object? sender, EventArgs e) { section_changed?.Invoke(this,"timeline"); }
    public void to_manuscript(object? sender, EventArgs e) { section_changed?.Invoke(this,"manuscript"); }
    public void to_appendices(object? sender, EventArgs e) { section_changed?.Invoke(this,"appendices"); }
    public async void to_dashboard(object? sender, EventArgs e) => await Shell.Current.GoToAsync("//dashboard");
    
    #region ANIMATION

    private Task animate_sidebar(double target_width)
    {
        var tcs = new TaskCompletionSource<bool>();

        new Animation(v => WidthRequest = v, Width, target_width)
            .Commit(this, "SidebarWidth", 24, 250, Easing.CubicInOut, (v, c)=> tcs.SetResult(true) );

        return tcs.Task;
    }
    #endregion
}
