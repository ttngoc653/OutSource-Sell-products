using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SellProducts.Design.UI.ManagerCustomer
{
    /// <summary>
    /// Interaction logic for CustomerControl.xaml
    /// </summary>
    public partial class CustomerControl : UserControl
    {
        private Impl.UI.ManagerCustomer.Customer customerAdd = new Impl.UI.ManagerCustomer.Customer(new Model.CUSTOMER());

        #region CustomEvent
        public static readonly RoutedEvent ListCustomerChangedEvent = EventManager.RegisterRoutedEvent(
            "ListCustomerChanged",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(CustomerControl)
            );

        public event RoutedEventHandler ListCustomerChanged
        {
            add { AddHandler(ListCustomerChangedEvent, value); }
            remove { RemoveHandler(ListCustomerChangedEvent, value); }
        }

        void RaiseCustomRoutedEvent()
        {
            RoutedEventArgs routedEventArgs = new RoutedEventArgs(ListCustomerChangedEvent);

            RaiseEvent(routedEventArgs);
        }
        #endregion

        public CustomerControl()
        {
            InitializeComponent();
        }

        public ObservableCollection<Impl.UI.ManagerCustomer.Customer> Customers
        {
            get
            {
                ObservableCollection<Impl.UI.ManagerCustomer.Customer> items = (ObservableCollection<Impl.UI.ManagerCustomer.Customer>)lvList.ItemsSource;
                return items;
            }
            set
            {
                if (value != null)
                {
                    lvList.Items.Clear();

                    foreach (Impl.UI.ManagerCustomer.Customer item in value)
                    {
                        lvList.Items.Add(item);
                    }

                    Visibility = Visibility.Visible;
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            RaiseCustomRoutedEvent();
        }

        private void bAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            customerAdd.Insert();
            customerAdd.Name = "";
            customerAdd.Phone = "";
            customerAdd.Address = "";
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dpAddCustomer.DataContext = customerAdd;
        }

        private void menuSeeOrders_Click(object sender, RoutedEventArgs e)
        {
            Impl.UI.ManagerCustomer.Customer customer = (Impl.UI.ManagerCustomer.Customer)lvList.SelectedItem;
            try
            {
                ObservableCollection<Impl.UI.ManagerOrder.Order> orders = new ObservableCollection<Impl.UI.ManagerOrder.Order>(Impl.UI.ManagerOrder.Order.GetAll().Where(o => o.CustomerPhone == customer.Phone));

                if (orders.Count>0)
                {
                    Grid controlParent = (Grid)this.Parent;

                    foreach (object item in controlParent.Children)
                    {
                        if (item is ManagerOrder.OrderControl)
                        {
                            ManagerOrder.OrderControl orderControl = item as ManagerOrder.OrderControl;
                            orderControl.Visibility = Visibility.Visible;
                            orderControl.Orders = orders;
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Khách hàng này chưa có đơn hàng.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void miRemove_Click(object sender, RoutedEventArgs e)
        {
            Impl.UI.ManagerCustomer.Customer customer = (Impl.UI.ManagerCustomer.Customer)lvList.SelectedItem;
            ObservableCollection<Impl.UI.ManagerOrder.Order> orders = new ObservableCollection<Impl.UI.ManagerOrder.Order>(Impl.UI.ManagerOrder.Order.GetAll().Where(o => o.CustomerPhone == customer.Phone));

            if (orders.Count > 0)
                MessageBox.Show("Khách hàng đã có đơn hàng nên không thể xóa.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                lvList.Items.Remove(customer);
                customer.Remove();
            }
        }
    }
}
