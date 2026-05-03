using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Novela.Resources.Models;

namespace Novela.Resources.Pages.Authentication;

public partial class Novela_Auth : ContentPage
{
    // private User
    public Novela_Auth()
    {
        InitializeComponent();
    }

    // Toggle Sign In/Out
    public void to_signin(object? sender, EventArgs args)
    {
        signup.IsVisible = false;
        signin.IsVisible = true;
    }
    
    public void to_signup(object? sender, EventArgs args)
    {
        signin.IsVisible = false;
        signup.IsVisible = true;
    }
    
    // Buttons
    public void psswd_visibility(object? sender, EventArgs args)
    {
        var button = sender as ImageButton;
        var entry = button?.CommandParameter as Entry;
        
        entry.IsPassword = !entry.IsPassword;
        button.Source = entry.IsPassword ? "icon_closedeye.png" : "icon_openeye.png";
    }
    
    public async void sign_in(object? sender, EventArgs args)
    {
        await Shell.Current.GoToAsync("//dashboard");
    }
    public async void sign_up(object? sender, EventArgs args)
    {
        await Shell.Current.GoToAsync("//dashboard");
    }
    
    public async void continue_guest(object? sender, EventArgs args)
    {
        
    }
}