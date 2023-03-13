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
using ChatWPF_Appalonov.Class;
using ChatWPF_Appalonov.Model;
using ChatWPF_Appalonov.Windows;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace ChatWPF_Appalonov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(PsBPassword.Password) || string.IsNullOrEmpty(TxtLogin.Text))
            {
                MessageBox.Show("Please fill in the fields", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var auth = Connect.connect.Employee.Where(z => z.Password == PsBPassword.Password && z.Username == TxtLogin.Text).FirstOrDefault();
                if (auth != null)
                {
                    
                    UserWindow userWindow = new UserWindow(auth);
                    userWindow.Show();
                    var message = MessageBox.Show($"Hello {auth.Name}", "Login", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    App.Current.MainWindow.Close();
                }
                else
                {
                    MessageBox.Show("Authorization error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ChBRemember_Checked(object sender, RoutedEventArgs e)
        { 
            //////////////////////Работает но не доступно из-за прав администратора
            
            //StreamWriter writerLog = new StreamWriter("/SavedLog.txt");
            //StreamWriter writerPass = new StreamWriter("/SavedPass.txt");
           
            //if (ChBRemember.IsChecked==true)
            //{
            //    writerLog.Write(TxtLogin.Text);
            //    writerPass.Write(PsBPassword.Password);
            //}
            //if (ChBRemember.IsChecked == false)
            //{
            //    writerLog.Write("");
            //    writerPass.Write("");
            //}
        }
    }
}
