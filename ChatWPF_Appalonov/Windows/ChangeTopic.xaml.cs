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
    /// Логика взаимодействия для ChangeTopic.xaml
    /// </summary>
    public partial class ChangeTopic : Window
    {
        public ChangeTopic(Chatroom namechat)
        {
            InitializeComponent();
            this.DataContext = namechat;
        }

        private void BTNSave_Click(object sender, RoutedEventArgs e)
        {
            Connect.connect.SaveChanges();
            MessageBox.Show("Saved!");
            this.Close();
        }
    }
}
