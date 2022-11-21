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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        FirebaseLink firebaseLink;

        public MainMenu(FirebaseLink fbl)
        {
            InitializeComponent();
            firebaseLink = fbl;
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile(firebaseLink);
            profile.Show();
            this.Close();
        }

        private void btnReplacingBooks_Click(object sender, RoutedEventArgs e)
        {
            SubMenu subMenu = new SubMenu(firebaseLink, 0);
            subMenu.Show();
            this.Close();
        }

        private void btnIdentifyingAreas_Click(object sender, RoutedEventArgs e)
        {
            SubMenu subMenu = new SubMenu(firebaseLink, 1);
            subMenu.Show();
            this.Close();
        }

        private void btnFindingCallNumbers_Click(object sender, RoutedEventArgs e)
        {
            SubMenu subMenu = new SubMenu(firebaseLink, 2);
            subMenu.Show();
            this.Close();

            //ComingSoon comingSoon = new ComingSoon(firebaseLink);
            //comingSoon.Show();

            //SubMenu subMenu = new SubMenu(firebaseLink, 1);
            //subMenu.Show();

            this.Close();
        }

        private void btnAchievements_Click(object sender, RoutedEventArgs e)
        {
            Achievements achievements = new Achievements(firebaseLink);
            achievements.Show();
            this.Close();
        }

        private void btnShop_Click(object sender, RoutedEventArgs e)
        {
            Shop shop = new Shop(firebaseLink);
            shop.Show();
            this.Close();
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            Help help = new Help(firebaseLink);
            help.Show();
            this.Close();
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            this.Close();
        }

        //xmal
        //https://stackoverflow.com/questions/11948829/wpf-throws-cannot-locate-resource-exception-when-loading-the-image
    }
}
