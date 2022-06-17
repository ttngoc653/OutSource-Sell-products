using SellProducts.Impl.UI.ManagerOrder;
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

namespace SellProducts.Design.UI.ManagerOrder
{
    /// <summary>
    /// Interaction logic for OrderControl.xaml
    /// </summary>
    public partial class OrderControl : UserControl
    {
        private ObservableCollection<Impl.UI.ManagerOrder.Order> _orders = new ObservableCollection<Impl.UI.ManagerOrder.Order>();
        public OrderControl()
        {
            InitializeComponent();
            lvListOrder.ItemsSource = _orders;
        }

        public ObservableCollection<Order> Orders
        {
            get => _orders; 
            set
            {
                _orders.Clear();
                foreach (Order item in value)
                {
                    _orders.Add(item);
                }
            }
        }

        private void bRemoveOrder_Click(object sender, RoutedEventArgs e)
        {
            Order order = lvListOrder.SelectedItem as Order;
            _orders.Remove(order);
            order.Remove();
        }

        private void ListViewItem_PreviewGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            ListViewItem listViewItem = sender as ListViewItem;
            listViewItem.IsSelected = true;
        }
    }
}
