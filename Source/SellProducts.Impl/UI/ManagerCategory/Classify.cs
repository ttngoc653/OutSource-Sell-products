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
        ObservableCollection<MyMap> _productnames = null;
        ManagerProduct.Category _category = null;
        ObservableCollection<Classify> _childs = null;

        public Classify(Category category)
        {
            _category = category ?? throw new ArgumentNullException(nameof(category));
            if (_category != null)
            {
                _productnames = new ObservableCollection<MyMap>();

                foreach (ProductInfor item in ProductInfor.GetAll())
                {
                    Model.CLASSIFY classify= Common.ConnectDB.Get.Classifies().FirstOrDefault(c => c.category == category.Id && c.product == item.Id);
                    if (classify== null)
                        _productnames.Add(new MyMap() {Productname=item.Name, Checked=false });
                    else
                        _productnames.Add(new MyMap() { Productname = item.Name, Checked = false });
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
        public ObservableCollection<MyMap> Productnames { get => _productnames; set => _productnames = value; }
        public ObservableCollection<Classify> Childs
        {
            get
            {
                if (_childs==null)
                {
                    _childs = new ObservableCollection<Classify>();

                    List<Category> categories = Category.GetAll().Where(c => c.Parent?.Id == _category.Id).ToList();
                    foreach (var item in categories)
                    {
                        _childs.Add(new Classify(item));
                    }
                }
                return _childs;
            }
            set
            {
                _childs = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static ObservableCollection<Classify> GetAll()
        {
            ObservableCollection<Classify> classifies = new ObservableCollection<Classify>();
            foreach (Category item in Category.GetAll().Where(c => c.Parent == null))
                classifies.Add(new Classify(item));

            return classifies;
        }

        public override bool Insert()
        {
            foreach (MyMap item in _productnames)
            {
                ManagerProduct.ProductInfor productInfor = ManagerProduct.ProductInfor.GetAll().FirstOrDefault(i => i.Name == item.Productname);
                if (productInfor != null)
                    if (item.Checked == true &&
                        Common.ConnectDB.Get.Classifies().FirstOrDefault(c => c.category == _category.Id && c.product == productInfor.Id) == null)
                    {
                        Common.ConnectDB.Insert.Instance(new Model.CLASSIFY() { category = _category.Id, product = productInfor.Id });
                    }
            }

            return true;
        }

        public override bool Remove()
        {
            foreach (MyMap item in _productnames)
            {
                ManagerProduct.ProductInfor productInfor = ManagerProduct.ProductInfor.GetAll().Where(i => i.Name == item.Productname).FirstOrDefault();
                if (productInfor != null && item.Checked == false)
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

    public class MyMap : INotifyPropertyChanged
    {
        public string Productname { get; set; }
        public bool Checked { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
