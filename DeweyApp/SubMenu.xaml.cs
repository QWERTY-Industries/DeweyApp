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
    /// Interaction logic for SubMenu.xaml
    /// </summary>
    public partial class SubMenu : Window
    {
        FirebaseLink firebaseLink;
        int gamemode;

        public SubMenu(FirebaseLink fbl, int mode)
        {
            InitializeComponent();
            firebaseLink = fbl;
            gamemode = mode;

            if (gamemode == 0)
            {
                // Taken From StackOverflow
                // Authour Gaessaki
                // Year 2015
                // https://stackoverflow.com/questions/28437096/how-do-i-programmatically-change-the-title-in-a-wpf-window
                this.Title = "Replacing Books";
                //****************
            }
            else if (gamemode == 1)
            {
                this.Title = "Identifying Areas";
            }
            else
            {
                this.Title = "Finding Call Numbers";
            }
        }

        private void btnAdventureMap_Click(object sender, RoutedEventArgs e)
        {
            AdventureMap adventureMap = new AdventureMap(firebaseLink, gamemode);
            adventureMap.Show();
            this.Close();
        }

        private void btnChallengeLevels_Click(object sender, RoutedEventArgs e)
        {
            if (firebaseLink.getUserLevel(gamemode) >= 10)
            {
                ChallengeLevels challengeLevels = new ChallengeLevels(firebaseLink, gamemode);
                challengeLevels.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Complete the Adventure Map to Unlock Challenge Levels", "No Newbies Allowed!");
            }
        }

        private void btnLeaderboard_Click(object sender, RoutedEventArgs e)
        {
            if (firebaseLink.getUserLevel(gamemode) >= 10)
            {
                Leaderboard leaderboard = new Leaderboard(firebaseLink, gamemode);
                leaderboard.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Complete the Adventure Map to Unlock the Leaderboard", "No Newbies Allowed!");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu(firebaseLink);
            mainMenu.Show();
            this.Close();
        }
    }
}
