using HeroChatClient.Models;
using HeroChatClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HeroChatClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPageDetail : ContentPage
    {
        public ChatPageDetail()
        {
            InitializeComponent();
            BindingContext = new ChatDetailViewModel(Username.Text);
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var chatDetailViewModel = BindingContext as ChatDetailViewModel;
            chatDetailViewModel?.SelectMessageListCommand.Execute(e.SelectedItem as ChatMessage);
        }

        private async void SendMessageBtn_Clicked(object sender, EventArgs e)
        {
            //await StartConnecting();

            if (!String.IsNullOrEmpty(messageEntry.Text))
            {
                (BindingContext as ChatDetailViewModel).SendMessageCommmand.Execute(messageEntry.Text);
                messageEntry.Text = "";
            }
            else
            {
                await DisplayAlert("Empty message", "Please, input your message", "Horosho");
            }
        }

        //async Task StartConnecting()
        //{
        //    Task connectSocket = Connect();
        //    await connectSocket;
        //}

        //public async Task Connect()
        //{
        //    var address = "127.0.0.1";
        //    var port = 8888;
        //    var r = new Random();
        //    client = new TcpSocketClient();
        //    await client.ConnectAsync(address, port);
        //    await DisplayAlert("Empty message", "Please, input your message", "Horosho");
        //    // we're connected!
        //    for (int i = 0; i < 5; i++)
        //    {
        //        // write to the 'WriteStream' property of the socket client to send data
        //        var nextByte = (byte)r.Next(0, 254);
        //        client.WriteStream.WriteByte(nextByte);
        //        await client.WriteStream.FlushAsync();
        //        // wait a little before sending the next bit of data
        //        await Task.Delay(TimeSpan.FromMilliseconds(500));
        //    }
        //    await client.DisconnectAsync();
        //}

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            var selectedMenuItem = sender as MenuItem;
            var message = selectedMenuItem.CommandParameter as ChatMessage;
            (BindingContext as ChatDetailViewModel).DeleteMessageCommand.Execute(message);
        }
    }
}