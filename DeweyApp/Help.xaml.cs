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
    /// Interaction logic for Help.xaml
    /// </summary>
    public partial class Help : Window
    {
        FirebaseLink firebaseLink;
        public Help(FirebaseLink fbl)
        {
            InitializeComponent();
            firebaseLink = fbl;
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (txbDeveloperCode.Text == "FULL MARKS")
            {
                firebaseLink.EnableDeveloperStatus();
            }

            txbDeveloperCode.Clear();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu(firebaseLink);
            mainMenu.Show();
            this.Close();
        }
        //xaml
        //https://stackoverflow.com/questions/183406/newline-in-string-attribute
    }
}
