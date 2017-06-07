using HeroChatClient.ViewModels;
using HeroChatClient.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            await Navigation.PushModalAsync(new ChatPage());
        }

        private async void SignUpBtn_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegistrationPage());
        }
    }
}
