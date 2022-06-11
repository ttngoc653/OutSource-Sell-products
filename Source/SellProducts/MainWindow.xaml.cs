using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.VisualBasic;
using Microsoft.Win32;

namespace SellProducts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        private Impl.ViewModel.Login inforLogin;

        private uint numberItemPerPage = uint.MaxValue;

        public MainWindow()
        {
            InitializeComponent();

            try
            {
                string[] arg = Environment.GetCommandLineArgs();
                if (arg.Length > 1)
                {
                    Common.ConnectDB.General.ConnectDB.SetConnectString(arg[1]);
                }
                this.rbMenu.SelectionChanged += RbMenu_SelectionChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public int GetNumberItemPerPage()
        {
            try
            {
                return int.Parse(Common.ConnectDB.Get.Settings()
                                                                 .FirstOrDefault(p => p.account == inforLogin.UserName && p.name == SellProduct_CONSTANT.SETTING_PAGING).value);
            }
            catch (Exception)
            {
            }
            return 5;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.rbMenu.IsMinimized = true;
            this.rbMenu.SelectedIndex = -1;

            try
            {

                bool result = false;
                while (true)
                {
                    result = SellProducts.Common.ConnectDB.General.ConnectDB.CheckConnect();

                    if (result)
                    {
                        break;
                    }

                    string connectionStrNew = Interaction.InputBox(Properties.Resources.ChangeConnectionStringDialog, Properties.Resources.QuestionDialog);
                }

                LoginWindow window = new LoginWindow();
                bool? resultLogin = window.ShowDialog();
                if (resultLogin == true)
                {
                    inforLogin = window.Getlogin();
                }
                else
                {
                    Application.Current.Shutdown();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuGoHome_Click(object sender, RoutedEventArgs e)
        {
            this.ucDashboard.Visibility = Visibility.Visible;
        }

        private void MenuBackuUpDatabase_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuRestoreDatabase_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtCustomerFind_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void btnProductImportCategory_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn file excel:";
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";

            if (openFileDialog.ShowDialog().Value)
            {
                List<Model.CATEGORY> cs = new Common.Imports.Excel(openFileDialog.FileName).GetCategories();

                int numberAdded = 0;
                foreach (Model.CATEGORY item in cs)
                {
                    if (new Impl.UI.ManagerProduct.Category(item).Insert())
                        numberAdded++;
                }


                MessageBox.Show(string.Format("Đã thêm {0} sản phẩm", numberAdded));
            }
        }

        private void btnProductImportProducts_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn file excel:";
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";

            if (openFileDialog.ShowDialog().Value)
            {
                List<Model.PRODUCT> cs = new Common.Imports.Excel(openFileDialog.FileName).GetProducts();

                int numberAdded = 0;
                foreach (Model.PRODUCT item in cs)
                {
                    if (new Impl.UI.ManagerProduct.ProductInfor(item).Insert())
                        numberAdded++;
                }


                MessageBox.Show(string.Format("Đã thêm {0} sản phẩm", numberAdded));
            }
        }

        private void btnProductCategoryAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnProductCategorySee_Click(object sender, RoutedEventArgs e)
        {
            ucCMM.Visibility = Visibility.Visible;
        }

        private void btnProductProductAdd_Click(object sender, RoutedEventArgs e)
        {
            ucProduct.Visibility = Visibility.Visible;
            ucProduct.ShowAddProduct();
        }

        private void btnProductProductUpdate_Click(object sender, RoutedEventArgs e)
        {
            List<Impl.UI.ManagerProduct.ProductInfor> productInfors = ((Impl.UI.ManagerProduct.PageProducts)cbbProductCategoryPage.SelectedItem).Products;

            foreach (Impl.UI.ManagerProduct.ProductInfor item in productInfors)
            {
                item.Update();
            }

            FilterAndGenPageProduct(Impl.UI.ManagerProduct.ProductInfor.GetAll());
        }

        private void txtProductFindName_TextChanged(object sender, TextChangedEventArgs e)
        {
            ucProduct.Visibility = Visibility.Visible;
            FilterAndGenPageProduct(Impl.UI.ManagerProduct.ProductInfor.GetAll());
        }

        private void rsProductFindLimitPrice_IsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ucProduct.Visibility = Visibility.Visible;
            FilterAndGenPageProduct(Impl.UI.ManagerProduct.ProductInfor.GetAll());
        }

        private void btnOrderActAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnOrderActDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnOrderActUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnOrderSee_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dpOrderFindStart_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dpOrderFindEnd_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnOrderFind_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbbCustomerPage_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void btnCustomerSeeList_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCustomerAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCustomerUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnReportSale_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnReportProducts_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbSettingSave_Click(object sender, RoutedEventArgs e)
        {
            /// save setting auto login
            try
            {
                Util.SaveSettings(new Model.SETTING()
                {
                    account = inforLogin.UserName,
                    name = SellProduct_CONSTANT.SETTING_AUTO_LOGIN,
                    value = cbSettingAutoLogin.IsChecked.ToString()
                });
            }
            catch (Exception) { }

            /// load setting save user name
            try
            {
                Util.SaveSettings(new Model.SETTING()
                {
                    account = inforLogin.UserName,
                    name = SellProduct_CONSTANT.SETTING_REMEMBER_NAME,
                    value = cbSettingSaveLogin.IsChecked.ToString()
                });
                cbSettingSaveLogin.IsChecked = bool.Parse(Common.ConnectDB.Get.Settings().FirstOrDefault(p => p.account == inforLogin.UserName && p.name == SellProduct_CONSTANT.SETTING_REMEMBER_NAME).value);
            }
            catch (Exception) { }

            /// load setting paging
            try
            {
                if (tbSettingItemPerPage.Background != Brushes.Red)
                {
                    Util.SaveSettings(new Model.SETTING()
                    {
                        account = inforLogin.UserName,
                        name = SellProduct_CONSTANT.SETTING_PAGING,
                        value = tbSettingItemPerPage.Value.ToString()
                    });
                }
                else
                {
                    MessageBox.Show("Số lượng phần từ trong 1 trang không hợp lệ. Vui lòng kiểm tra lại");
                    tbSettingItemPerPage.Value = tbSettingItemPerPage.Value;
                    tbSettingItemPerPage.Focus();
                }
            }
            catch (Exception) { }

            /// load setting open screen last
            try
            {
                Util.SaveSettings(new Model.SETTING()
                {
                    account = inforLogin.UserName,
                    name = SellProduct_CONSTANT.SETTING_SAVE_FUNCTION_LAST,
                    value = cbSettingOpenLastControl.IsChecked.ToString()
                });
            }
            catch (Exception) { }

            if (cbSettingSaveLogin.IsChecked==true)
            {
                Properties.Settings.Default.user = inforLogin.UserName;
            }
            if (cbSettingAutoLogin.IsChecked==true)
            {
                Properties.Settings.Default.pass = inforLogin.Password;
                Properties.Settings.Default.remember = cbSettingAutoLogin.IsEnabled;
            }

            Properties.Settings.Default.Save();
        }

        private void RbMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count>0 && e.AddedItems[0] is RibbonTab)
            {
                RibbonTab tab = e.AddedItems[0] as RibbonTab;
                if (tab == rtCustomer)
                {
                    LoadTabCustomer();
                }
                else if (tab == rtOrder)
                {

                }
                else if (tab == rtProduct)
                {
                    LoadTabProduct();
                }
                else if (tab == rtPromotion)
                {

                }
                else if (tab == rtReport)
                {

                }
                else if (tab == rtSettings)
                {
                    LoadTabSettings();
                }
                else
                {
                    MessageBox.Show("Nhóm chức năng không có.");
                }
            }
        }

        private void LoadTabProduct()
        {
            IList<Impl.UI.ManagerProduct.ProductInfor> ps = Impl.UI.ManagerProduct.ProductInfor.GetAll();
            int? maxPriceSale = ps.OrderByDescending(p => p.Price).FirstOrDefault()?.PriceSale;
            int? minPriceSale = ps.OrderBy(p => p.Price).FirstOrDefault()?.PriceSale;

            int? maxPrice = ps.OrderByDescending(p => p.Price).FirstOrDefault()?.Price;
            int? minPrice = ps.OrderBy(p => p.Price).FirstOrDefault()?.Price;

            rsProductFindLimitPrice.Maximum = Math.Max(maxPrice.Value, maxPriceSale.Value) * 1.25;
            rsProductFindLimitPrice.Minimum = rsProductFindLimitPrice.Maximum * (-0.01);

            rsProductFindLimitPrice.LowerValue = 0;
            rsProductFindLimitPrice.UpperValue = rsProductFindLimitPrice.Maximum;

            FilterAndGenPageProduct(ps);
        }

        List<Impl.UI.ManagerProduct.PageProducts> pageProductInfor = new List<Impl.UI.ManagerProduct.PageProducts>();
        private void FilterAndGenPageProduct(IList<Impl.UI.ManagerProduct.ProductInfor> products)
        {
            IList<Impl.UI.ManagerProduct.ProductInfor> psFilter = products.Where(p => p.Name.Contains(txtProductFindName.Text)).ToList();

            psFilter = psFilter.Where(p => (rsProductFindLimitPrice.LowerValue <= p.Price && p.Price <= rsProductFindLimitPrice.UpperValue) ||
                 (rsProductFindLimitPrice.LowerValue <= p.PriceSale && p.PriceSale <= rsProductFindLimitPrice.UpperValue)).ToList();

            if (cbbProductCategoryName.SelectedItem != null && !string.IsNullOrEmpty(cbbProductCategoryName.Text))
            {
                int idCategorySeleted = ((Impl.UI.ManagerProduct.Category)cbbProductCategoryName.SelectedItem).Id;
                psFilter = psFilter.Where(p => p.Categories.Where(c => c.Id == idCategorySeleted).Count() > 0).ToList();
            }

            pageProductInfor.Clear();
            
            for (int i = 0; i < products.Count; i++)
            {
                if (i % GetNumberItemPerPage() == 0)
                {
                    Impl.UI.ManagerProduct.PageProducts pageProducts = new Impl.UI.ManagerProduct.PageProducts()
                    {
                        IndexPage = pageProductInfor.Count + 1,
                        Products = new List<Impl.UI.ManagerProduct.ProductInfor>() { products.ElementAt(i) }
                    };

                    pageProductInfor.Add(pageProducts);
                }
                else
                {
                    pageProductInfor.Last().Products.Add(products.ElementAt(i));
                }
            }

            cbbProductCategoryPage.ItemsSource = pageProductInfor;
        }

        private void LoadTabSettings()
        {
            /// load setting auto login
            try
            {
                cbSettingAutoLogin.IsChecked = bool.Parse(Common.ConnectDB.Get.Settings().FirstOrDefault(p => p.account == inforLogin.UserName && p.name == SellProduct_CONSTANT.SETTING_AUTO_LOGIN).value);
            }
            catch (Exception) { }

            /// load setting save user name
            try
            {
                cbSettingSaveLogin.IsChecked = bool.Parse(Common.ConnectDB.Get.Settings().FirstOrDefault(p => p.account == inforLogin.UserName && p.name == SellProduct_CONSTANT.SETTING_REMEMBER_NAME).value);
            }
            catch (Exception) { }

            /// load setting paging
            try
            {
                tbSettingItemPerPage.Value = int.Parse(Common.ConnectDB.Get.Settings()
                                                                 .FirstOrDefault(p => p.account == inforLogin.UserName && p.name == SellProduct_CONSTANT.SETTING_PAGING).value);
            }
            catch (Exception) {
                tbSettingItemPerPage.Value = 5;
            }
            numberItemPerPage = (uint)tbSettingItemPerPage.Value;

            /// load setting open screen last
            try
            {
                cbSettingOpenLastControl.IsChecked = bool.Parse(Common.ConnectDB.Get.Settings().FirstOrDefault(p => p.account == inforLogin.UserName && p.name == SellProduct_CONSTANT.SETTING_SAVE_FUNCTION_LAST).value);
            }
            catch (Exception) { }
        }

        private void LoadTabCustomer()
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void tbSettingItemPerPage_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            uint numberItemPerPage = 5;
            tbSettingItemPerPage.ToolTip = tbSettingItemPerPage.Value;

            try
            {
                if (!uint.TryParse(tbSettingItemPerPage.Value.Value.ToString(), out numberItemPerPage))
                {
                    throw new Exception();
                }
                else if (tbSettingItemPerPage.Background == Brushes.Red)
                {
                    tbSettingItemPerPage.Background = SystemColors.WindowBrush;
                }
            }
            catch (Exception)
            {
                tbSettingItemPerPage.Background = Brushes.Red;
            }
        }

        private void cbbProductCategoryName_DropDownOpened(object sender, EventArgs e)
        {
            IList<Impl.UI.ManagerProduct.Category> categories = Impl.UI.ManagerProduct.Category.GetAll();
            categories.Insert(0, new Impl.UI.ManagerProduct.Category(new Model.CATEGORY() { name = "" }));

            cbbProductCategoryName.Items.Clear();
            foreach (Impl.UI.ManagerProduct.Category item in categories)
            {
                cbbProductCategoryName.Items.Add(item);
            }

        }

        private void uc_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender is UserControl)
            {
                UserControl userControl = sender as UserControl;

                Grid controlParent = (Grid)userControl.Parent;

                foreach (var item in controlParent.Children)
                {
                    Control control = item as Control;
                    if (control!=sender)
                    {
                        control.Visibility = Visibility.Collapsed;
                    }
                }
            }
        }

        private void cbbProductCategoryPage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ucProduct.Visibility = Visibility.Visible;

            List<Impl.UI.ManagerProduct.ProductInfor> productInfors = ((Impl.UI.ManagerProduct.PageProducts)cbbProductCategoryPage.SelectedItem).Products;

            ucProduct.ProductInfors = productInfors;
        }

        private void cbbProductCategoryName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ucProduct.Visibility = Visibility.Visible;
            FilterAndGenPageProduct(Impl.UI.ManagerProduct.ProductInfor.GetAll());
        }

        private void ucProduct_ListProductChanged(object sender, RoutedEventArgs e)
        {
            btnProductProductUpdate.IsEnabled = true;
        }
    }
}
