using HeroChatClient.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using HeroChatClient.Services;
using Xamarin.Forms;

namespace HeroChatClient.ViewModels
{
    class HeroChatViewModel : BaseViewModel
    {
        #region Private Fields
        private readonly IChatService _chatService;
        private ChatMessage _selectedMessage;
        #endregion

        #region Public Properties
        public ObservableCollection<ChatMessage> Messages { get; set; }
        public User User { get; }
        public ChatMessage SelectedMessage
        {
            get => _selectedMessage;
            set => SetValue(ref _selectedMessage, value);
        }
        #endregion

        #region Commands
        public ICommand SendMessageCommmand { get; }
        public ICommand SelectMessageListCommand { get; }
        public ICommand DeleteMessageCommand { get; }
        public ICommand JoinRoomCommand { get; }
        public ICommand DisconnectCommand { get; }
        #endregion

        public HeroChatViewModel(User user)
        {
            #region Command Initialization
            SendMessageCommmand = new Command<string>(text => ExecuteSendMessageCommand(text));
            SelectMessageListCommand = new Command<ChatMessage>(message => ExecuteSelectMessageListCommand(message));
            DeleteMessageCommand = new Command<ChatMessage>(message => ExecuteDeleteMessageCommand(message));
            JoinRoomCommand = new Command(ExecuteJoinRoomMessage);
            DisconnectCommand = new Command(ExecuteDisconnectCommand);
            #endregion

            User = user;
            Messages = new ObservableCollection<ChatMessage>();

            _selectedMessage = new ChatMessage();

            _chatService = DependencyService.Get<IChatService>();
            _chatService.Connect();
            _chatService.OnMessageReceived += _chatService_OnMessageReceived;
        }
        private void _chatService_OnMessageReceived(object sender, ChatMessage e)
        {
            Messages.Add(new ChatMessage { Name = e.Name, Text = e.Text, Time = DateTime.Now.ToString() });
        }

        #region Join Room Command
        private void ExecuteJoinRoomMessage()
        {
            _chatService.JoinRoomTask();
        }
        #endregion  

        #region Delete Message Command
        private void ExecuteDeleteMessageCommand(ChatMessage message)
        {
            Messages.Remove(message);
        }
        #endregion

        #region Send Button Command
        private void ExecuteSendMessageCommand(string message)
        {
            _chatService.Send(new ChatMessage { Name = User.Username, Text = message, Time = DateTime.Now.ToString() });
        }
        #endregion

        #region Disconnect Command
        private void ExecuteDisconnectCommand()
        {
            _chatService.Disconnect();
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
