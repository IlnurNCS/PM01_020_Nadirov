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

namespace PM._01.Pages
{
    /// <summary>
    /// Логика взаимодействия для Registrarion.xaml
    /// </summary>
    public partial class Registrarion : Page
    {
        
        public Registrarion()
        {
            InitializeComponent();
           
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Id.Text.Length > 0)
            {
                Labelid.Visibility = Visibility.Hidden;
            }
            if (Id.Text.Length == 0)
            {
                Labelid.Visibility = Visibility.Visible;
            }
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (Password.Text.Length > 0)
            {
                Labelpass.Visibility = Visibility.Hidden;
            }

            if (Password.Text.Length == 0)
            {
                Labelpass.Visibility = Visibility.Visible;
            }
        }

        
       
    }
}
