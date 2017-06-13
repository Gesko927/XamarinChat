using HeroChatClient.ViewModels;
using HeroChatClient.Views;
using System;
using HeroChatClient.Models;
using Xamarin.Forms;

namespace HeroChatClient
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UsernameEntry.Text = "";
            PasswordEntry.Text = "";
        }

        private async void SignInBtn_OnClicked(object sender, EventArgs e)
        {
            var loginPageViewModel = BindingContext as LoginPageViewModel;

            var result = loginPageViewModel != null && loginPageViewModel.CheckLoginData(new LoginData
            {
                Password = PasswordEntry.Text,
                Username = UsernameEntry.Text
            });

            if (result)
            {
                await Navigation.PushModalAsync(new NavigationPage(
                    new HeroChatPage(loginPageViewModel.GetUser(UsernameEntry.Text))));
            }
            else
            {
                UsernameEntry.Text = null;
                PasswordEntry.Text = null;
                await DisplayAlert("Invalid data!", "Invalid username or password.", "OK");
            }
        }

        private async void SignUpBtn_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegistrationPage());
        }
    }
}
