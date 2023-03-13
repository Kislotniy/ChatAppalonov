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
    /// Логика взаимодействия для ChatRoomService.xaml
    /// </summary>
    public partial class ChatRoomService : Window

    {
        public Chatroom currentChatroom;
        public ChatMessage message;
        public Employee employee;
        public EmployeeChat roomChat;
        public ChatRoomService(Chatroom chatroom)
        {
            InitializeComponent();
            var idnamechatroom = chatroom.Id_Chatroom;

            LvUser.ItemsSource = Connect.connect.EmployeeChat.Where(z => z.Chatroom_Id == idnamechatroom).ToList();

            currentChatroom = chatroom;
            this.DataContext = currentChatroom;
            LvMessages.ItemsSource = Connect.connect.ChatMessage.Where(z => z.Chatroom_Id == chatroom.Id_Chatroom).ToList();
        }
        private void Refreshmessage()
        {
            LvMessages.ItemsSource = Connect.connect.ChatMessage.Where(z => z.Chatroom_Id == currentChatroom.Id_Chatroom).ToList();
        }
        private void asd()
        {
           
            ChatRoomService chatRoom = new ChatRoomService(currentChatroom);
            this.Close();   chatRoom.ShowDialog();
          
            
        }

        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            EmployeeSearch addUsers = new EmployeeSearch(currentChatroom.Id_Chatroom,employee);
            addUsers.Closed += (q,w) => asd();
            addUsers.ShowDialog();
            

            
        }

        private void BtnChangeTopic_Click(object sender, RoutedEventArgs e)
        {
            ChangeTopic changeTopic = new ChangeTopic(currentChatroom);
            changeTopic.Show();
        }

        private void LeaveChatroom_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtMessage.Text))
            {
                MessageBox.Show("You can't send an empty message!!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var message = new ChatMessage()
                {
                    Sender_Id = UserWindow.Eemployee.Id_Employee,Chatroom_Id = currentChatroom.Id_Chatroom,Date = DateTime.Now,Message = TxtMessage.Text,};
                Connect.connect.ChatMessage.Add(message);
                Connect.connect.SaveChanges();
                Refreshmessage();
                TxtMessage.Text = "";
            }
        }
    }
}
