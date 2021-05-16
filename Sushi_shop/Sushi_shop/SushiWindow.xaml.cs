using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sushi_shop
{
   
    public partial class SushiWindow : Window
    {
        public SushiWindow()
        {
            InitializeComponent();
            DataContext = loginWindow._ModelMain;
        }
    }
}
