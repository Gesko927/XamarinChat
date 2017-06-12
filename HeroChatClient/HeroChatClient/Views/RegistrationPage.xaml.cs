using System;
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
        #region Private Fields
        private readonly DataVerificationService _dataVerificationService;
        #endregion

        public RegistrationPage()
        {
            InitializeComponent();
            BindingContext = new RegistrationViewModel();
            _dataVerificationService = new DataVerificationService();
        }

        private async void SignUpBtn_OnClicked(object sender, EventArgs e)
        {
            if (DataVerificationService.NullOrEmptyEntryText(
                UsernameEntry.Text, PasswordEntry.Text, EmailEntry.Text, FirstNameEntry.Text, AgeEntry.Text))
            {
                var registrationViewModel = BindingContext as RegistrationViewModel;
                if (registrationViewModel != null && registrationViewModel.RegisterNewUser(new User
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
                };
            }
            else
            {
                await DisplayAlert("Missing information!", "Pleasy, ensure that you give all necessary information" +
                                                     "(username, password, email, country, age)", "OK");
            }
        }

        #region Entries OnCompleted Events
        private async void UsernameEntry_OnCompleted(object sender, EventArgs e)
        {
            if (DataVerificationService.CheckEntryLength(UsernameEntry.Text, 16))
            {
                if (_dataVerificationService.CheckUsernameConstraint(UsernameEntry.Text))
                {
                    UsernameEntry.Text = "";
                    await DisplayAlert("Invalid username.", "User with this username already exists!", "OK");
                }
            }
            else
            {
                UsernameEntry.Text = "";
                await DisplayAlert("Invalid username.", "Username length should be less or equal than 16 symbols", "OK");
            }
        }

        private async void EmailEntry_OnCompleted(object sender, EventArgs e)
        {
            if (DataVerificationService.CheckEntryLength(EmailEntry.Text, 32))
            {
                if (_dataVerificationService.CheckEmailAddressConstraint(EmailEntry.Text))
                {
                    EmailEntry.Text = "";
                    await DisplayAlert("Invalid email.", "User with this email already exists!", "OK");
                };
            }
            else
            {
                EmailEntry.Text = "";
                await DisplayAlert("Invalid email.", "User with this email already exists!", "OK");
            }
        }

        private async void CountryEntry_OnCompleted(object sender, EventArgs e)
        {
            if (DataVerificationService.CheckEntryLength(CountryEntry.Text, 16))
            {
                LastNameEntry.Text = "";
                await DisplayAlert("Invalid country.", "Country length should be less or equal than 16 symbols", "OK");
            }
        }

        private async void AgeEntry_OnCompleted(object sender, EventArgs e)
        {
            if (DataVerificationService.CheckEntryLength(AgeEntry.Text, 3))
            {
                AgeEntry.Text = "";
                await DisplayAlert("Invalid age.", "Age length should be less or equal than 3 symbols", "OK");
            }
        }

        private async void LastNameEntry_OnCompleted(object sender, EventArgs e)
        {
            if (DataVerificationService.CheckEntryLength(LastNameEntry.Text, 30))
            {
                LastNameEntry.Text = "";
                await DisplayAlert("Invalid last name.", "Last name length should be less or equal than 30 symbols", "OK");
            }
        }

        private async void FirstNameEntry_OnCompleted(object sender, EventArgs e)
        {
            if (DataVerificationService.CheckEntryLength(FirstNameEntry.Text, 30))
            {
                FirstNameEntry.Text = "";
                await DisplayAlert("Invalid first name.", "First name length should be less or equal than 30 symbols", "OK");
            }
        }

        private async void PasswordEntry_OnCompleted(object sender, EventArgs e)
        {
            if (DataVerificationService.CheckEntryLength(PasswordEntry.Text, 18))
            {
                PasswordEntry.Text = "";
                await DisplayAlert("Invalid password.", "Password length should be less or equal than 18 symbols", "OK");
            }
        }
        #endregion

    }
}