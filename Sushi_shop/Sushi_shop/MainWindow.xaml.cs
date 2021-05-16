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

namespace Sushi_shop
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

        private void Button_Register(object sender, RoutedEventArgs e)
        {
            string userEmail = textBoxEmail.Text.Trim().ToLower();
            string userName = textBoxName.Text.Trim();
            string userLastName = textBoxLastName.Text.Trim();
            string userAddress = textBoxAddress.Text.Trim();
            string userPhone = textBoxPhoneNumber.Text.Trim();
            string userPassword = passwordBox.Password.Trim().GetHashCode().ToString();
            string userPassword2 = passwordBox2.Password.Trim().GetHashCode().ToString();
            if (userPassword.Length < 7)
            {
                passwordBox.ToolTip = "password is too short";
                MessageBox.Show("error in the password field");
                passwordBox.Focus();
            }
            else if (userPassword != userPassword2)
            {
                passwordBox2.ToolTip = "password must match";
                MessageBox.Show("error in the password field");
                passwordBox2.Focus();
            }
            else if (!userEmail.Contains("@mail.ru") && !userEmail.Contains("@list.ru"))
            {
                textBoxEmail.ToolTip = "email must include @mail.ru or @list.ru";
                MessageBox.Show("error in the email field");
                textBoxEmail.Focus();
            }
            else {
                textBoxEmail.ToolTip = "";
                textBoxName.ToolTip = "";
                textBoxLastName.ToolTip = "";
                textBoxAddress.ToolTip = "";
                textBoxPhoneNumber.ToolTip = "";
                passwordBox.ToolTip = "";
                passwordBox2.ToolTip = "";

                MessageBox.Show("registration complete");
                Clients client = new Clients(userEmail, userName, userLastName, userAddress, userPhone, userPassword);
                loginWindow.SushiDb.Clients.Add(client);
                loginWindow.SushiDb.SaveChanges();
                loginWindow toLoginWindow = new loginWindow();
                toLoginWindow.Show();
                Hide();
            }

        }

        private void To_Sign_In_Window(object sender, RoutedEventArgs e)
        {
            loginWindow toLoginWindow = new loginWindow();
            toLoginWindow.Show();
            Hide();
        }
    }
}
