using HeroChatClient.DBRepository;

namespace HeroChatClient.Services
{
    public class DataVerificationService
    {
        private readonly SQLiteRepository _repository;

        public DataVerificationService()
        {
            _repository = new SQLiteRepository("Users.db");
        }

        public static bool NullOrEmptyEntryText(params string[] informationStrings)
        {
            foreach (var info in informationStrings)
                if (string.IsNullOrEmpty(info))
                    return false;
            return true;
        }

        public static bool CheckEntryLength(string entryText, int length)
        {
            if (entryText.Length > length)
                return false;
            return true;
        }

        public bool CheckUsernameConstraint(string username)
        {
            var user = _repository.GetUserByUsername(username);
            return user != null;
        }

        public bool CheckEmailAddressConstraint(string email)
        {
            var user = _repository.GetUserByEmail(email);
            return user != null;
        }
    }
}