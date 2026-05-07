namespace Novela.Resources.Services;

public class Service_SidebarState
{
    public static Service_SidebarState _instance;
    public static Service_SidebarState Instance => _instance ??= new Service_SidebarState();
    
    private Service_SidebarState() {}

    public bool IsSideBarOpen { get; set; } = true;
    public int rotation { get; set; } = 0;

    public EventHandler SidebarState;

    public void sidebar_state(bool sidebar_state)
    {
        if (IsSideBarOpen != sidebar_state)
        {
            IsSideBarOpen = sidebar_state;
            SidebarState?.Invoke(this, EventArgs.Empty);
        }
    }
}