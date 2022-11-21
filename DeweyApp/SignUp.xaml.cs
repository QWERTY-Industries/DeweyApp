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
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        FirebaseLink firebaseLink = new FirebaseLink();

        public SignUp()
        {
            InitializeComponent();
            //txbEmail.Text = "qwerty@gmail.com"; // TESTING PURPOSES
            //txbPassword.Text = "feet"; // TESTING PURPOSES
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            firebaseLink.SignUpUser(txbEmail.Text, txbPassword.Text);
            
            txbEmail.Clear();
            txbPassword.Clear();

            LogIn logIn = new LogIn();
            logIn.Show();
            this.Close();
        }

        private void btnLogInScreen_Click(object sender, RoutedEventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            this.Close();
        }
    }
}
