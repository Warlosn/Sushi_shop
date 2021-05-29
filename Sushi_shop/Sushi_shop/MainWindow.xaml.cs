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
            string userPassword = passwordBox.Password.ToString();
            string userPassword2 = passwordBox2.Password.Trim().ToString();
            if (userName.Length < 2)
            {
                textBoxName.ToolTip = "Имя слишком короткое";
                MessageBox.Show("Ошибка в поле имя");
                textBoxName.Focus();
            }
            else if (userLastName.Length < 3)
            {
                textBoxLastName.ToolTip = "Фамилия слишком короткая";
                MessageBox.Show("Ошибка в поле Фамилия");
                textBoxLastName.Focus();
            }
            else if (userAddress.Length < 5)
            {
                textBoxAddress.ToolTip = "Адрес слишком короткий";
                MessageBox.Show("Ошибка в поле Адресс");
                textBoxAddress.Focus();
            }
            else if (userPhone.Length !=12)
            {
                textBoxPhoneNumber.ToolTip = "номер телефона некорректный";
                MessageBox.Show("Ошибка в поле номер телефона");
                textBoxPhoneNumber.Focus();
            }
            else if (userPassword.Length < 7)
            {
                passwordBox.ToolTip = "Пароль слишком короткий";
                MessageBox.Show("Ошибка в поле пароль");
                passwordBox.Focus();
            }
            else if (userPassword != userPassword2)
            {
                passwordBox2.ToolTip = "пароли должны совпадать";
                MessageBox.Show("Ошибка в поле парольы");
                passwordBox2.Focus();
            }
            else if (!userEmail.Contains("@mail.ru") && !userEmail.Contains("@list.ru"))
            {
                textBoxEmail.ToolTip = "email должен включать @mail.ru или @list.ru";
                MessageBox.Show("ошибка в поле email");
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

                MessageBox.Show("регистрация завершена");
                Clients client = new Clients(userEmail, userName, userLastName, userAddress, userPhone, userPassword.GetHashCode().ToString());
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
