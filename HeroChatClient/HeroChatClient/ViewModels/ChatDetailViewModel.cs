using HeroChatClient.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using HeroChatClient.Services;
using Xamarin.Forms;

namespace HeroChatClient.ViewModels
{
    class ChatDetailViewModel : BaseViewModel
    {
        private IChatService _chatService;
        private string _username;
        private string _roomName = "PrivateRoom";
        public ICommand SendMessageCommmand { get; private set; }
        public ICommand SelectMessageListCommand { get; private set; }
        public ICommand DeleteMessageCommand { get; private set; }

        public ObservableCollection<ChatMessage> Messages { get; set; }

        private ChatMessage _selectedMessage;
        public ChatMessage SelectedMessage
        {
            get => _selectedMessage;
            set => SetValue(ref _selectedMessage, value);
        }

        public ChatDetailViewModel(string username)
        {
            #region Command Initialization

            SendMessageCommmand = new Command<string>(text => ExecuteSendMessageCommand(text));
            SelectMessageListCommand = new Command<ChatMessage>(message => ExecuteSelectMessageListCommand(message));
            DeleteMessageCommand = new Command<ChatMessage>(message => ExecuteDeleteMessageCommand(message));

            #endregion

            _selectedMessage = new ChatMessage();
            Messages = new ObservableCollection<ChatMessage>();
            _username = username;

            _chatService = DependencyService.Get<IChatService>();
            _chatService.Connect();
            _chatService.OnMessageReceived += _chatService_OnMessageReceived;
            _chatService.JoinRoomTask(_roomName);
        }

        private void _chatService_OnMessageReceived(object sender, ChatMessage e)
        {
            Messages.Add(new ChatMessage { Name = e.Name, Text = e.Text, Time = DateTime.Now.ToString() });
        }

        #region Delete Message Command
        private void ExecuteDeleteMessageCommand(ChatMessage message)
        {
            Messages.Remove(message);
        }

        #endregion

        #region Send Button Command
        private void ExecuteSendMessageCommand(string message)
        {
            _chatService.Send(new ChatMessage { Name = "User", Text = message, Time = DateTime.Now.ToString() },_roomName);

            Messages.Add(new ChatMessage { Name = "User", Text = message, Time = DateTime.Now.ToString() });
        }
        #endregion

        #region SelectMessageList Command
        public void ExecuteSelectMessageListCommand(ChatMessage message)
        {
            if (message == null)
                return;

            SelectedMessage = null;
        }

        #endregion
    }
}
