using SellProducts.Impl.UI.ManagerProduct;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellProducts.Impl.UI.ManagerOrder
{
    public class Order : IImpl, INotifyPropertyChanged
    {
        public Model.ORDER _order = null;

        private List<Cart> _carts = null;

        public Order(Model.ORDER o)
        {
            _order = o;
        }
        
        public string CustomerPhone
        {
            get
            {
                return _order?.customer;
            }
            set
            {
                if (_order==null)
                {
                    _order = new Model.ORDER();
                }
                _customer = ManagerCustomer.Customer.GetAll().Where(i => i.Phone == value).First();
                _order.customer = value;
            }
        }

        public int Id
        {
            get
            {
                return _order.id;
            }
            set
            {
                _order.id = value;
            }
        }

        public DateTime DateTimeOrder
        {
            get
            {
                return (DateTime)(_order?.time);
            }
            set
            {
                if (_order==null)
                {
                    _order = new Model.ORDER();
                }

                _order.time = value;
            }
        }

        public int Total
        {
            get
            {
                return (int)(_order?.total);
            }
            set
            {
                if (_order == null)
                {
                    _order = new Model.ORDER();
                }

                _order.total = value;
            }
        }

        public string Comment
        {
            get
            {
                return _order?.comment;
            }
            set
            {
                if (_order==null)
                {
                    _order = new Model.ORDER();
                }
                _order.comment = value;
            }
        }

        private ManagerCustomer.Customer _customer = null;

        public Impl.UI.ManagerCustomer.Customer CustomerOrder
        {
            get
            {
                return _customer;
            }
            set
            {
                _customer = value;
                _order.customer = _customer.Phone;
            }
        }

        private List<ManagerProduct.ProductInfor> _productInfors = null;

        public List<ProductInfor> ProductInfors
        {
            get
            {
                return _productInfors;
            }
            set
            {
                _productInfors = value;
            }
        }

        public List<Cart> Carts
        {
            get
            {
                if (_carts == null || _carts.Count == 0)
                {
                    _carts = Cart.GetAll().Where(i => i.IdOrder == _order.id).ToList();
                }
                return _carts;
            }
            set
            {
                _carts = value;
            }
        }

        public static List<Order> GetAll()
        {
            List<Model.ORDER> cs = (List<Model.ORDER>)Common.ConnectDB.Get.Orders();

            List<Order> orders = new List<Order>();
            foreach (var item in cs)
            {
                orders.Add(new Order(item));
            }

            return orders;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override bool Insert()
        {
            bool result = Common.ConnectDB.Insert.Instance(_order);
            foreach (Cart item in _carts)
            {
                item.IdOrder = _order.id;
                item.Insert();
            }

            return result;
        }

        public override bool Remove()
        {
            foreach (var item in _carts)
            {
                item.Remove();
            }

            return Common.ConnectDB.Delete.Instance(_order) > 0;
        }

        public override bool Update()
        {
            foreach (var item in _carts)
            {
                item.Update();
            }

            return Common.ConnectDB.Update.Instance(_order) > 0;
        }
    }
}
