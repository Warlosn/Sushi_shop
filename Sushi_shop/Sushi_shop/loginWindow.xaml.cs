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

namespace Sushi_shop
{
    /// <summary>
    /// Логика взаимодействия для loginWindow.xaml
    /// </summary>
    public partial class loginWindow : Window
    {
        public loginWindow()
        {
            InitializeComponent();
        }

        private void Button_Sign_Click(object sender, RoutedEventArgs e)
        {
            string userEmail = textBoxEmail.Text.Trim().ToLower();
            string userPassword = passwordBox.Password.Trim().GetHashCode().ToString();

            if (userPassword.Length < 7)
            {
                passwordBox.ToolTip = "password is too short";
                MessageBox.Show("error in the password field");
                passwordBox.Focus();
            }
            else if (!userEmail.Contains("@mail.ru") && !userEmail.Contains("@list.ru"))
            {
                textBoxEmail.ToolTip = "email must include @mail.ru or @list.ru";
                MessageBox.Show("error in the email field");
                textBoxEmail.Focus();
            }
            else
            {
                textBoxEmail.ToolTip = "";
                passwordBox.ToolTip = "";


                //НЕ РАБОТЕТ!!!!!!!!
                //Clients signIn = null;
                //using (sushiDBEntities db = new sushiDBEntities()) {
                //    signIn = db.Clients.Where(b => b.email == userEmail).FirstOrDefault();

                //}
                //if (signIn != null)
                //    MessageBox.Show("vrode norm");
                //else
                //    MessageBox.Show("hren'");
                   
            }

        }

        private void to_sign_up_window(object sender, RoutedEventArgs e)
        {
            MainWindow toMainWindow = new MainWindow();
            toMainWindow.Show();
            Hide();

        }
    }
}
