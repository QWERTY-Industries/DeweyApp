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
using static System.Net.Mime.MediaTypeNames;

namespace DeweyApp
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        FirebaseLink firebaseLink;
        public Profile(FirebaseLink fbl)
        {
            InitializeComponent();
            firebaseLink = fbl;

            lblUsername.Content = firebaseLink.GetUsername();
            lblRbLevel.Content = "Replacing Books Level " + firebaseLink.getUserLevel(0);
            lblIaLevel.Content = "Identifying Areas Level " + firebaseLink.getUserLevel(1);
            lblFcnLevel.Content = "Finding Call Numbers Level " + firebaseLink.getUserLevel(2);
            lblTotalLevel.Content = firebaseLink.getUserTotalLevel();

            int picture = firebaseLink.GetDisplayPicture();

            BitmapImage bitmapImage = new BitmapImage();
            Uri uriSource;

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

            if (achievements[4])
            {
                lstPictures.Items.Add("Robot Portrait");
            }

            if (achievements[5])
            {
                lstPictures.Items.Add("Goblin Portrait");
            }

            if (achievements[6])
            {
                lstPictures.Items.Add("Knight Portrait");
            }

            if (achievements[7])
            {
                imgNovice.Visibility = Visibility.Visible;
            }

            if (achievements[8])
            {
                imgHead.Visibility = Visibility.Visible;
            }

            if (achievements[9])
            {
                lstPictures.Items.Add("QWERTY");
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

            if (items[3])
            {
                lstPictures.Items.Add("More Sorting?");
            }

            if (items[4])
            {
                lstPictures.Items.Add("It'll be Fun!");
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

            if (items[8])
            {
                lstPictures.Items.Add("Check Out");
            }

            if (items[9])
            {
                lstPictures.Items.Add("Group Picture!");
            }
        }

        private void btnChangeUsername_Click(object sender, RoutedEventArgs e)
        {
            firebaseLink.ChangeUsername(txbUsername.Text);
            lblUsername.Content = txbUsername.Text;
            txbUsername.Clear();
        }

        private void btnSelectPicture_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage bitmapImage = new BitmapImage();
            Uri uriSource;

            int pictureId;

            if (lstPictures.SelectedItem.ToString() == "Robot Portrait")
            {
                pictureId = 1;
                uriSource = new Uri("Images/Avatars/RobotAvatar.jpg", UriKind.Relative);
            }
            else if (lstPictures.SelectedItem.ToString() == "Goblin Portrait")
            {
                pictureId = 2;
                uriSource = new Uri("Images/Avatars/GoblinAvatar.jpg", UriKind.Relative);
            }
            else if (lstPictures.SelectedItem.ToString() == "Knight Portrait")
            {
                pictureId = 3;
                uriSource = new Uri("Images/Avatars/KnightAvatar.jpg", UriKind.Relative);
            }
            else if (lstPictures.SelectedItem.ToString() == "QWERTY")
            {
                pictureId = 4;
                uriSource = new Uri("Images/Avatars/QwertyAvatar.jpg", UriKind.Relative);
            }
            else if (lstPictures.SelectedItem.ToString() == "More Sorting?")
            {
                pictureId = 5;
                uriSource = new Uri("Images/Avatars/ManAvatar.jpg", UriKind.Relative);
            }
            else if (lstPictures.SelectedItem.ToString() == "It'll be Fun!")
            {
                pictureId = 6;
                uriSource = new Uri("Images/Avatars/WomanAvatar.jpg", UriKind.Relative);
            }
            else if (lstPictures.SelectedItem.ToString() == "Check Out")
            {
                pictureId = 7;
                uriSource = new Uri("Images/Avatars/BookAvatar.jpg", UriKind.Relative);
            }
            else if (lstPictures.SelectedItem.ToString() == "Group Picture!")
            {
                pictureId = 8;
                uriSource = new Uri("Images/Avatars/GroupAvatar.jpg", UriKind.Relative);
            }
            else
            {
                pictureId = 0;
                uriSource = new Uri("Images/Avatars/DefaultAvatar.jpg", UriKind.Relative);
            }

            firebaseLink.ChangePicture(pictureId);
            imgDisplayPicture.Source = new BitmapImage(uriSource);
        }

        private void btnRemovePicture_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage bitmapImage = new BitmapImage();
            Uri uriSource;
            uriSource = new Uri("Images/Avatars/DefaultAvatar.jpg", UriKind.Relative);

            firebaseLink.ChangePicture(0);
            imgDisplayPicture.Source = new BitmapImage(uriSource);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu(firebaseLink);
            mainMenu.Show();
            this.Close();
        }
    }
}
