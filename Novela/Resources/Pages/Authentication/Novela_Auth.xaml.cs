using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Novela.Resources.Models;
using Novela.Resources.Services;

namespace Novela.Resources.Pages.Authentication;

public partial class Novela_Auth : ContentPage
{
    private readonly Service_Auth _user_service;
    public Novela_Auth()
    {
        InitializeComponent();
        _user_service = Service_Auth.Instance;
        Shell.SetTitleView(this, null);
    }

    #region SignIn
        public void to_signin(object? sender, EventArgs args)
        {
            signup.IsVisible = false;
            signin.IsVisible = true;
        }
        
        public async void sign_in(object? sender, EventArgs args)
        {
            ErrorMessageA.IsVisible = false;
            ErrorMessageA.Text = string.Empty;
            var (success, message) = _user_service.Login(si_user.Text, si_psswd.Text);

            if (success) await Shell.Current.GoToAsync("//dashboard");
            else
            {
                ErrorMessageA.Text = message;
                ErrorMessageA.IsVisible = true;
            }
        }
    #endregion
    
    #region SignOut
        public void to_signup(object? sender, EventArgs args)
        {
            signin.IsVisible = false;
            signup.IsVisible = true;
        }
        
        public async void sign_up(object? sender, EventArgs args)
        {
            ErrorMessageB.IsVisible =  false;
            ErrorMessageB.Text = string.Empty;
            
            var (success, message) = _user_service.Register(su_user.Text, su_psswd1.Text, su_psswd2.Text);
            if (success)
            {
                _user_service.Login(su_user.Text, su_psswd1.Text);
                await Shell.Current.GoToAsync("//dashboard");
            } else
            {
                ErrorMessageB.Text = message;
                ErrorMessageB.IsVisible = true;
            }
        }
    #endregion
    
    #region EXTRAS
        public void psswd_visibility(object? sender, EventArgs args)
        {
            var button = sender as ImageButton;
            var entry = button?.CommandParameter as Entry;
            
            entry.IsPassword = !entry.IsPassword;
            button.Source = entry.IsPassword ? "icon_closedeye.png" : "icon_openeye.png";
        }
        
        public async void continue_guest(object? sender, EventArgs args)
        {
            
        }
    #endregion
}