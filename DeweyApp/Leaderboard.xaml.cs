using DeweyApp.MVVM.Model;
using DeweyApp.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
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
using static System.Net.Mime.MediaTypeNames;

namespace DeweyApp
{
    /// <summary>
    /// Interaction logic for Leaderboard.xaml
    /// </summary>
    public partial class Leaderboard : Window
    {
        FirebaseLink firebaseLink;
        int gamemode;

        public Leaderboard(FirebaseLink fbs, int mode)
        {
            InitializeComponent();
            firebaseLink = fbs;
            gamemode = mode;

            BitmapImage backgroundBitmapImage = new BitmapImage();
            Uri UriSource;

            if (gamemode == 0)
            {
                // Taken From StackOverflow
                // Authour Gaessaki
                // Year 2015
                // https://stackoverflow.com/questions/28437096/how-do-i-programmatically-change-the-title-in-a-wpf-window
                this.Title = "Replacing Books Leaderboard";
                //****************

                UriSource = new Uri("Images/ReplacingBooksBackgrounds/LeaderboardA.jpg", UriKind.Relative);
            }
            else if (gamemode == 1)
            {
                this.Title = "Identifying Areas Leaderboard";

                UriSource = new Uri("Images/IdentifiyingAreasBackgrounds/LeaderboardB.jpg", UriKind.Relative);
            }
            else
            {
                this.Title = "Finding Call Numbers Leaderboard";

                UriSource = new Uri("Images/FindingCallNumbersBackgrounds/LeaderboardC.jpg", UriKind.Relative);
            }

            image.Source = new BitmapImage(UriSource);
            ImageSource newImage = image.Source;

            Background = new ImageBrush(newImage);
            image.Stretch = Stretch.Fill;

            firebaseLink.GenerateTopPlayers(gamemode);

            string[] leaderboardUsernames = firebaseLink.GetLeaderboardUsernames();

            for (int i = 0; i < leaderboardUsernames.Length; i++)
            {
                lstPlayers.Items.Add(leaderboardUsernames[i]);
            }

            BitmapImage bitmapImage = new BitmapImage();
            Uri uriSource;

            lblUsername.Content = firebaseLink.GetUsername();

            lblLevel.Content = "Level " + firebaseLink.getUserLevel(gamemode);

            int picture = firebaseLink.GetDisplayPicture();

            if (picture == 1)
            {
                uriSource = new Uri("Images/Avatars/RobotAvatar.jpg", UriKind.Relative); //imgDisplayPicture.Source = new BitmapImage(new Uri("Images/Avatars/RobotAvatar", UriKind.Relative));
            }
            else if (picture == 2)
            {
                uriSource = new Uri("Images/Avatars/GoblinAvatar.jpg", UriKind.Relative);
            }
            else if (picture == 3)
            {
                uriSource = new Uri("Images/Avatars/KnightAvatar.jpg", UriKind.Relative);
            }
            else if (picture == 4)
            {
                uriSource = new Uri("Images/Avatars/QwertyAvatar.jpg", UriKind.Relative);
            }
            else if (picture == 5)
            {
                uriSource = new Uri("Images/Avatars/ManAvatar.jpg", UriKind.Relative);
            }
            else if (picture == 6)
            {
                uriSource = new Uri("Images/Avatars/WomanAvatar.jpg", UriKind.Relative);
            }
            else if (picture == 7)
            {
                uriSource = new Uri("Images/Avatars/BookAvatar.jpg", UriKind.Relative);
            }
            else if (picture == 8)
            {
                uriSource = new Uri("Images/Avatars/GroupAvatar.jpg", UriKind.Relative);
            }
            else
            {
                uriSource = new Uri("Images/Avatars/DefaultAvatar.jpg", UriKind.Relative);
            }

            imgDisplayPicture.Source = new BitmapImage(uriSource);

            bool[] achievements = firebaseLink.GetUserAchievements();
            bool[] items = firebaseLink.GetUserShopItems();

            if (achievements[0])
            {
                imgNewbie.Visibility = Visibility.Visible;
            }

            if (achievements[1])
            {
                imgBookReplacer.Visibility = Visibility.Visible;
            }

            if (achievements[2])
            {
                imgAreaIdentifier.Visibility = Visibility.Visible;
            }

            if (achievements[3])
            {
                imgCallNumberFinder.Visibility = Visibility.Visible;
            }

            if (achievements[7])
            {
                imgNovice.Visibility = Visibility.Visible;
            }

            if (achievements[8])
            {
                imgHead.Visibility = Visibility.Visible;
            }

            if (items[0])
            {
                imgPamphlet.Visibility = Visibility.Visible;
            }

            if (items[1])
            {
                imgManual.Visibility = Visibility.Visible;
            }

            if (items[2])
            {
                imgEncyclopedia.Visibility = Visibility.Visible;
            }

            if (items[5])
            {
                imgRobotBobble.Visibility = Visibility.Visible;
            }

            if (items[6])
            {
                imgGoblinBobble.Visibility = Visibility.Visible;
            }

            if (items[7])
            {
                imgKnightBobble.Visibility = Visibility.Visible;
            }
        }

