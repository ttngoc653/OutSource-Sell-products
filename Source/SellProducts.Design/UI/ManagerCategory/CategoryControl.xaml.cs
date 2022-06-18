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

namespace SellProducts.Design.UI.ManagerCategory
{
    /// <summary>
    /// Interaction logic for CategoryControl.xaml
    /// </summary>
    public partial class CategoryControl : UserControl
    {
        ObservableCollection<Impl.UI.ManagerCategory.Classify> categories;

        public CategoryControl()
        {
            InitializeComponent();

            this.Loaded += CategoryControl_Loaded;
            this.Unloaded += CategoryControl_Unloaded;
            this.IsVisibleChanged += CategoryControl_IsVisibleChanged;
        }

        private void CategoryControl_Loaded(object sender, RoutedEventArgs e)
        {
            categories = Impl.UI.ManagerCategory.Classify.GetAll();

            tvCategory.Items.Clear();
            foreach (var item in categories)
            {
                tvCategory.Items.Add(item);
            }
        }

        private void CategoryControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            SaveTree();
        }

        private void CategoryControl_Unloaded(object sender, RoutedEventArgs e)
        {
            SaveTree();
        }

        private void SaveTree()
        {

        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in categories)
            {
                item.Update();
            }
        }

        private void checkIn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
