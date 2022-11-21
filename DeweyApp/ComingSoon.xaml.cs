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
    /// Interaction logic for ComingSoon.xaml
    /// </summary>
    public partial class ComingSoon : Window
    {
        FirebaseLink firebaseLink;

        public ComingSoon(FirebaseLink fbl)
        {
            InitializeComponent();
            firebaseLink = fbl;
        }

        private void btnMainMenuScreen_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu(firebaseLink);
            mainMenu.Show();
            this.Close();
        }
    }
}