        private void btnViewPlayer_Click(object sender, RoutedEventArgs e)
        {
            string leaderboardPlayerId = "";

            for (int i = 0; i < lstPlayers.Items.Count; i++)
            {
                if (lstPlayers.SelectedIndex == i)
                {
                    leaderboardPlayerId = firebaseLink.GetLeaderboardPlayer(i);
                }
            }

            BitmapImage bitmapImage = new BitmapImage();
            Uri uriSource;

            lblUsername.Content = firebaseLink.GetLeaderboardUsername(leaderboardPlayerId);
            lblLevel.Content = "Level " + firebaseLink.GetLeaderboardLevel(leaderboardPlayerId, gamemode);
            
            int picture = firebaseLink.GetLeaderboardPicture(leaderboardPlayerId);

            if (picture == 1)
            {
                uriSource = new Uri("Images/Avatars/RobotAvatar.jpg", UriKind.Relative);
            }
            else if (picture == 2)
            {
                uriSource = new Uri("Images/Avatars/GoblinAvatar.jpg", UriKind.Relative);
            }
            else if (picture == 3)
            {
                uriSource = new Uri("Images/Avatars/KnightAvatar.jpg", UriKind.Relative);
            }
            else if (picture == 4)
            {
                uriSource = new Uri("Images/Avatars/QwertyAvatar.jpg", UriKind.Relative);
            }
            else if (picture == 5)
            {
                uriSource = new Uri("Images/Avatars/ManAvatar.jpg", UriKind.Relative);
            }
            else if (picture == 6)
            {
                uriSource = new Uri("Images/Avatars/WomanAvatar.jpg", UriKind.Relative);
            }
            else if (picture == 7)
            {
                uriSource = new Uri("Images/Avatars/BookAvatar.jpg", UriKind.Relative);
            }
            else if (picture == 8)
            {
                uriSource = new Uri("Images/Avatars/GroupAvatar.jpg", UriKind.Relative);
            }
            else
            {
                uriSource = new Uri("Images/Avatars/DefaultAvatar.jpg", UriKind.Relative);
            }

            imgDisplayPicture.Source = new BitmapImage(uriSource);

            bool[] achievements = firebaseLink.GetLeaderboardAchievements(leaderboardPlayerId);
            bool[] items = firebaseLink.GetLeaderboardShopItems(leaderboardPlayerId);

            imgNewbie.Visibility = Visibility.Hidden;
            imgBookReplacer.Visibility = Visibility.Hidden;
            imgAreaIdentifier.Visibility = Visibility.Hidden;
            imgCallNumberFinder.Visibility = Visibility.Hidden;
            imgNovice.Visibility = Visibility.Hidden;
            imgHead.Visibility = Visibility.Hidden;
            
            imgPamphlet.Visibility = Visibility.Hidden;
            imgManual.Visibility = Visibility.Hidden;
            imgEncyclopedia.Visibility = Visibility.Hidden;
            imgRobotBobble.Visibility = Visibility.Hidden;
            imgGoblinBobble.Visibility = Visibility.Hidden;
            imgKnightBobble.Visibility = Visibility.Hidden;

            if (achievements[0])
            {
                imgNewbie.Visibility = Visibility.Visible;
            }

            if (achievements[1])
            {
                imgBookReplacer.Visibility = Visibility.Visible;
            }

            if (achievements[2])
            {
                imgAreaIdentifier.Visibility = Visibility.Visible;
            }

            if (achievements[3])
            {
                imgCallNumberFinder.Visibility = Visibility.Visible;
            }

            if (achievements[7])
            {
                imgNovice.Visibility = Visibility.Visible;
            }

            if (achievements[8])
            {
                imgHead.Visibility = Visibility.Visible;
            }

            if (items[0])
            {
                imgPamphlet.Visibility = Visibility.Visible;
            }

            if (items[1])
            {
                imgManual.Visibility = Visibility.Visible;
            }

            if (items[2])
            {
                imgEncyclopedia.Visibility = Visibility.Visible;
            }

            if (items[5])
            {
                imgRobotBobble.Visibility = Visibility.Visible;
            }

            if (items[6])
            {
                imgGoblinBobble.Visibility = Visibility.Visible;
            }

            if (items[7])
            {
                imgKnightBobble.Visibility = Visibility.Visible;
            }
        }

