using HeroChatClient.Models;
using System;
using System.Threading.Tasks;

namespace HeroChatClient.Services
{
    interface IChatService
    {
        Task Connect();
        Task Send(ChatMessage message);
        void JoinRoomTask();
        void Disconnect();

        event EventHandler<ChatMessage> OnMessageReceived;
    }
}
