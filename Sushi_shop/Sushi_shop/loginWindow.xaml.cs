using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using Sushi_shop.viewmodel;

namespace Sushi_shop
{
    /// <summary>
    /// Логика взаимодействия для loginWindow.xaml
    /// </summary>
    public partial class loginWindow : Window
    {
        public static int IsAdmin;
        public static  Entities SushiDb;
        public static ModelMain _ModelMain;
        public loginWindow()
        {
            InitializeComponent();
            SushiDb = new Entities();
            SushiDb.Products.Load();
            SushiDb.category.Load();
            _ModelMain = new ModelMain();
        }

        private void Button_Sign_Click(object sender, RoutedEventArgs e)
        {
            string userEmail = textBoxEmail.Text.Trim().ToLower();
            string userPassword = passwordBox.Password.Trim().GetHashCode().ToString();

            // if (userPassword.Length < 7)
            // {
            //     passwordBox.ToolTip = "password is too short";
            //     MessageBox.Show("error in the password field");
            //     passwordBox.Focus();
            // }
            // else if (!userEmail.Contains("@mail.ru") && !userEmail.Contains("@list.ru"))
            // {
            //     textBoxEmail.ToolTip = "email must include @mail.ru or @list.ru";
            //     MessageBox.Show("error in the email field");
            //     textBoxEmail.Focus();
            // }
            // else
            // {
            //     textBoxEmail.ToolTip = "";
            //     passwordBox.ToolTip = "";
            //     
            //     var user = SushiDb.Clients.SqlQuery("select * from Clients where  email = '" + userEmail +
            //                                    "' and pasword = '" + userPassword+"'").FirstOrDefault();
            //  // var  user = SushiDb.Clients.FirstOrDefault(c => c.email == userEmail);
            Clients user = new Clients();
            if (user != null)
                {
                    if (user.email == "admin@mail.ru")
                        IsAdmin = 1;
                    SushiWindow toShushiWindow = new SushiWindow();
                    toShushiWindow.Show();
                    Hide();
                }
                else
                    MessageBox.Show("hren'");

            //}

        }

        private void To_sign_up_window(object sender, RoutedEventArgs e)
        {
            MainWindow toMainWindow = new MainWindow();
            toMainWindow.Show();
            Hide();

        }
    }
}
