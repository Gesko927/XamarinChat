using System;
using System.Diagnostics;
using System.Threading.Tasks;
using HeroChatClient.DBRepository;
using HeroChatClient.Models;
using HeroChatClient.Services;

namespace HeroChatClient.ViewModels
{
    class UserDataViewModel
    {
        #region Private Fields
        private readonly SQLiteRepository _repository;
        private readonly IPageService _pageService;
        #endregion

        #region Public Properties
        public User User { get; }

        #endregion

        public UserDataViewModel(IPageService pageService, User user = null)
        {
            _repository = new SQLiteRepository("Users.db");
            _pageService = pageService;
            User = user;
        }

        public bool RegisterOrUpdateUser(User newUser)
        {
            return (_repository.SaveOrUpdateUser(newUser) != 0);
        }

        public bool NullOrEmptyEntryText(params string[] infoStrings)
        {
            if (DataVerificationService.NullOrEmptyEntryText(infoStrings)) return true;
            _pageService.DisplayAlert("Missing information!", "Pleasy, ensure that you give all necessary information" +
                                                                    "(username, password, email, country, age)", "OK");
            return false;
        }

        public bool CheckEntryLength(string entryText, int length)
        {
            if (DataVerificationService.CheckEntryLength(entryText, length)) return true;
            _pageService.DisplayAlert("Invalid length!", $"Length should be less or equal than { length } symbols", "OK");
            return false;
        }

        public bool CheckUsername(string username, int length)
        {
            if (CheckEntryLength(username, length))
            {
                var user = _repository.GetUserByUsername(username);
                return user == null;
            }
            _pageService.DisplayAlert("Invalid username data!", $"Please, check username data. Length should be less than {length}", "OK");
            return false;
        }

        public bool CheckEmailAddress(string email, int length)
        {
            if (CheckEntryLength(email, length))
            {
                var user = _repository.GetUserByEmail(email);
                return user == null;
            }
            _pageService.DisplayAlert("Invalid email address!", $"Please, check email address. Length should be less than {length}", "OK");
            return false;
            
        }
    }
}
