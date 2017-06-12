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
            BindingContext = new MainPageViewModel();
        }

        private async void SignInBtn_OnClicked(object sender, EventArgs e)
        {
            var mainPageViewModel = BindingContext as MainPageViewModel;

            var result = mainPageViewModel != null && mainPageViewModel.CheckLoginData(new LoginData
            {
                Password = PasswordEntry.Text,
                Username = UsernameEntry.Text
            });

            if (result)
            {
                await Navigation.PushModalAsync(new NavigationPage(
                    new HeroChatPage(mainPageViewModel.GetUser(UsernameEntry.Text))));
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
