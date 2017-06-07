using HeroChatClient.Models;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroChatClient.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(ChatService))]
namespace HeroChatClient.Services
{
    class ChatService : IChatService
    {
        private readonly HubConnection _connection;
        private readonly IHubProxy _proxy;

        public event EventHandler<ChatMessage> OnMessageReceived;

        public ChatService()
        {
            _connection = new HubConnection("http://xamarin-chat.azurewebsites.net/");
            _proxy = _connection.CreateHubProxy("ChatHub");
        }

        #region IChatServices implementation

        public async Task JoinRoomTask(string roomName)
        {
            await _proxy.Invoke("JoinRoom", roomName);
        }

        public async Task Connect()
        {
            await _connection.Start();

            _proxy.On("GetMessage", (string name, string text) =>
            {
                OnMessageReceived?.Invoke(this, new ChatMessage
                {
                    Text = text,
                    Name = name,
                    Time = DateTime.Now.ToString()
                });
            });
        }

        public async Task Send(ChatMessage message, string roomName)
        {
            await _proxy.Invoke("SendMessage", message.Name, message.Text, roomName);
        }

        #endregion
    }
}
