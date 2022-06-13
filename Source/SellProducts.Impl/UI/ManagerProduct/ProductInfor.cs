using SellProducts.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace SellProducts.Impl.UI.ManagerProduct
{
    public class ProductInfor : IImpl, INotifyPropertyChanged
    {
        public Model.PRODUCT _product = null;
        private Manufacturer _manufacturer = null;
        private MadeIn _madeIn = null;

        public ProductInfor()
        {
            _product = new Model.PRODUCT();
            Price = 0;
            PriceSale = 0;
            Amount = 0;
        }

        private ObservableCollection<Category> _categories = null;

        public ProductInfor(Model.PRODUCT product1)
        {
            _product = product1;
        }

        public int Id { get { return _product.id; } set { _product.id = value; } }
        public string Code { get { return _product.code; } set { _product.code = value; } }

        public string Name { get => _product.name; set => _product.name = value; }

        public int Price { get => (int)_product.price; set => _product.price = value; }

        public int PriceSale { get => (int)_product.price_sale; set => _product.price_sale = value; }

        public string Describe { get => _product.describe; set => _product.describe = value; }

        public string Detail { get => _product.detail; set => _product.detail = value; }

        public int Amount { get => (int)_product.amount_current; set => _product.amount_current = value; }

        public bool IsHide { get => _product.is_hide; set => _product.is_hide = value; }

        public string ManufacturerName
        {
            get
            {
                return ManufacturerProduct?.Name;
            }

            set
            {
                _manufacturer = Manufacturer.GetAll().Where(m => m.Name == value).FirstOrDefault();
                _product.manufacturer = _manufacturer?.Id;
            }
        }

        public Manufacturer ManufacturerProduct
        {
            get
            {
                if (_manufacturer == null)
                {
                    _manufacturer = Manufacturer.GetAll().Where(m => m.Id == _product.manufacturer).FirstOrDefault();
                }
                return _manufacturer;
            }

            set
            {
                _manufacturer = Manufacturer.GetAll().Where(m => m.Name == value?.Name).FirstOrDefault();
                _product.manufacturer = _manufacturer?.Id;
                MadeInName = _manufacturer?.Name;
            }
        }

        public string MadeInName
        {
            get
            {
                if (_product.MADEIN1 == null)
                {
                    _product.MADEIN1 = Common.ConnectDB.Get.Madeins().Where(m => m.id == _product.madein).FirstOrDefault();
                }
                return _product.MADEIN1?.location;
            }

            set
            {
                _product.MADEIN1 = Common.ConnectDB.Get.Madeins().Where(m => m.location == value).FirstOrDefault();
                _product.madein = _product.MADEIN1?.id;
            }
        }

        public MadeIn MadeInProduct
        {
            get
            {
                if (_madeIn == null)
                {
                    _madeIn = MadeIn.GetAll().Where(m => m.Id == _product.madein).FirstOrDefault();
                }
                return _madeIn;
            }

            set
            {
                _madeIn = value;
                _product.madein = value?.Id;
            }
        }

        public ObservableCollection<Category> Categories
        {
            get
            {
                if (_categories==null)
                {
                    IEnumerable<CLASSIFY> cLASSIFies = Common.ConnectDB.Get.Classifies().Where(c => c.product == this._product.id);
                    _categories = new ObservableCollection<Category>();

                    foreach (CLASSIFY item in cLASSIFies)
                    {
                        _categories.Add(new Category(Common.ConnectDB.Get.Categories().Where(c => c.id == item.category).First()));
                    }
                }
                return _categories;
            }
            set => _categories = value;
        }

        public override bool Insert() => Common.ConnectDB.Insert.Instance(_product);

        public static ObservableCollection<ProductInfor> GetAll()
        {
            ObservableCollection<ProductInfor> productInfors = new ObservableCollection<ProductInfor>();

            foreach (Model.PRODUCT item in Common.ConnectDB.Get.Products())
            {
                productInfors.Add(new ProductInfor(item));
            }

            return productInfors;
        }

        public override bool Update()
        {
            return Common.ConnectDB.Update.Instance(_product) > 0;
        }

        public override bool Remove()
        {
            return Common.ConnectDB.Delete.Instance(_product) > 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
