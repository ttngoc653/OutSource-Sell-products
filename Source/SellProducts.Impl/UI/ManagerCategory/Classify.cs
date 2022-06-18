using SellProducts.Impl.UI.ManagerProduct;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellProducts.Impl.UI.ManagerCategory
{
    public class Classify : IImpl, INotifyPropertyChanged
    {
        Dictionary<string,bool> _productnames = null;
        ManagerProduct.Category _category = null;

        public Classify(Category category)
        {
            _category = category ?? throw new ArgumentNullException(nameof(category));
            if (_category != null)
            {
                _productnames = new Dictionary<string, bool>();

                foreach (ProductInfor item in ProductInfor.GetAll())
                {
                    if (Common.ConnectDB.Get.Classifies().Select(c => c.category == category.Id && c.product == item.Id) == null)
                        _productnames.Add(item.Name, false);
                    else
                        _productnames.Add(item.Name, true);
                }
            }
        }

        public string CategoryName
        {
            get => _category.Name; 
            set
            {
                _category = Category.GetAll().Where(i=>i.Name==value).FirstOrDefault();
            }
        }
        public Dictionary<string, bool> Productnames { get => _productnames; set => _productnames = value; }

        public event PropertyChangedEventHandler PropertyChanged;

        public static ObservableCollection<Classify> GetAll()
        {
            ObservableCollection<Classify> classifies = new ObservableCollection<Classify>();
            foreach (Category item in Category.GetAll())
                classifies.Add(new Classify(item));

            return classifies;
        }

        public override bool Insert()
        {
            foreach (KeyValuePair<string, bool> item in _productnames)
            {
                ManagerProduct.ProductInfor productInfor = ManagerProduct.ProductInfor.GetAll().FirstOrDefault(i => i.Name == item.Key);
                if (productInfor != null)
                    if (item.Value == true &&
                        Common.ConnectDB.Get.Classifies().FirstOrDefault(c => c.category == _category.Id && c.product == productInfor.Id) == null)
                    {
                        Common.ConnectDB.Insert.Instance(new Model.CLASSIFY() { category = _category.Id, product = productInfor.Id });
                    }
            }

            return true;
        }

        public override bool Remove()
        {
            foreach (KeyValuePair<string, bool> item in _productnames)
            {
                ManagerProduct.ProductInfor productInfor = ManagerProduct.ProductInfor.GetAll().Where(i => i.Name == item.Key).FirstOrDefault();
                if (productInfor != null && item.Value == false)
                {
                    Remove(productInfor.Id);
                }
            }
            return true;
        }

        public bool Remove(int idProduct)
        {
            if (Common.ConnectDB.Get.Classifies().Where(c => c.category == _category.Id && c.product == idProduct).FirstOrDefault() != null)
            {
                Common.ConnectDB.Delete.Instance(new Model.CLASSIFY() { category = _category.Id, product = idProduct});
            }
            return true;
        }

        public override bool Update()
        {
            return Insert() && Update();
        }
    }
}
