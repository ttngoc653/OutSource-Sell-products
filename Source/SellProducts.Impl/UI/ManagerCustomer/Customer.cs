using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellProducts.Impl.UI.ManagerCustomer
{
    public class Customer : IImpl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        Model.CUSTOMER _customer = null;
        int totalOrder = 0;

        public Customer(Model.CUSTOMER c)
        {
            _customer = c;
        }

        public string Phone { get => _customer?.phone; set { _customer.phone = value; } }

        public string Name { get => _customer?.name; set { _customer.name = value; } }

        public string Address { get => _customer?.address; set { _customer.address = value; } }

        public int OrderTotal
        {
            get
            {
                if (totalOrder != 0)
                {
                    return totalOrder;
                }
                totalOrder = Common.ConnectDB.Get.Orders().Where(p => p.customer == Phone).Count();
                return totalOrder;
            }
            set { totalOrder = value; }
        }

        public static ObservableCollection<Customer> GetAll()
        {
            List<Model.CUSTOMER> cs = Common.ConnectDB.Get.Customers().ToList();

            ObservableCollection<Customer> customers = new ObservableCollection<Customer>();

            foreach (Model.CUSTOMER item in cs)
            {
                customers.Add(new Customer(item));
            }

            return customers;
        }

        public override bool Insert()
        {
            return Common.ConnectDB.Insert.Instance(_customer);
        }

        public override bool Remove()
        {
            return Common.ConnectDB.Delete.Instance(_customer)>0;
        }

        public override bool Update()
        {
            return Common.ConnectDB.Update.Instance(_customer) > 0;
        }
    }
}
