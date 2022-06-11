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
        IList<Impl.UI.ManagerProduct.ProductInfor> _productInfors = null;

        public event Notify ListChanged;

        protected virtual void OnListChanged()
        {
            ListChanged?.Invoke();
        }

        public ProductControl(IList<Impl.UI.ManagerProduct.ProductInfor> productInfors)
        {
            InitializeComponent();
            this.dgList.DataContext = productInfors;
        }

        public ProductControl()
        {
            InitializeComponent();
            this.dgList.SelectedCellsChanged += DgList_SelectedCellsChanged;
        }

        private void DgList_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            string a = "sdf";
        }

        public IList<Impl.UI.ManagerProduct.ProductInfor> ProductInfors { 
            get => (IList<Impl.UI.ManagerProduct.ProductInfor>)this.dgList.DataContext;
            set => this.dgList.DataContext = value;
        }
        public IList<ProductInfor> ProductInfors1 { get => _productInfors; set => _productInfors = value; }

        public void ShowAddProduct()
        {
            this.dpAdd.Visibility = Visibility.Visible;
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
            string see = "asfdg";
        }

        private void dpAdd_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.Property.Name == "Visibility"
                && (Visibility)e.NewValue == Visibility.Visible)
            {

            }
        }

        private void dpDetail_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void bMadeInAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbDetailMadeIn_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbDetailManufacturer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbAddManufacturer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbAddMadeIn_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void bAddManufacturerAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void bDetailAddManufacturer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CkDetailIsHide_Changed(object sender, RoutedEventArgs e)
        {

        }

        private void NumericUpDown_TextChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {

        }

        private void tbDetailPrice_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {

        }

        private void tbDetailPriceSale_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {

        }

        private void dgList_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
