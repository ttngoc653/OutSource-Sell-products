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
            return int.Parse(Common.ConnectDB.Get.Settings()
                                                             .FirstOrDefault(p => p.account == inforLogin.UserName && p.name == SellProduct_CONSTANT.SETTING_PAGING).value);
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
            foreach (object item in UIManager.Children)
            {
                if (item is Design.UI.DashboardControl)
                {
                    (item as Design.UI.DashboardControl).Visibility = Visibility.Visible;
                }
                else
                {
                    (item as UserControl).Visibility = Visibility.Collapsed;
                }
            }
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

        }

        private void btnProductImportProducts_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbbProductCategoryName_DropDownClosed(object sender, EventArgs e)
        {
            string ssada = "SAD";
        }

        private void cbbProductCategoryPage_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void btnProductCategoryAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnProductCategorySee_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnProductCategoryDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnProductProductAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnProductProductUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtProductFindName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void rsProductFindLimitPrice_IsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

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

        private void tbSettingItemPerPage_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int num = (int)tbSettingItemPerPage.Value;

                this.tbSettingItemPerPage.Background = null;
            }
            catch (Exception)
            {
                this.tbSettingItemPerPage.Background = Brushes.Red;
            }
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
            IList<Model.CATEGORY> categories = Common.ConnectDB.Get.Categories();
            categories.Insert(0, new Model.CATEGORY() { name = "" });

            cbbProductCategoryName.Items.Clear();
            for (int i = 0; i < categories.Count; i++)
            {
                cbbProductCategoryName.Items.Add(new Impl.ViewModel.Category(categories.ElementAt(i)));
            }

            IList<Model.PRODUCT> p = Common.ConnectDB.Get.Products();

            try
            {

            }
            catch (Exception)
            {

            }
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
                numberItemPerPage = (uint)tbSettingItemPerPage.Value;
            }
            catch (Exception) { }

            /// load setting open screen last
            try
            {
                cbSettingOpenLastControl.IsChecked = bool.Parse(Common.ConnectDB.Get.Settings().FirstOrDefault(p => p.account == inforLogin.UserName && p.name == SellProduct_CONSTANT.SETTING_SAVE_FUNCTION_LAST).value);
            }
            catch (Exception) { }
        }

        private void LoadTabCustomer()
        {
            throw new NotImplementedException();
        }

        private void tbSettingItemPerPage_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {

        }
    }
}
