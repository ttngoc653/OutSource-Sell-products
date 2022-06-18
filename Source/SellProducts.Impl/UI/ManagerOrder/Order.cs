using SellProducts.Impl.UI.ManagerProduct;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellProducts.Impl.UI.ManagerOrder
{
    public class Order : IImpl, INotifyPropertyChanged
    {
        public Model.ORDER _order = null;

        private ObservableCollection<Cart> _carts = null;

        private ManagerCustomer.Customer _customer = null;

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
                _customer = ManagerCustomer.Customer.GetAll().Where(i => i.Phone.Trim() == value.Trim()).FirstOrDefault();
                if (_customer == null)
                {
                    _customer = new ManagerCustomer.Customer(new Model.CUSTOMER());
                    _customer.Phone = value;
                }
                _order.customer = value.Trim();
            }
        }

        public string CustomerName
        {
            get
            {
                return _customer?.Name;
            }
            set
            {
                _customer.Name = value.Trim();
            }
        }

        public string CustomerAddress
        {
            get
            {
                return _customer?.Address;
            }
            set
            {
                _customer.Address = value.Trim();
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
                int result = 0;
                if (Carts!=null)
                {
                    foreach (Cart item in _carts)
                    {
                        result += item.Total;
                    }
                }
                if (_order != null)
                {
                    _order.total = result;
                }
                return result;
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
                _order.comment = value.Trim();
            }
        }

        public Impl.UI.ManagerCustomer.Customer CustomerOrder
        {
            get
            {
                return _customer;
            }
            set
            {
                if (value!=null)
                {
                    _customer = value;
                    _order.customer = _customer.Phone;
                }
            }
        }

        public ObservableCollection<Cart> Carts
        {
            get
            {
                if (_carts == null || _carts.Count == 0)
                {
                    _carts = new ObservableCollection<Cart>(Cart.GetAll().Where(i => i.IdOrder == _order.id).ToList());
                }
                return _carts;
            }
            set
            {
                _carts = value;
            }
        }

        public static ObservableCollection<Order> GetAll()
        {
            List<Model.ORDER> cs = Common.ConnectDB.Get.Orders()
                as List<Model.ORDER>;

            ObservableCollection<Order> orders = new ObservableCollection<Order>();
            foreach (var item in cs)
            {
                orders.Add(new Order(item));
            }

            return orders;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override bool Insert()
        {
            _order.time = DateTime.Now;
            
            bool result = Common.ConnectDB.Insert.Instance(_order);
            _order = Common.ConnectDB.Get.Orders().Where(o => o.customer.Trim()==_order.customer.Trim()).LastOrDefault();
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
