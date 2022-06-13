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

namespace SellProducts.Design.UI.ManagerProduct
{
    /// <summary>
    /// Interaction logic for CategoryManufacturerMadeInControl.xaml
    /// </summary>
    public partial class CategoryManufacturerMadeInControl : UserControl
    {
        public CategoryManufacturerMadeInControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Impl.UI.ManagerProduct.Category> categories = new ObservableCollection<Impl.UI.ManagerProduct.Category>(Impl.UI.ManagerProduct.Category.GetAll().Where(p => p.Parent == null));

            tvCategory.Items.Clear();
            foreach (Impl.UI.ManagerProduct.Category item in categories)
            {
                tvCategory.Items.Add(item);
            }

            /// ItemTemplate="{StaticResource ViewTreeTemplate}"
            /// ItemsSource = "{Binding JointTree}" />
            ///

                lvMadeIn.Items.Clear();
            foreach (Impl.UI.ManagerProduct.MadeIn item in Impl.UI.ManagerProduct.MadeIn.GetAll())
            {
                lvMadeIn.Items.Add(item);
            }

            lvManufactory.Items.Clear();
            foreach (Impl.UI.ManagerProduct.Manufacturer item in Impl.UI.ManagerProduct.Manufacturer.GetAll())
            {
                lvManufactory.Items.Add(item);
            }
        }

        private void bAddCat_Click(object sender, RoutedEventArgs e)
        {
            Impl.UI.ManagerProduct.Category category = new Impl.UI.ManagerProduct.Category(new Model.CATEGORY() { name = tbCategoreAdd.Text });
            category.Insert();

            UserControl_Loaded(null, null);
        }

        private void bAddManufacturer_Click(object sender, RoutedEventArgs e)
        {
            Impl.UI.ManagerProduct.Manufacturer manufacturer = new Impl.UI.ManagerProduct.Manufacturer(new Model.MANUFACTURER() { name = tbManufacturerAdd.Text });
            manufacturer.Insert();

            UserControl_Loaded(null, null);
        }

        private void bAddMadeIn_Click(object sender, RoutedEventArgs e)
        {
            Impl.UI.ManagerProduct.MadeIn madeIn = new Impl.UI.ManagerProduct.MadeIn(new Model.MADEIN() { location = tbMadeInAdd.Text });
            madeIn.Insert();

            UserControl_Loaded(null, null);
        }

        private void mtDeleteMadeIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Impl.UI.ManagerProduct.MadeIn madeIn = (Impl.UI.ManagerProduct.MadeIn)lvMadeIn.SelectedItem;

                if (!madeIn.Remove())
                {
                    throw new Exception();
                }

                UserControl_Loaded(null, null);
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa không thành công do đã có sản phẩm thuộc nơi sản xuất này.");
            }
        }

        private void mtDeletemanufacturer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Impl.UI.ManagerProduct.Manufacturer manufacturer = (Impl.UI.ManagerProduct.Manufacturer)lvManufactory.SelectedItem;

                if (!manufacturer.Remove())
                {
                    throw new Exception();
                }

                UserControl_Loaded(null, null);
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa không thành công do đã có nhà sản xuất này đã có sản phẩm.");
            }
        }

        private void mtDeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                UserControl_Loaded(null, null);
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa không thành công do đã có sản phẩm thuộc nhóm này hoặc có nhóm con.");
            }
        }
    }
}