        private void btnViewMyProfile_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage bitmapImage = new BitmapImage();
            Uri uriSource;

            lblUsername.Content = firebaseLink.GetUsername();

            lblLevel.Content = "Level " + firebaseLink.getUserLevel(gamemode);

            int picture = firebaseLink.GetDisplayPicture();

            if (picture == 1)
            {
                uriSource = new Uri("Images/Avatars/RobotAvatar.jpg", UriKind.Relative);
            }
            else if (picture == 2)
            {
                uriSource = new Uri("Images/Avatars/GoblinAvatar.jpg", UriKind.Relative);
            }
            else if (picture == 3)
            {
                uriSource = new Uri("Images/Avatars/KnightAvatar.jpg", UriKind.Relative);
            }
            else if (picture == 4)
            {
                uriSource = new Uri("Images/Avatars/QwertyAvatar.jpg", UriKind.Relative);
            }
            else if (picture == 5)
            {
                uriSource = new Uri("Images/Avatars/ManAvatar.jpg", UriKind.Relative);
            }
            else if (picture == 6)
            {
                uriSource = new Uri("Images/Avatars/WomanAvatar.jpg", UriKind.Relative);
            }
            else if (picture == 7)
            {
                uriSource = new Uri("Images/Avatars/BookAvatar.jpg", UriKind.Relative);
            }
            else if (picture == 8)
            {
                uriSource = new Uri("Images/Avatars/GroupAvatar.jpg", UriKind.Relative);
            }
            else
            {
                uriSource = new Uri("Images/Avatars/DefaultAvatar.jpg", UriKind.Relative);
            }

            imgDisplayPicture.Source = new BitmapImage(uriSource);

            bool[] achievements = firebaseLink.GetUserAchievements();
            bool[] items = firebaseLink.GetUserShopItems();

            imgNewbie.Visibility = Visibility.Hidden;
            imgBookReplacer.Visibility = Visibility.Hidden;
            imgAreaIdentifier.Visibility = Visibility.Hidden;
            imgCallNumberFinder.Visibility = Visibility.Hidden;
            imgNovice.Visibility = Visibility.Hidden;
            imgHead.Visibility = Visibility.Hidden;

            imgPamphlet.Visibility = Visibility.Hidden;
            imgManual.Visibility = Visibility.Hidden;
            imgEncyclopedia.Visibility = Visibility.Hidden;
            imgRobotBobble.Visibility = Visibility.Hidden;
            imgGoblinBobble.Visibility = Visibility.Hidden;
            imgKnightBobble.Visibility = Visibility.Hidden;

            if (achievements[0])
            {
                imgNewbie.Visibility = Visibility.Visible;
            }

            if (achievements[1])
            {
                imgBookReplacer.Visibility = Visibility.Visible;
            }

            if (achievements[2])
            {
                imgAreaIdentifier.Visibility = Visibility.Visible;
            }

            if (achievements[3])
            {
                imgCallNumberFinder.Visibility = Visibility.Visible;
            }

            if (achievements[7])
            {
                imgNovice.Visibility = Visibility.Visible;
            }

            if (achievements[8])
            {
                imgHead.Visibility = Visibility.Visible;
            }

            if (items[0])
            {
                imgPamphlet.Visibility = Visibility.Visible;
            }

            if (items[1])
            {
                imgManual.Visibility = Visibility.Visible;
            }

            if (items[2])
            {
                imgEncyclopedia.Visibility = Visibility.Visible;
            }

            if (items[5])
            {
                imgRobotBobble.Visibility = Visibility.Visible;
            }

            if (items[6])
            {
                imgGoblinBobble.Visibility = Visibility.Visible;
            }

            if (items[7])
            {
                imgKnightBobble.Visibility = Visibility.Visible;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            SubMenu subMenu = new SubMenu(firebaseLink, gamemode);
            subMenu.Show();
            this.Close();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Leaderboard leaderboard = new Leaderboard(firebaseLink, gamemode);
            leaderboard.Show();
            this.Close();
        }
    }
}
