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
        #region Private Fileds
        private readonly DataVerificationService _dataVerificationService;
        #endregion

        public SettingsPage(User user)
        {
            InitializeComponent();
            BindingContext = new SettingsViewModel(user);
            _dataVerificationService = new DataVerificationService();
        }

        private async void SaveButton_OnClicked(object sender, EventArgs e)
        {
            if (DataVerificationService.NullOrEmptyEntryText(
                UsernameEntryCell.Text, PasswordEntryCell.Text, EmailEntryCell.Text, FirstNameEntryCell.Text, AgeEntryCell.Text))
            {
                var registrationViewModel = BindingContext as RegistrationViewModel;
                if (registrationViewModel != null && registrationViewModel.RegisterNewUser(new User
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
                };
            }
            else
            {
                await DisplayAlert("Missing information!", "Pleasy, ensure that you give all necessary information" +
                                                           "(username, password, email, country, age)", "OK");
            }
        }

        #region EntryCell OnCompleted Events
        private async void UsernameEntryCell_OnCompleted(object sender, EventArgs e)
        {
            if (DataVerificationService.CheckEntryLength(UsernameEntryCell.Text, 16))
            {
                if (_dataVerificationService.CheckUsernameConstraint(UsernameEntryCell.Text))
                {
                    UsernameEntryCell.Text = "";
                    await DisplayAlert("Invalid username.", "User with this username already exists!", "OK");
                }
            }
            else
            {
                UsernameEntryCell.Text = "";
                await DisplayAlert("Invalid username.", "Username length should be less or equal than 16 symbols", "OK");
            }
        }
        private async void PasswordEntryCell_OnCompleted(object sender, EventArgs e)
        {
            if (DataVerificationService.CheckEntryLength(PasswordEntryCell.Text, 18))
            {
                PasswordEntryCell.Text = "";
                await DisplayAlert("Invalid password.", "Password length should be less or equal than 18 symbols", "OK");
            }
        }
        private async void EmailEntryCell_OnCompleted(object sender, EventArgs e)
        {
            if (DataVerificationService.CheckEntryLength(EmailEntryCell.Text, 32))
            {
                if (_dataVerificationService.CheckEmailAddressConstraint(EmailEntryCell.Text))
                {
                    EmailEntryCell.Text = "";
                    await DisplayAlert("Invalid email.", "User with this email already exists!", "OK");
                };
            }
            else
            {
                EmailEntryCell.Text = "";
                await DisplayAlert("Invalid email.", "User with this email already exists!", "OK");
            }
        }
        private async void FirstNameEntryCell_OnCompleted(object sender, EventArgs e)
        {
            if (DataVerificationService.CheckEntryLength(FirstNameEntryCell.Text, 30))
            {
                FirstNameEntryCell.Text = "";
                await DisplayAlert("Invalid first name.", "First name length should be less or equal than 30 symbols", "OK");
            }
        }
        private async void LastNameEntryCell_OnCompleted(object sender, EventArgs e)
        {
            if (DataVerificationService.CheckEntryLength(LastNameEntryCell.Text, 30))
            {
                LastNameEntryCell.Text = "";
                await DisplayAlert("Invalid last name.", "Last name length should be less or equal than 30 symbols", "OK");
            }
        }
        private async void CountryEntryCell_OnCompleted(object sender, EventArgs e)
        {
            if (DataVerificationService.CheckEntryLength(CountryEntryCell.Text, 16))
            {
                LastNameEntryCell.Text = "";
                await DisplayAlert("Invalid country.", "Country length should be less or equal than 16 symbols", "OK");
            }
        }
        private async void AgeEntryCell_OnCompleted(object sender, EventArgs e)
        {
            if (DataVerificationService.CheckEntryLength(AgeEntryCell.Text, 3))
            {
                AgeEntryCell.Text = "";
                await DisplayAlert("Invalid age.", "Age length should be less or equal than 3 symbols", "OK");
            }
        }

        #endregion

    }
}