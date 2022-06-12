using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellProducts.Impl.UI.ManagerCustomer
{
    public class PageCustomers: INotifyPropertyChanged
    {
        public int IndexPage { get; set; }

        public List<Customer> Customers { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
