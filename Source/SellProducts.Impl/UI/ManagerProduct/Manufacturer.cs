using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellProducts.Impl.UI.ManagerProduct
{
    public class Manufacturer : IImpl, INotifyPropertyChanged
    {
        Model.MANUFACTURER _m = null;

        List<ProductInfor> _products = null;

        public Manufacturer(Model.MANUFACTURER m)
        {
            _m = m;
        }

        public int Id { get => _m.id; set => _m.id = value; }
        public string Name { get => _m.name; set => _m.name = value; }
        public string Detail { get => _m.detail; set => _m.detail = value; }

        public List<ProductInfor> ProductInfors
        {
            get
            {
                if (_products==null)
                {
                    _m.PRODUCTS = Common.ConnectDB.Get.Products().Where(p => p.manufacturer.HasValue && p.manufacturer.Value == _m.id).ToList();

                    _products = new List<ProductInfor>();
                    foreach (Model.PRODUCT item in _m.PRODUCTS)
                    {
                        _products.Add(new ProductInfor(item));
                    }
                }

                return _products;
            }
            set { this._products = value; }
        }

        public static List<Manufacturer> GetAll()
        {
            return Common.ConnectDB.Get.Manufactureres().Select(item => new Manufacturer(item)).ToList();
        }

        public override bool Insert()
        {
            return Common.ConnectDB.Insert.Instance(_m);
        }

        public override bool Update()
        {
            return Common.ConnectDB.Update.Instance(_m) > 0;
        }

        public override bool Remove()
        {
            return Common.ConnectDB.Delete.Instance(_m) > 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
