using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellProducts.Impl.UI.ManagerOrder
{
   public class Cart : IImpl, INotifyPropertyChanged
    {
        Model.CART _cart = null;
        Order _order = null;
        ManagerProduct.ProductInfor _productInfor = null;
        public Cart(Model.CART c)
        {
            _cart = c;
        }

        public int IdOrder
        {
            get { return _cart.idorder; }
            set
            {
                if (_cart == null)
                {
                    _cart = new Model.CART();
                    _cart.ORDER1 = Common.ConnectDB.Get.Orders().Where(i => i.id == value).First();
                    _order = new Order(_cart.ORDER1);
                }
                _cart.idorder = value;
            }
        }

        public Order OrderCart
        {
            get
            {
                return _order;
            }
            set
            {
                _order = value;
                _cart.idorder = value.Id;
            }
        }

        public ManagerProduct.ProductInfor ProductCart
        {
            get
            {
                if (_productInfor==null)
                {
                    _productInfor = ManagerProduct.ProductInfor.GetAll().Where(p => p.Id == _cart.idproduct).FirstOrDefault();
                }

                return _productInfor;
            }
            set
            {
                _productInfor = value;
                _cart.idproduct = value.Id;
            }
        }

        public int Amount
        {
            get
            {
                return (int)(_cart?.amount);
            }
            set
            {
                _cart.amount = value;
            }
        }

        public int Price
        {
            get
            {
                return _cart.price;
            }
            set
            {
                _cart.price = value;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public override bool Insert()
        {
            return Common.ConnectDB.Insert.Instance(_cart);
        }

        public override bool Remove()
        {
            return Common.ConnectDB.Delete.Instance(_cart)>0;
        }

        public override bool Update()
        {
            return Common.ConnectDB.Update.Instance(_cart) > 0;
        }

        public static List<Cart> GetAll()
        {
            List<Model.CART> cs = (List<Model.CART>)Common.ConnectDB.Get.Carts();

            List<Cart> carts = new List<Cart>();
            foreach (var item in cs)
            {
                carts.Add(new Cart(item));
            }

            return carts;
        }
    }
}
