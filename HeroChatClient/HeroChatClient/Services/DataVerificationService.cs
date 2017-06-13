using System.Linq;
using HeroChatClient.DBRepository;

namespace HeroChatClient.Services
{
    public class DataVerificationService
    {
        public static bool NullOrEmptyEntryText(params string[] informationStrings)
        {
            return informationStrings.All(info => !string.IsNullOrEmpty(info));
        }

        public static bool CheckEntryLength(string entryText, int length)
        {
            return entryText.Length <= length;
        }
    }
}