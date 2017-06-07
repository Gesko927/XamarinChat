using HeroChatClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HeroChatClient.ViewModels
{
    class MainPageViewModel : BaseViewModel
    {
        private readonly IChatService _chatService; 
        public MainPageViewModel()
        {
            _chatService = new ChatService();
        }

        private Command _signInPressedCommand;
        public Command SignInPressedCommand => _signInPressedCommand ?? (_signInPressedCommand = new Command(ExecuteSignInPressed));

        private void ExecuteSignInPressed(object obj)
        {
            _chatService.Connect();
        }
    }
}
