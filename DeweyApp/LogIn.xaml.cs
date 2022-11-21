using DeweyApp.MVVM.Model;
using DeweyApp.MVVM.ViewModel;
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

namespace DeweyApp
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        FirebaseLink firebaseLink = new FirebaseLink();

        public LogIn()
        {
            InitializeComponent();
            //txbEmail.Text = "qwerty@gmail.com"; // TESTING PURPOSES
            //txbPassword.Text = "feet"; // TESTING PURPOSES
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            if (firebaseLink.LogInUser(txbEmail.Text, txbPassword.Text) == true)
            {
                txbEmail.Clear();
                txbPassword.Clear();

                MainMenu mainMenu = new MainMenu(firebaseLink);
                mainMenu.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Login Credentials", "Log In Error");
            }
        }

        private void btnSignUpScreen_Click(object sender, RoutedEventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
            this.Close();
        }
    }
}
