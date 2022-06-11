using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace SellProducts.Impl.UI.ManagerProduct
{
    public class ProductInfor : INotifyPropertyChanged
    {
        public Model.PRODUCT _product;

        public ProductInfor(Model.PRODUCT product1)
        {
            _product = product1;
        }

        public string Code { get { return _product.code; } set { _product.code = value; } }

        public string Name { get => _product.name; set => _product.name = value; }

        public int Price { get => (int)_product.price; set => _product.price = value; }

        public int PriceSale { get => (int)_product.price_sale; set => _product.price_sale = value; }

        public string Desctibe { get => _product.describe; set => _product.describe = value; }

        public string Detail { get => _product.detail; set => _product.detail = value; }

        public int Amount { get => (int)_product.amount_current; set => _product.amount_current = value; }

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
                _product.manufacturer = _product.MANUFACTURERE.id;
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

        public bool Save() => Common.ConnectDB.Insert.Instance(_product);

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
