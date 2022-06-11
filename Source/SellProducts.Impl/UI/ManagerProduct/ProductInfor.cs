using SellProducts.Model;
using System;
using System.Collections.Generic;
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

        public ProductInfor()
        {
            _product = new Model.PRODUCT();
            Price = 0;
            PriceSale = 0;
            Amount = 0;
        }

        private List<Category> _categories = null;

        public ProductInfor(Model.PRODUCT product1)
        {
            _product = product1;
        }

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
                if (_product.MANUFACTURERE == null)
                {
                    _product.MANUFACTURERE = Common.ConnectDB.Get.Manufactureres().Where(m => m.id == _product.manufacturer).FirstOrDefault();
                }
                return _product.MANUFACTURERE?.name;
            }

            set
            {
                _product.MANUFACTURERE = Common.ConnectDB.Get.Manufactureres().Where(m => m.name == value).FirstOrDefault();
                _product.manufacturer = _product?.MANUFACTURERE.id;
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
                _product.madein = _product.MADEIN1.id;
            }
        }

        public List<Category> Categories
        {
            get
            {
                if (_categories==null)
                {
                    List<CLASSIFY> cLASSIFies = Common.ConnectDB.Get.Classifies().Where(c => c.product == this._product.id).ToList();
                    _categories = new List<Category>();

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

        public static List<ProductInfor> GetAll()
        {
            List<ProductInfor> productInfors = new List<ProductInfor>();

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
