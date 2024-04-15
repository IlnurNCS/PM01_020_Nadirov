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
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            
            AuthUsr(Id.Text, Password.Text);

        }

        public bool AuthUsr(string login, string password)
        {
            

            
            if (string.IsNullOrEmpty(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите логин и пароль");
                return false;
            }

           

            using (var db = new Entities())
            {
                var moderator = db.Moderators.AsNoTracking().FirstOrDefault(u => u.ID.ToString() == login && u.Password == password);
                if (AuthenticateUser(moderator, new Profile(), "", ""))
                    return true;



                var organizer = db.Organizers.AsNoTracking().FirstOrDefault(u => u.ID.ToString() == login && u.Password == password);

                if (organizer == null)
                {
                    MessageBox.Show("Логин или пароль неверный");
                    return false;
                }

                if (AuthenticateUser(organizer, new Profile(), organizer.Surname, organizer.Otch))
                    return true;

                var participant = db.Participants.AsNoTracking().FirstOrDefault(u => u.ID.ToString() == login && u.Password == password);
                if (AuthenticateUser(participant, new Profile(), "", ""))
                    return true;
            }
            return false;
        }

            private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registrarion());
        }

        private void Id_TextChanged(object sender, TextChangedEventArgs e)
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

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
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


        private bool AuthenticateUser(object authenticatedUser, Page nextPage, string name, string Otch)
        {
            if (authenticatedUser != null)
            {
                RememberCredentials(Id.Text, Password.Text);
                NavigationService?.Navigate(nextPage);
                

                return true;
            }

            return false;
        }

        private void RememberCredentials(string login, string password)
        {

            UserCredentials.RememberCredentials(login, password);
        }

        public static class UserCredentials
        {
            private static string rememberedLogin;
            private static string rememberedPassword;

            public static void RememberCredentials(string login, string password)
            {
                rememberedLogin = login;
                rememberedPassword = password;
            }

            public static bool TryGetRememberedCredentials(out string login, out string password)
            {
                login = rememberedLogin;
                password = rememberedPassword;
                return !string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password);
            }

        }

    }

}
