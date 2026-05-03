using Novela.Resources.Enums;
using Novela.Resources.Models;

namespace Novela.Resources.Pages.Book;

public partial class Novela_Dashboard : ContentPage
{
    public Novela_Dashboard()
    {
        InitializeComponent();
        Shell.SetNavBarIsVisible(this, true);
        BindingContext = this;
    }
    
    // Header
    private void OnSettings(object sender, EventArgs e)
    {

    }

    private void OnAbout(object sender, EventArgs e)
    {

    }

    private async void OnLogout(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//auth");
    }

    // Filter
    public Array StatusOptions => Enum.GetValues(typeof(Status));
    public Status DefaultStatus { get; set; } = Status.Draft;

    // Book Grid
    private async void OnBookOptionsClicked(object sender, EventArgs e)
    {
        string action = await DisplayActionSheet(
            "Book Options",
            "Cancel",
            null,
            "Edit",
            "Delete",
            "Save"
        );

        if (action == "Cancel" || action == null)
            return;

        switch (action)
        {
            case "Edit":
                await DisplayAlert("Edit", "Edit clicked", "OK");
                break;

            case "Delete":
                await DisplayAlert("Delete", "Delete clicked", "OK");
                break;

            case "Save":
                await DisplayAlert("Save", "Save clicked", "OK");
                break;
        }
    }

    private async void OnTapped(object sender, EventArgs e)
    {
        
    }
}