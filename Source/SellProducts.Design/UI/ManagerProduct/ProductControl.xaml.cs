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
    /// <summary>
    /// Interaction logic for ProductControl.xaml
    /// </summary>
    public partial class ProductControl : UserControl
    {
        public ProductControl(IList<Impl.UI.ManagerProduct.ProductInfor> productInfors)
        {
            InitializeComponent();
            this.dgList.DataContext = productInfors;
        }

        public ProductControl()
        {
            InitializeComponent();
        }

        public IList<Impl.UI.ManagerProduct.ProductInfor> ProductInfors { 
            get => (IList<Impl.UI.ManagerProduct.ProductInfor>)this.dgList.DataContext;
            set => this.dgList.DataContext = value;
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
    }
}
