using HeroChatClient.DBRepository;
using HeroChatClient.Models;

namespace HeroChatClient.ViewModels
{
    class LoginPageViewModel : BaseViewModel
    {
        #region Private Fields
        private readonly SQLiteRepository _repository;
        #endregion

        public LoginPageViewModel()
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
