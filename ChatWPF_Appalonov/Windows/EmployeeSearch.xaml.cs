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
    /// Логика взаимодействия для EmployeeSearch.xaml
    /// </summary>
    public partial class EmployeeSearch : Window
    {   

        int CurrentChatroom;
        Employee empl;
        public EmployeeSearch(int chatroom, Employee employee)
        {
            InitializeComponent();
            CurrentChatroom = chatroom;
            empl = employee;
            LvEmployee.ItemsSource = Connect.connect.Employee.ToList();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            EmployeeChat addemployee = new EmployeeChat();
            addemployee.Chatroom_Id = CurrentChatroom;
            var a = LvEmployee.SelectedItem as Employee;
            var b = Connect.connect.Employee.Where(z => z.Id_Employee == a.Id_Employee).FirstOrDefault();
            addemployee.Employee_Id = b.Id_Employee;
            Connect.connect.EmployeeChat.Add(addemployee);
            Connect.connect.SaveChanges();
            MessageBox.Show("Saved!");
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            LvEmployee.ItemsSource = Connect.connect.Employee.Where(z => z.Name.Contains(TxtSearch.Text)).ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            //ChatRoomService chatRoom = new ChatRoomService();
            this.Close();
            //chatRoom.ShowDialog();

        }

        private void LvEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (CH1.IsChecked == true)
            {
                LvEmployee.ItemsSource = Connect.connect.Employee.Where(z => z.Department_Id == 1).ToList();
            }
            if (CH1.IsChecked == false)
            {
                LvEmployee.ItemsSource = Connect.connect.Employee.ToList();
            }
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            if (CH2.IsChecked == true)
            {
                LvEmployee.ItemsSource = Connect.connect.Employee.Where(z => z.Department_Id == 2).ToList();
            }
            if (CH2.IsChecked == false)
            {
                LvEmployee.ItemsSource = Connect.connect.Employee.ToList();
            }

        }

        private void CheckBox_Checked_2(object sender, RoutedEventArgs e)
        {
            if (CH3.IsChecked == true)
            {
               LvEmployee.ItemsSource = Connect.connect.Employee.Where(z => z.Department_Id == 3).ToList();
            }
            if (CH3.IsChecked == false)
            {
                LvEmployee.ItemsSource = Connect.connect.Employee.ToList();
            }
        }

        private void CheckBox_Checked_3(object sender, RoutedEventArgs e)
        {
            if (CH4.IsChecked == true)
            {
                LvEmployee.ItemsSource = Connect.connect.Employee.Where(z => z.Department_Id == 4).ToList();
            }
            if (CH4.IsChecked == false)
            {
                LvEmployee.ItemsSource = Connect.connect.Employee.ToList();
            }
        }
    }
}
