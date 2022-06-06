using SellProducts.Model;
using System.ComponentModel;

namespace SellProducts.Impl.ViewModel
{
    public class Login : INotifyPropertyChanged
    {
        private MANAGER manager=new MANAGER();

        public string UserName
        {
            get => manager.account;
            set { manager.account = value; }
        }

        public string Password
        {
            get => manager.password;
            set { manager.password = value; }
        }

        public bool Remember
        {
            get; set;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
