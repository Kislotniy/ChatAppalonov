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
using System.Windows.Shapes;
using ChatWPF_Appalonov.Model;
using ChatWPF_Appalonov.Class;
using ChatWPF_Appalonov.Windows;

namespace ChatWPF_Appalonov.Windows
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public static Employee Eemployee;
        public UserWindow(Employee employee)
        {
            InitializeComponent();
            Eemployee = employee;
            this.DataContext = Eemployee;
            LvChats.ItemsSource = Connect.connect.Chatroom.ToList();
        }

        

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {

            EmployeeSearch search = new EmployeeSearch(0,Eemployee);
            this.Close();
            search.ShowDialog();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void LvChats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var idchatroom = Connect.connect.EmployeeChat.Where(z => z.Employee_Id == Eemployee.Id_Employee).FirstOrDefault();
            if (idchatroom != null)
            {
                var a = ((sender as ListView).SelectedItem as Chatroom);
                
                ChatRoomService chatroomserv = new ChatRoomService(a);
                this.Close();
                chatroomserv.ShowDialog();
            }
            else
            {
                MessageBox.Show("Вас нет в этом чате!");
            }

        }
    }
}
