using HeroChatClient.DBRepository;
using HeroChatClient.Models;

namespace HeroChatClient.ViewModels
{
    class RegistrationViewModel
    {
        #region Private Fields
        private readonly SQLiteRepository _repository;
        #endregion

        public RegistrationViewModel()
        {
            _repository = new SQLiteRepository("Users.db");
        }

        public bool RegisterNewUser(User newUser)
        {
            return (_repository.SaveOrUpdateUser(newUser) != 0);
        }
    }
}
