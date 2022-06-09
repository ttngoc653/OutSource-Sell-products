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

namespace SellProducts.Design.UI
{
    /// <summary>
    /// Interaction logic for DashboardControl.xaml
    /// </summary>
    public partial class DashboardControl : UserControl
    {
        Impl.UI.DashboardInfo dashboardInfo = null;

        public DashboardControl()
        {
            InitializeComponent();
            this.Loaded += DashboardControl_Loaded;
        }

        private void DashboardControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dashboardInfo = new Impl.UI.DashboardInfo();

            this.DataContext = dashboardInfo;
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue && e.Property.Name.Equals("IsVisible"))
            {
                LoadData();
            }
        }
    }
}
