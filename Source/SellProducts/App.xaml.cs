using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SellProducts
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            string filelog = System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName + ".log";
            List<string> logcontents = new List<string>() {
                DateTime.Now.ToString() + ": " + e.Exception.Message,
                e.Exception.StackTrace            
            };
            System.IO.File.AppendAllLines(filelog, logcontents);

            MessageBox.Show(e.Exception.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
            e.Handled = true;
        }
    }
}
