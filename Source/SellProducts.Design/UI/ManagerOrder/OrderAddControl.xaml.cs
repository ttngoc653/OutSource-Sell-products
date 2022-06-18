using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for OrderAddControl.xaml
    /// </summary>
    public partial class OrderAddControl : UserControl, INotifyPropertyChanged
    {
        Impl.UI.ManagerOrder.Order order = new Impl.UI.ManagerOrder.Order(new Model.ORDER());
        ObservableCollection<Impl.UI.ManagerOrder.Cart> carts = new ObservableCollection<Impl.UI.ManagerOrder.Cart>();

        public event PropertyChangedEventHandler PropertyChanged;

        public OrderAddControl()
        {
            InitializeComponent();
            InitializeOrder();

            this.DataContext = order;
            this.lvCarts.ItemsSource = carts;
        }

        private void InitializeOrder()
        {
            order.Carts = carts;
            order.Comment = "";
            order.CustomerOrder = new Impl.UI.ManagerCustomer.Customer(new Model.CUSTOMER() { phone="", address="", name="" });
            order.CustomerOrder.Name = "";
            order.CustomerOrder.Phone = "";
            order.CustomerOrder.Address = "";
            order.CustomerPhone = "";
            order.DateTimeOrder = DateTime.Now;
            order.Total = 0;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> productnames = Impl.UI.ManagerProduct.ProductInfor.GetAll().Where(p => p.IsHide == false && p.Amount > 0).Select(i => i.Name).ToList();
            cbOrderAddProduct.ItemsSource = productnames;
        }

        private void bAddCart_Click(object sender, RoutedEventArgs e)
        {
            string productSelected = cbOrderAddProduct.SelectedItem.ToString();
            Impl.UI.ManagerProduct.ProductInfor productInfor = Impl.UI.ManagerProduct.ProductInfor.GetAll().Where(i => i.Name == productSelected).FirstOrDefault();
            if (productInfor != null)
                if (productInfor.Amount > 0)
                {
                    Impl.UI.ManagerOrder.Cart cart = carts.Where(i => i.ProductName == productSelected).FirstOrDefault();
                    if (cart != null)
                    {
                        if (productInfor.Amount >= cart.Amount + 1)
                        {
                            cart.Amount++;
                        }
                        else
                        {
                            throw new Exception("Sản phẩm hiện có trong giỏ đã đạt giới hạn nên không thể thêm vào giỏ.");
                        }
                    }
                    else
                    {
                        cart = new Impl.UI.ManagerOrder.Cart(new Model.CART())
                        {
                            ProductCart = productInfor,
                            Amount = 1,
                            Price = productInfor.PriceSale.HasValue ? productInfor.PriceSale.Value : productInfor.Price.HasValue ? productInfor.Price.Value : 0,
                        };
                        carts.Add(cart);
                    }
                }
                else
                {
                    throw new Exception("Sản phẩm hiện đã hết hàng");
                }
            UpdateLayout();
            UpdateTotalOrder();
        }
         
        private void bOrderAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!order.CustomerOrder.ExistAtDatabse)
                order.CustomerOrder.Insert();

            order.Carts = carts;
            order.Insert();

            InitializeOrder();
            UpdateLayout();
        }

        private void nudAmount_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            Impl.UI.ManagerOrder.Cart cartChange = (Impl.UI.ManagerOrder.Cart)lvCarts.SelectedItem;
            Impl.UI.ManagerProduct.ProductInfor productInfor = Impl.UI.ManagerProduct.ProductInfor.GetAll().Where(p => p.Name == cartChange.ProductName).FirstOrDefault();
            if (productInfor.Amount < e.NewValue)
            {
                MessageBox.Show("Số lượng '" + productInfor.Name + "' trong cửa hàng hiện có" + productInfor.Amount + " nên không thể thêm số lượng được nữa."+
                    Environment.NewLine+
                    "Số lượng sản phẩm sẽ trở về trước khi thay đổi.");

                MahApps.Metro.Controls.NumericUpDown numericUpDown = sender as MahApps.Metro.Controls.NumericUpDown;
                numericUpDown.Value = e.OldValue;
            }

            lvCarts.Items.Refresh();
            UpdateTotalOrder();
        }

        private void btnRemoveCart_Click(object sender, RoutedEventArgs e)
        {
            Impl.UI.ManagerOrder.Cart cartRemove = (Impl.UI.ManagerOrder.Cart)lvCarts.SelectedItem;
            carts.Remove(cartRemove);
            UpdateTotalOrder();
            UpdateLayout();
        }

        private void ListViewItem_PreviewGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            ListViewItem listViewItem = (ListViewItem)sender;
            listViewItem.IsSelected = true;
        }

        private void UpdateTotalOrder()
        {
            int number = order.Total;
            tbTotal.Text = number.ToString();
        }
    }
}
