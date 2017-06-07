using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HeroChatClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPageMaster : ContentPage
    {
        public ListView ListView;

        public ChatPageMaster()
        {
            InitializeComponent();

            BindingContext = new ChatPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class ChatPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<ChatPageMenuItem> MenuItems { get; set; }

            public ChatPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<ChatPageMenuItem>(new[]
                {
                    new ChatPageMenuItem { Id = 0, Title = "Page 1" },
                    new ChatPageMenuItem { Id = 1, Title = "Page 2" },
                    new ChatPageMenuItem { Id = 2, Title = "Page 3" },
                    new ChatPageMenuItem { Id = 3, Title = "Page 4" },
                    new ChatPageMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}