using System;
using HeroChatClient.Exceptions;
using HeroChatClient.Models;
using HeroChatClient.Services;
using HeroChatClient.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HeroChatClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
            BindingContext = new UserDataViewModel(new PageService());
        }

        private async void SignUpBtn_OnClicked(object sender, EventArgs e)
        {
            if (((UserDataViewModel)BindingContext).NullOrEmptyEntryText(
                   UsernameEntry.Text,
                   PasswordEntry.Text,
                   EmailEntry.Text,
                   FirstNameEntry.Text,
                   AgeEntry.Text))
            {
                var userDataViewModel = (UserDataViewModel)BindingContext;
                if (userDataViewModel != null && userDataViewModel.RegisterOrUpdateUser(new User
                {
                    Age = AgeEntry.Text,
                    Country = CountryEntry.Text,
                    Email = EmailEntry.Text,
                    FirstName = FirstNameEntry.Text,
                    LastName = LastNameEntry.Text,
                    Password = PasswordEntry.Text,
                    Username = UsernameEntry.Text
                }))
                {
                    await Navigation.PopModalAsync();
                }
            }
        }

        #region Entries OnCompleted Events
        private void UsernameEntry_OnCompleted(object sender, EventArgs e)
        {
            if (!((UserDataViewModel) BindingContext).CheckUsername(UsernameEntry.Text, 16))
            {
                UsernameEntry.Text = "";
            }
        }

        private void EmailEntry_OnCompleted(object sender, EventArgs e)
        {
            if (!((UserDataViewModel) BindingContext).CheckEmailAddress(EmailEntry.Text, 32))
            {
                EmailEntry.Text = "";
            }
        }

        private void CountryEntry_OnCompleted(object sender, EventArgs e)
        {
            if (!((UserDataViewModel) BindingContext).CheckEntryLength(CountryEntry.Text, 16))
            {
                CountryEntry.Text = "";
            }
        }

        private void AgeEntry_OnCompleted(object sender, EventArgs e)
        {
            if (!((UserDataViewModel) BindingContext).CheckEntryLength(AgeEntry.Text, 3))
            {
                AgeEntry.Text = "";
            }
        }

        private void LastNameEntry_OnCompleted(object sender, EventArgs e)
        {
            if (!((UserDataViewModel)BindingContext).CheckEntryLength(LastNameEntry.Text, 30))
            {
                LastNameEntry.Text = "";
            }
        }

        private void FirstNameEntry_OnCompleted(object sender, EventArgs e)
        {
            if (!((UserDataViewModel)BindingContext).CheckEntryLength(FirstNameEntry.Text, 30))
            {
                FirstNameEntry.Text = "";
            }
        }

        private void PasswordEntry_OnCompleted(object sender, EventArgs e)
        {

            if (!((UserDataViewModel)BindingContext).CheckEntryLength(PasswordEntry.Text, 18))
            {
                PasswordEntry.Text = "";
            }
        }
        #endregion

    }
}