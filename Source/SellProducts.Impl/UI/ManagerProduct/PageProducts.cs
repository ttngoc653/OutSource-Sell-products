using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellProducts.Impl.UI.ManagerProduct
{
    public class PageProducts : INotifyPropertyChanged
    {
        public int IndexPage { get; set; }

        public ObservableCollection<ProductInfor> Products { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
