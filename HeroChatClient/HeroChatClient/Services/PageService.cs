using System.Threading.Tasks;
using Xamarin.Forms;

namespace HeroChatClient.Services
{
    public class PageService : IPageService
    {
        public async Task PushModalAsync(Page page)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(page);
        }

        public async Task PopModalAsync()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }

        public async void DisplayAlert(string title, string message, string ok)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, ok);
        }
    }
}