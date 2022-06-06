using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellProducts.Impl.ViewModel
{
    public class Category: INotifyPropertyChanged
    {
        Model.CATEGORY cat = new Model.CATEGORY();

        public string Name
        {
            get => cat.name;
            set { cat.name = value; }
        }

        public string Parent
        {
            get
            {
                return new Common.ConnectDB.Get().GetParentCategory(cat.name).name;
            }
            set
            {

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
