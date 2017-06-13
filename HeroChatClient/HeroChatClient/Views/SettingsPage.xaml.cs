using System;
using HeroChatClient.Models;
using HeroChatClient.Services;
using HeroChatClient.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HeroChatClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage(User user)
        {
            InitializeComponent();
            BindingContext = new UserDataViewModel(new PageService(), user);
        }

        private async void SaveButton_OnClicked(object sender, EventArgs e)
        {
            if (((UserDataViewModel)BindingContext).NullOrEmptyEntryText(
                UsernameEntryCell.Text,
                PasswordEntryCell.Text,
                EmailEntryCell.Text,
                FirstNameEntryCell.Text,
                AgeEntryCell.Text))
            {
                var userDataViewModel = (UserDataViewModel)BindingContext;
                if (userDataViewModel != null && userDataViewModel.RegisterOrUpdateUser(new User
                {
                    Age = AgeEntryCell.Text,
                    Country = CountryEntryCell.Text,
                    Email = EmailEntryCell.Text,
                    FirstName = FirstNameEntryCell.Text,
                    LastName = LastNameEntryCell.Text,
                    Password = PasswordEntryCell.Text,
                    Username = UsernameEntryCell.Text
                }))
                {
                    await Navigation.PopModalAsync();
                }
            }
        }

        #region Entries OnCompleted Events
        private void UsernameEntryCell_OnCompleted(object sender, EventArgs e)
        {
            if (!((UserDataViewModel)BindingContext).CheckUsername(UsernameEntryCell.Text, 16))
            {
                UsernameEntryCell.Text = "";
            }
        }

        private void EmailEntryCell_OnCompleted(object sender, EventArgs e)
        {
            if (!((UserDataViewModel)BindingContext).CheckEmailAddress(EmailEntryCell.Text, 32))
            {
                EmailEntryCell.Text = "";
            }
        }

        private void CountryEntryCell_OnCompleted(object sender, EventArgs e)
        {
            if (!((UserDataViewModel)BindingContext).CheckEntryLength(CountryEntryCell.Text, 16))
            {
                CountryEntryCell.Text = "";
            }
        }

        private void AgeEntryCell_OnCompleted(object sender, EventArgs e)
        {
            if (!((UserDataViewModel)BindingContext).CheckEntryLength(AgeEntryCell.Text, 3))
            {
                AgeEntryCell.Text = "";
            }
        }

        private void LastNameEntryCell_OnCompleted(object sender, EventArgs e)
        {
            if (!((UserDataViewModel)BindingContext).CheckEntryLength(LastNameEntryCell.Text, 30))
            {
                LastNameEntryCell.Text = "";
            }
        }

        private void FirstNameEntryCell_OnCompleted(object sender, EventArgs e)
        {
            if (!((UserDataViewModel)BindingContext).CheckEntryLength(FirstNameEntryCell.Text, 30))
            {
                FirstNameEntryCell.Text = "";
            }
        }

        private void PasswordEntryCell_OnCompleted(object sender, EventArgs e)
        {
            if (!((UserDataViewModel)BindingContext).CheckEntryLength(PasswordEntryCell.Text, 18))
            {
                PasswordEntryCell.Text = "";
            }
        }
        #endregion

    }
}