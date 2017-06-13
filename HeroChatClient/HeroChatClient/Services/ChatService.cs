using System;
using System.Threading.Tasks;
using HeroChatClient.Models;
using HeroChatClient.Services;
using Microsoft.AspNet.SignalR.Client;
using Xamarin.Forms;

[assembly: Dependency(typeof(ChatService))]
namespace HeroChatClient.Services
{
    internal class ChatService : IChatService
    {
        #region Private Fields
        private readonly HubConnection _connection;
        private readonly IHubProxy _proxy;
        private readonly string _roomName = "PrivateRoom";
        #endregion

        public ChatService()
        {
            _connection = new HubConnection("http://xamarin-chat.azurewebsites.net/");
            _proxy = _connection.CreateHubProxy("ChatHub");
        }

        #region IChatServices implementation
        public async void JoinRoomTask()
        {
            await _proxy.Invoke("JoinRoom", _roomName);
        }
        public async Task Connect()
        {
            await _connection.Start();

            _proxy.On("GetMessage", (string name, string text) => OnMessageReceived?.Invoke(this, new ChatMessage
            {
                Name = name,
                Text = text,
                Time = DateTime.Now.ToString()
            }));
        }
        public async Task Send(ChatMessage message)
        {
            await _proxy.Invoke("SendMessage", message.Name, message.Text, _roomName);
        }

        public event EventHandler<ChatMessage> OnMessageReceived;
        #endregion

        public void Disconnect()
        {
            _connection.Stop();
        }
    }
}