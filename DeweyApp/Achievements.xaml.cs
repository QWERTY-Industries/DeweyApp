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
    /// Interaction logic for Achievements.xaml
    /// </summary>
    public partial class Achievements : Window
    {
        FirebaseLink firebaseLink;

        BitmapImage bitmapImage = new BitmapImage();
        Uri uriSource;

        public Achievements(FirebaseLink fbl)
        {
            InitializeComponent();
            firebaseLink = fbl;

            bool[] obtainedAchievements = firebaseLink.GetUserAchievements();

            lstAchievements.Items.Add("Newbie");

            lstAchievements.Items.Add("Book Replacer");
            lstAchievements.Items.Add("Area Identifier");
            lstAchievements.Items.Add("Call Number Finder");

            lstAchievements.Items.Add("Robot Portrait");

            lstAchievements.Items.Add("Goblin Portrait");
            lstAchievements.Items.Add("Knight Portrait");

            lstAchievements.Items.Add("Novice Librarian");
            lstAchievements.Items.Add("Head Librarian");

            lstAchievements.Items.Add("QWERTY");

            lblTitle.Content = "Newbie";
            lblDescription.Content = "Win a Level in any Gamemode";
            lblType.Content = "BADGE";

            bool obtained = firebaseLink.GetObtained(0);

            uriSource = new Uri("Images/Badges/NewbieBadge.jpg", UriKind.Relative);

            if (obtained == true)
                lblObtained.Content = "Earned";
            else
                lblObtained.Content = "Not Earned";

            imgAchievement.Source = new BitmapImage(uriSource);
        }

        private void btnViewAchievement_Click(object sender, RoutedEventArgs e)
        {
            bool obtained;

            if (lstAchievements.SelectedItem.ToString() == "Newbie")
            {
                lblTitle.Content = "Newbie";
                lblDescription.Content = "Win a Level in any Gamemode";
                lblType.Content = "BADGE";
                obtained = firebaseLink.GetObtained(0);

                uriSource = new Uri("Images/Badges/NewbieBadge.jpg", UriKind.Relative);
            }
            else if (lstAchievements.SelectedItem.ToString() == "Book Replacer")
            {
                lblTitle.Content = "Book Replacer";
                lblDescription.Content = "Win a Replacing Books Level";
                lblType.Content = "BADGE";
                obtained = firebaseLink.GetObtained(1);

                uriSource = new Uri("Images/Badges/ProcessorBadge.jpg", UriKind.Relative);
            }
            else if (lstAchievements.SelectedItem.ToString() == "Area Identifier")
            {
                lblTitle.Content = "Area Identifter";
                lblDescription.Content = "Win an Identifying Areas Level";
                lblType.Content = "BADGE";
                obtained = firebaseLink.GetObtained(2);

                uriSource = new Uri("Images/Badges/WigBadge.jpg", UriKind.Relative);
            }
            else if (lstAchievements.SelectedItem.ToString() == "Call Number Finder")
            {
                lblTitle.Content = "Call Number Finder";
                lblDescription.Content = "Win a Finding Call Numbers Level";
                lblType.Content = "BADGE";
                obtained = firebaseLink.GetObtained(3);

                uriSource = new Uri("Images/Badges/HelmetBadge.jpg", UriKind.Relative);
            }
            else if(lstAchievements.SelectedItem.ToString() == "Robot Portrait")
            {
                lblTitle.Content = "Robot Portrait";
                lblDescription.Content = "Complete the Replacing Books Adventure Map";
                lblType.Content = "AVATAR";
                obtained = firebaseLink.GetObtained(4);

                uriSource = new Uri("Images/Avatars/RobotAvatar.jpg", UriKind.Relative);
            }
            else if (lstAchievements.SelectedItem.ToString() == "Goblin Portrait")
            {
                lblTitle.Content = "Goblin Portrait";
                lblDescription.Content = "Complete the Identifying Areas Adventure Map";
                lblType.Content = "AVATAR";
                obtained = firebaseLink.GetObtained(5);

                uriSource = new Uri("Images/Avatars/GoblinAvatar.jpg", UriKind.Relative);
            }
            else if (lstAchievements.SelectedItem.ToString() == "Knight Portrait")
            {
                lblTitle.Content = "Knight Portrait";
                lblDescription.Content = "Complete the Finding Call Numbers Adventure Map";
                lblType.Content = "AVATAR";
                obtained = firebaseLink.GetObtained(6);

                uriSource = new Uri("Images/Avatars/KnightAvatar.jpg", UriKind.Relative);
            }
            else if (lstAchievements.SelectedItem.ToString() == "Novice Librarian")
            {
                lblTitle.Content = "Novice Librarian";
                lblDescription.Content = "Complete Every Adventure Map";
                lblType.Content = "BADGE";
                obtained = firebaseLink.GetObtained(7);

                uriSource = new Uri("Images/Badges/NoviceBadge.jpg", UriKind.Relative);
            }
            else if (lstAchievements.SelectedItem.ToString() == "Head Librarian")
            {
                lblTitle.Content = "Head Librarian";
                lblDescription.Content = "Complete a Total of 30 Challenge Levels in any Gamemode";
                lblType.Content = "BADGE";
                obtained = firebaseLink.GetObtained(8);

                uriSource = new Uri("Images/Badges/HeadBadge.jpg", UriKind.Relative);
            }
            else if (lstAchievements.SelectedItem.ToString() == "QWERTY")
            {
                lblTitle.Content = "QWERTY";
                lblDescription.Content = "Congratulations you are a Developer!";
                lblType.Content = "AVATAR";
                obtained = firebaseLink.GetObtained(9);

                uriSource = new Uri("Images/Avatars/QwertyAvatar.jpg", UriKind.Relative);
            }
            else
                obtained = false;

            if (obtained == true)
                lblObtained.Content = "Earned";
            else
                lblObtained.Content = "Not Earned";

            imgAchievement.Source = new BitmapImage(uriSource);
        }

        private void btnCheckAchievement_Click(object sender, RoutedEventArgs e)
        {
            int userRbLevel = firebaseLink.getUserLevel(0);
            int userIaLevel = firebaseLink.getUserLevel(1);
            int userFcnLevel = firebaseLink.getUserLevel(2);

            int userTotalLevel = firebaseLink.getUserTotalLevel();

            if (lstAchievements.SelectedItem.ToString() == "Newbie")
            {
                if (userTotalLevel >= 1)
                {
                    firebaseLink.Obtain(0);
                    lblObtained.Content = "Earned";
                }
                else
                {
                    MessageBox.Show("You have not completed any Levels yet", "Achievement not Completed");
                }
            }
            else if (lstAchievements.SelectedItem.ToString() == "Book Replacer")
            {
                if (userRbLevel >= 1)
                {
                    firebaseLink.Obtain(1);
                    lblObtained.Content = "Earned";
                }
                else
                {
                    MessageBox.Show("You have not completed a Replacing Books Level yet", "Achievement not Completed");
                }
            }
            else if (lstAchievements.SelectedItem.ToString() == "Area Identifier")
            {
                if (userIaLevel >= 1)
                {
                    firebaseLink.Obtain(2);
                    lblObtained.Content = "Earned";
                }
                else
                {
                    MessageBox.Show("You have not completed an Identifying Areas Level yet", "Achievement not Completed");
                }
            }
            else if (lstAchievements.SelectedItem.ToString() == "Call Number Finder")
            {
                if (userFcnLevel >= 1)
                {
                    firebaseLink.Obtain(3);
                    lblObtained.Content = "Earned";
                }
                else
                {
                    MessageBox.Show("You have not completed a Finding Call Numbers Level yet", "Achievement not Completed");
                }
            }
            else if (lstAchievements.SelectedItem.ToString() == "Robot Portrait")
            {
                if (userRbLevel >= 10)
                {
                    firebaseLink.Obtain(4);
                    lblObtained.Content = "Earned";
                }
                else
                {
                    MessageBox.Show("You have not completed the Replacing Books Adventure Map yet", "Achievement not Completed");
                }
            }
            else if (lstAchievements.SelectedItem.ToString() == "Goblin Portrait")
            {
                if (userIaLevel >= 10)
                {
                    firebaseLink.Obtain(5);
                    lblObtained.Content = "Earned";
                }
                else
                {
                    MessageBox.Show("You have not completed the Identifying Areas Adventure Map yet", "Achievement not Completed");
                }
            }
            else if (lstAchievements.SelectedItem.ToString() == "Knight Portrait")
            {
                if (userFcnLevel >= 10)
                {
                    firebaseLink.Obtain(6);
                    lblObtained.Content = "Earned";
                }
                else
                {
                    MessageBox.Show("You have not completed the Finding Call Numbers Adventure Map yet", "Achievement not Completed");
                }
            }
            else if (lstAchievements.SelectedItem.ToString() == "Novice Librarian")
            {
                if (userRbLevel >= 10 && userIaLevel >= 10 && userFcnLevel >= 10)
                {
                    firebaseLink.Obtain(7);
                    lblObtained.Content = "Earned";
                }
                else
                {
                    MessageBox.Show("You have not completed Every Adventure Map yet", "Achievement not Completed");
                }
            }
            else if (lstAchievements.SelectedItem.ToString() == "Head Librarian")
            {
                int challengeLevelsCompleted = 0;

                if (userRbLevel >= 10)
                {
                    challengeLevelsCompleted = challengeLevelsCompleted + userRbLevel - 10;
                }
                if (userIaLevel >= 10)
                {
                    challengeLevelsCompleted = challengeLevelsCompleted + userIaLevel - 10;
                }
                if (userFcnLevel >= 10)
                {
                    challengeLevelsCompleted = challengeLevelsCompleted + userFcnLevel - 10;
                }

                if (challengeLevelsCompleted >= 30)
                {
                    firebaseLink.Obtain(8);
                    lblObtained.Content = "Earned";
                }
                else
                {
                    MessageBox.Show("You have not completed 30 Challenge Levels yet", "Achievement not Completed");
                }
            }
            else if (lstAchievements.SelectedItem.ToString() == "QWERTY")
            {
                if (firebaseLink.GetDeveloperStatus())
                {
                    firebaseLink.Obtain(9);
                    lblObtained.Content = "Earned";
                }
                else
                {
                    MessageBox.Show("What? You think I'm gonna tell you the code? xD", "Achievement not Completed");
                }
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
