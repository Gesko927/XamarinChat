using HeroChatClient.Models;
using System;
using System.Threading.Tasks;

namespace HeroChatClient.Services
{
    interface IChatService
    {
        Task Connect();
        Task Send(ChatMessage message, string roomName);
        Task JoinRoomTask(string roomName);

        event EventHandler<ChatMessage> OnMessageReceived;
    }
}
