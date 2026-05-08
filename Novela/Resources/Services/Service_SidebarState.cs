namespace Novela.Resources.Services;

public class Service_SidebarState
{
    private static Service_SidebarState _instance;
    public static Service_SidebarState Instance => _instance ??= new Service_SidebarState();

    private Service_SidebarState() { }

    public bool IsSideBarOpen { get; set; } = true;
    public double Rotation    { get; set; } = 0;

    public event EventHandler<bool> SidebarStateChanged;

    public void SetState(bool isOpen)
    {
        if (IsSideBarOpen == isOpen) return;
        IsSideBarOpen = isOpen;
        SidebarStateChanged?.Invoke(this, IsSideBarOpen);
    }
}