using SellProducts.Model.Demo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
