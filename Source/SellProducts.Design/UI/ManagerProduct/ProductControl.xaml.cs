using SellProducts.Impl.UI.ManagerProduct;
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

namespace SellProducts.Design.UI.ManagerProduct
{
    public delegate void Notify();

    /// <summary>
    /// Interaction logic for ProductControl.xaml
    /// </summary>
    public partial class ProductControl : UserControl
    {
        IList<ProductInfor> _productInfors = null;

        ProductInfor productInfor = new ProductInfor();

        #region CustomEvent
        public static readonly RoutedEvent ListProductChangedEvent = EventManager.RegisterRoutedEvent(
            "ListProductChanged",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(ProductControl)
            );

        public event RoutedEventHandler ListProductChanged
        {
            add { AddHandler(ListProductChangedEvent, value); }
            remove { RemoveHandler(ListProductChangedEvent, value); }
        }

        void RaiseCustomRoutedEvent()
        {
            RoutedEventArgs routedEventArgs = new RoutedEventArgs(ListProductChangedEvent);

            RaiseEvent(routedEventArgs);
        }
        #endregion

        public ProductControl(IList<Impl.UI.ManagerProduct.ProductInfor> productInfors)
        {
            InitializeComponent();
            this.dgList.DataContext = productInfors;
        }

        public ProductControl()
        {
            InitializeComponent();
            this.dgList.SelectionChanged += DgList_SelectionChanged; ;

            this.dpAdd.DataContext = productInfor;
        }

        private void DgList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dpAdd.Visibility = Visibility.Collapsed;
            dpDetail.Visibility = Visibility.Visible;
        }

        private void DgList_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
        }

        public IList<ProductInfor> ProductInfors
        {
            get => (IList<ProductInfor>)this.dgList.DataContext;
            set
            {
                this.dgList.Items.Clear();
                foreach (ProductInfor item in value)
                {
                    this.dgList.Items.Add(item);
                }
                this._productInfors = value;
            }
        }
        
        public void ShowAddProduct()
        {
            this.dpAdd.Visibility = Visibility.Visible;
            this.dpDetail.Visibility = Visibility.Collapsed;
        }

        private void menuSeeDetail_Click(object sender, RoutedEventArgs e)
        {
            string see = "asfdg";
        }

        private void menuDelete_Click(object sender, RoutedEventArgs e)
        {
            string see = "asfdg";
        }

        private void menuUpdateOnlyOnce_Click(object sender, RoutedEventArgs e)
        {
            Impl.UI.ManagerProduct.ProductInfor productInfor = (ProductInfor)dgList.SelectedItem;

            productInfor.Update();
        }

        private void dpAdd_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.Property.Name == "Visibility"
                && (Visibility)e.NewValue == Visibility.Visible)
            {
                dpDetail.Visibility = Visibility.Collapsed;
            }
        }

        private void DpDetail_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.Property.Name == "Visibility"
                && (Visibility)e.NewValue == Visibility.Visible)
            {
                dpAdd.Visibility = Visibility.Collapsed;
            }
        }

        private void cbDetailMadeIn_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RaiseCustomRoutedEvent();
        }

        private void cbDetailManufacturer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            RaiseCustomRoutedEvent();
        }

        private void CkDetailIsHide_Changed(object sender, RoutedEventArgs e)
        {
            RaiseCustomRoutedEvent();
        }

        private void tbDetailPrice_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            RaiseCustomRoutedEvent();
        }

        private void tbDetailPriceSale_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            RaiseCustomRoutedEvent();
        }

        private void cbManufacturer_DropDownOpened(object sender, EventArgs e)
        {
            if (sender is ComboBox)
            {
                ComboBox comboBox = sender as ComboBox;

                List<Manufacturer> manufacturers = Manufacturer.GetAll();

                comboBox.Items.Clear();
                foreach (Manufacturer item in manufacturers)
                {
                    comboBox.Items.Add(item);
                }
            }
        }

        private void cbMadeIn_DropDownOpened(object sender, EventArgs e)
        {
            if (sender is ComboBox)
            {
                ComboBox comboBox = sender as ComboBox;

                List<MadeIn> categories = MadeIn.GetAll();

                comboBox.Items.Clear();
                foreach (MadeIn item in categories)
                {
                    comboBox.Items.Add(item);
                }
            }
        }

        private void bProductAdd_Click(object sender, RoutedEventArgs e)
        {
            productInfor.Insert();
        }

        private void tbDetailAmount_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {

        }

        private void lbDetailCategories_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void lbDetailCategories_Unselected(object sender, RoutedEventArgs e)
        {

        }

        private void lbCategories_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is ListBox)
            {
                ListBox listBox = sender as ListBox;

                List<Category> categories = Category.GetAll();

                listBox.Items.Clear();
                foreach (Category item in categories)
                {
                    listBox.Items.Add(item);
                }
            }
        }

        private void dgList_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
