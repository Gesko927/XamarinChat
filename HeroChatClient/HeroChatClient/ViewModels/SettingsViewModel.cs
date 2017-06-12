using HeroChatClient.DBRepository;
using HeroChatClient.Models;

namespace HeroChatClient.ViewModels
{
    public class SettingsViewModel
    {
        #region Private Fields
        private readonly SQLiteRepository _repository;
        #endregion

        #region Public Properties
        public User User { get; }
        #endregion

        public SettingsViewModel(User user)
        {
            User = user;
            _repository = new SQLiteRepository("Users.db");
        }

        public bool UpdateUser(User user)
        {
            return (_repository.SaveOrUpdateUser(user) != 0);
        }

    }
}