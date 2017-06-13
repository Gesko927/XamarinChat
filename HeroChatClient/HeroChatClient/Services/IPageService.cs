using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HeroChatClient.Services
{
    interface IPageService
    {
        Task PushModalAsync(Page page);
        Task PopModalAsync();
        void DisplayAlert(string title, string message, string ok);
    }
}
