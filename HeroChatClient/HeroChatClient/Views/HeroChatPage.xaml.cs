using System;
using HeroChatClient.Models;
using HeroChatClient.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HeroChatClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HeroChatPage : ContentPage
    {
        #region Private Fields
        private readonly User _currentUser;
        #endregion

        public HeroChatPage(User user)
        {
            InitializeComponent();
            _currentUser = user;
            BindingContext = new HeroChatViewModel(_currentUser);
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var chatDetailViewModel = (HeroChatViewModel)BindingContext;
            chatDetailViewModel?.SelectMessageListCommand.Execute(e.SelectedItem as ChatMessage);
        }

        private async void SendMessageBtn_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(MessageEntry.Text))
            {
                ((HeroChatViewModel)BindingContext)?.SendMessageCommmand.Execute(MessageEntry.Text);
                MessageEntry.Text = "";
            }
            else
            {
                await DisplayAlert("Empty message", "Please, input your message", "OK");
            }
        }

        private void ListItemContext_Clicked(object sender, EventArgs e)
        {
            var selectedMenuItem = sender as MenuItem;
            var message = selectedMenuItem?.CommandParameter as ChatMessage;
            ((HeroChatViewModel)BindingContext)?.DeleteMessageCommand.Execute(message);
        }

        #region MenuItem Clicked Events
        private async void SettingMenuItem_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new SettingsPage(_currentUser)));
        }
        private async void SignOutMenuItem_OnClicked(object sender, EventArgs e)
        {
            var res = await DisplayAlert("Sign Out", "Do you really want to change account?", "Yes", "No");
            if (!res) return;
            (BindingContext as HeroChatViewModel)?.DisconnectCommand.Execute(null);
            await Navigation.PopModalAsync();
        }
        #endregion

    }
}