using HeroChatClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HeroChatClient.DBRepository;
using HeroChatClient.Models;
using Xamarin.Forms;

namespace HeroChatClient.ViewModels
{
    class MainPageViewModel : BaseViewModel
    {
        #region Private Fields
        private readonly SQLiteRepository _repository;
        #endregion

        public MainPageViewModel()
        {
            _repository = new SQLiteRepository("Users.db");
        }

        public bool CheckLoginData(LoginData data)
        {
            var user = _repository.GetUserByUsername(data.Username);

            if (user != null)
            {
                if (user.Password == data.Password)
                {
                    return true;
                }
            }
            return false;
        }

        public User GetUser(string username)
        {
            return _repository.GetUserByUsername(username);
        }
    }
}
