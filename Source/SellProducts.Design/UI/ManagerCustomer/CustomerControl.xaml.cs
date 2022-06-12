using System;
using System.Collections.Generic;
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

        public List<Impl.UI.ManagerCustomer.Customer> Customers
        {
            get => (from Impl.UI.ManagerCustomer.Customer item in lvList.Items
                    select item).ToList(); 
            set
            {
                lvList.Items.Clear();
                foreach (Impl.UI.ManagerCustomer.Customer item in value)
                {
                    lvList.Items.Add(item);
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
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dpAddCustomer.DataContext = customerAdd;
        }
    }
}
