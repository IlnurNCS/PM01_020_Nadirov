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
    /// Логика взаимодействия для Merop.xaml
    /// </summary>
    public partial class Merop : Page
    {
        List<Perop> list = new List<Perop>();
        public Merop()
        {
            InitializeComponent();

            list.Add(new Perop("123", "E:\\VSprojects\\Conferencia\\Conferencia\\Images\\foto8.jpg"));
            list.Add(new Perop("1232", "E:\\VSprojects\\Conferencia\\Conferencia\\Images\\foto9.jpg"));
            list.Add(new Perop("12333", "E:\\VSprojects\\Conferencia\\Conferencia\\Images\\foto10.jpg"));
            list.Add(new Perop("12333", "E:\\VSprojects\\Conferencia\\Conferencia\\Images\\foto10.jpg"));
            list.Add(new Perop("12333", "E:\\VSprojects\\Conferencia\\Conferencia\\Images\\foto10.jpg"));
            list.Add(new Perop("12333", "E:\\VSprojects\\Conferencia\\Conferencia\\Images\\foto10.jpg"));

            ListPerop.ItemsSource = list;

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = TextFiltr.Text;
            List<Perop> perops = list.Where(perop => perop.name.ToLower().Contains(text.ToLower())).ToList();
            ListPerop.ItemsSource = perops;
        }
    }

    public class Perop
    {
        public string name { get; set; }
        public string photo { get; set; }
        public Perop(string name, string photo)
        {
            this.name = name;
            this.photo = photo;

        }
    }
}
