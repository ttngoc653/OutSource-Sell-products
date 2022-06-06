﻿using System;
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
using System.Windows.Shapes;

namespace SellProducts
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private Impl.ViewModel.Login login1;

        public Impl.ViewModel.Login Getlogin()
        {
            return login1;
        }

        public LoginWindow()
        {
            InitializeComponent();

            this.Loaded += LoginWindow_Loaded;
        }

        private void LoginWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (new Common.ConnectDB.Manager().ChangePassword("admin", "admin", Common.Utils.CriptoUtil.CreateMD5("admin"))==1)
                {
                    MessageBox.Show("Changed password admin.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (Properties.Settings.Default.remember == false)
                this.login1 = new Impl.ViewModel.Login();
            else
            {
                this.login1 = new Impl.ViewModel.Login()
                {
                    UserName = Properties.Settings.Default.user,
                    Password = Properties.Settings.Default.pass,
                    Remember = Properties.Settings.Default.remember
                };
                TextBoxPassword.Password = Getlogin().Password;

                CheckAccount();
            }
            this.DataContext = Getlogin();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Getlogin().Password = Common.Utils.CriptoUtil.CreateMD5(TextBoxPassword.Password);

            CheckAccount();
        }

        private void CheckAccount()
        {
            if (new Common.ConnectDB.Manager().Get(Getlogin().UserName, Getlogin().Password) != null)
            {
                if (Getlogin().Remember)
                {
                    Properties.Settings.Default.user = Getlogin().UserName;
                    Properties.Settings.Default.pass = Getlogin().Password;
                    Properties.Settings.Default.remember = Getlogin().Remember;

                    Properties.Settings.Default.Save();
                }
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Sai tài khoản. Vui lòng thử lại.");
            }
        }
    }
}
