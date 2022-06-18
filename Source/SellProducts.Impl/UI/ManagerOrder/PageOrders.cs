using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellProducts.Impl.UI.ManagerOrder
{
    public class PageOrders : INotifyPropertyChanged
    {
        public string IndexPage { get; set; }

        public ObservableCollection<Order> Orders { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
