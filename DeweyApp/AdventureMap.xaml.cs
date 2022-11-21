using DeweyApp.MVVM.Model;
using DeweyApp.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
    /// Interaction logic for AdventureMap.xaml
    /// </summary>
    public partial class AdventureMap : Window
    {
        FirebaseLink firebaseLink;
        int gamemode;

        int userLevel;

        public AdventureMap(FirebaseLink fbl, int mode)
        {
            InitializeComponent();
            firebaseLink = fbl;
            gamemode = mode;

            //if (gamemode == 0)
            //{
            //    // Taken From StackOverflow
            //    // Authour Gaessaki
            //    // Year 2015
            //    // https://stackoverflow.com/questions/28437096/how-do-i-programmatically-change-the-title-in-a-wpf-window
            //    this.Title = "Replacing Books Adventure Map";
            //    //****************
            //}
            //else if (gamemode == 1)
            //{
            //    this.Title = "Identifying Areas Adventure Map";
            //}
            //else
            //{
            //    this.Title = "Finding Call Numbers Adventure Map";
            //}

            BitmapImage bitmapImage = new BitmapImage();
            Uri UriSource;

            userLevel = firebaseLink.getUserLevel(gamemode);

            if (gamemode == 0)
            {
                // Taken From StackOverflow
                // Authour Gaessaki
                // Year 2015
                // https://stackoverflow.com/questions/28437096/how-do-i-programmatically-change-the-title-in-a-wpf-window
                this.Title = "Replacing Books Adventure Map";
                //****************

                UriSource = new Uri("Images/ReplacingBooksBackgrounds/AdventureMapA.jpg", UriKind.Relative);
            }
            else if (gamemode == 1)
            {
                this.Title = "Identifying Areas Adventure Map";

                UriSource = new Uri("Images/IdentifyingAreasBackgrounds/AdventureMapB.jpg", UriKind.Relative);
            }
            else
            {
                this.Title = "Finding Call Numbers Adventure Map";

                UriSource = new Uri("Images/FindingCallNumbersBackgrounds/AdventureMapC.jpg", UriKind.Relative);
            }

            image.Source = new BitmapImage(UriSource);
            ImageSource newImage = image.Source;

            Background = new ImageBrush(newImage);
            image.Stretch = Stretch.Fill;

            if (userLevel >= 1)
            {
                btnTwo.Visibility = Visibility.Visible;
                if (userLevel >= 2)
                {
                    btnThree.Visibility = Visibility.Visible;
                    if (userLevel >= 3)
                    {
                        btnFour.Visibility = Visibility.Visible;
                        if (userLevel >= 4)
                        {
                            btnFive.Visibility = Visibility.Visible;
                            if (userLevel >= 5)
                            {
                                btnSix.Visibility = Visibility.Visible;
                                if (userLevel >= 6)
                                {
                                    btnSeven.Visibility = Visibility.Visible;
                                    if (userLevel >= 7)
                                    {
                                        btnEight.Visibility = Visibility.Visible;
                                        if (userLevel >= 8)
                                        {
                                            btnNine.Visibility = Visibility.Visible;
                                            if (userLevel >= 9)
                                            {
                                                btnTen.Visibility = Visibility.Visible;
                                                if (userLevel >= 10)
                                                {
                                                    btnOutro.Visibility = Visibility.Visible;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnIntro_Click(object sender, RoutedEventArgs e)
        {
            Comic comic;

            if (gamemode == 0)
            {
                comic = new Comic("Images/Comics/IntroA.jpg", firebaseLink, gamemode);
            }
            else if (gamemode == 1)
            {
                comic = new Comic("Images/Comics/IntroA.jpg", firebaseLink, gamemode);
            }
            else
            {
                comic = new Comic("Images/Comics/IntroC.jpg", firebaseLink, gamemode);
            }

            comic.Show();
            this.Close();
        }

        private void btnOutro_Click(object sender, RoutedEventArgs e)
        {
            Comic comic;

            if (gamemode == 0)
            {
                comic = new Comic("Images/Comics/OutroA.jpg", firebaseLink, gamemode);
            }
            else if (gamemode == 1)
            {
                comic = new Comic("Images/Comics/OutroA.jpg", firebaseLink, gamemode);
            }
            else
            {
                comic = new Comic("Images/Comics/OutroC.jpg", firebaseLink, gamemode);
            }

            comic.Show();
            this.Close();
        }

        private void btnOne_Click(object sender, RoutedEventArgs e)
        {
            if (userLevel == 0)
            {
                if (gamemode == 0)
                {
                    ReplacingBooksLevel level = new ReplacingBooksLevel("Images/ReplacingBooksBackgrounds/Level1a.jpg", firebaseLink, 1, gamemode);
                    level.Show();
                }
                else if (gamemode == 1)
                {
                    IdentifyingAreasLevel level = new IdentifyingAreasLevel("Images/IdentifyingAreasBackgrounds/Level1b.jpg", firebaseLink, 1, gamemode);
                    level.Show();
                }
                else
                {
                    FindingCallNumbersLevel level = new FindingCallNumbersLevel("Images/FindingCallNumbersBackgrounds/Level1c.jpeg", firebaseLink, 1, gamemode);
                    level.Show();
                }
                
                this.Close();
            }
            else
            {
                MessageBox.Show("You Cannot Replay Adventure Map Levels", "Level 1 Completed!");
            }
        }

        private void btnTwo_Click(object sender, RoutedEventArgs e)
        {
            if (userLevel == 1)
            {
                if (gamemode == 0)
                {
                    ReplacingBooksLevel level = new ReplacingBooksLevel("Images/ReplacingBooksBackgrounds/Level2a.jpg", firebaseLink, 2, gamemode);
                    level.Show();
                }
                else if (gamemode == 1)
                {
                    IdentifyingAreasLevel level = new IdentifyingAreasLevel("Images/IdentifyingAreasBackgrounds/Level2b.jpeg", firebaseLink, 2, gamemode);
                    level.Show();
                }
                else
                {
                    FindingCallNumbersLevel level = new FindingCallNumbersLevel("Images/FindingCallNumbersBackgrounds/Level2c.jpeg", firebaseLink, 2, gamemode);
                    level.Show();
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("You Cannot Replay Adventure Map Levels", "Level 2 Completed!");
            }
        }

        private void btnThree_Click(object sender, RoutedEventArgs e)
        {
            if (userLevel == 2)
            {
                if (gamemode == 0)
                {
                    ReplacingBooksLevel level = new ReplacingBooksLevel("Images/ReplacingBooksBackgrounds/Level3a.jpg", firebaseLink, 3, gamemode);
                    level.Show();
                }
                else if (gamemode == 1)
                {
                    IdentifyingAreasLevel level = new IdentifyingAreasLevel("Images/IdentifyingAreasBackgrounds/Level3b.jpg", firebaseLink, 3, gamemode);
                    level.Show();
                }
                else
                {
                    FindingCallNumbersLevel level = new FindingCallNumbersLevel("Images/FindingCallNumbersBackgrounds/Level3c.jpeg", firebaseLink, 3, gamemode);
                    level.Show();
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("You Cannot Replay Adventure Map Levels", "Level 1 Completed!");
            }
        }

        private void btnFour_Click(object sender, RoutedEventArgs e)
        {
            if (userLevel == 3)
            {
                if (gamemode == 0)
                {
                    ReplacingBooksLevel level = new ReplacingBooksLevel("Images/ReplacingBooksBackgrounds/Level4a.jpg", firebaseLink, 4, gamemode);
                    level.Show();
                }
                else if (gamemode == 1)
                {
                    IdentifyingAreasLevel level = new IdentifyingAreasLevel("Images/IdentifyingAreasBackgrounds/Level4b.jpeg", firebaseLink, 4, gamemode);
                    level.Show();
                }
                else
                {
                    FindingCallNumbersLevel level = new FindingCallNumbersLevel("Images/FindingCallNumbersBackgrounds/Level4c.jpeg", firebaseLink, 4, gamemode);
                    level.Show();
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("You Cannot Replay Adventure Map Levels", "Level 1 Completed!");
            }
        }

        private void btnFive_Click(object sender, RoutedEventArgs e)
        {
            if (userLevel == 4)
            {
                if (gamemode == 0)
                {
                    ReplacingBooksLevel level = new ReplacingBooksLevel("Images/ReplacingBooksBackgrounds/Level5a.jpg", firebaseLink, 5, gamemode);
                    level.Show();
                }
                else if (gamemode == 1)
                {
                    IdentifyingAreasLevel level = new IdentifyingAreasLevel("Images/IdentifyingAreasBackgrounds/Level5b.jpeg", firebaseLink, 5, gamemode);
                    level.Show();
                }
                else
                {
                    FindingCallNumbersLevel level = new FindingCallNumbersLevel("Images/FindingCallNumbersBackgrounds/Level5c.jpeg", firebaseLink, 5, gamemode);
                    level.Show();
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("You Cannot Replay Adventure Map Levels", "Level 5 Completed!");
            }
        }

        private void btnSix_Click(object sender, RoutedEventArgs e)
        {
            if (userLevel == 5)
            {
                if (gamemode == 0)
                {
                    ReplacingBooksLevel level = new ReplacingBooksLevel("Images/ReplacingBooksBackgrounds/Level6a.jpg", firebaseLink, 6, gamemode);
                    level.Show();
                }
                else if (gamemode == 1)
                {
                    IdentifyingAreasLevel level = new IdentifyingAreasLevel("Images/IdentifyingAreasBackgrounds/Level6b.jpeg", firebaseLink, 6, gamemode);
                    level.Show();
                }
                else
                {
                    FindingCallNumbersLevel level = new FindingCallNumbersLevel("Images/FindingCallNumbersBackgrounds/Level6c.jpeg", firebaseLink, 6, gamemode);
                    level.Show();
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("You Cannot Replay Adventure Map Levels", "Level 6 Completed!");
            }
        }

        private void btnSeven_Click(object sender, RoutedEventArgs e)
        {
            if (userLevel == 6)
            {
                if (gamemode == 0)
                {
                    ReplacingBooksLevel level = new ReplacingBooksLevel("Images/ReplacingBooksBackgrounds/Level7a.jpg", firebaseLink, 7, gamemode);
                    level.Show();
                }
                else if (gamemode == 1)
                {
                    IdentifyingAreasLevel level = new IdentifyingAreasLevel("Images/IdentifyingAreasBackgrounds/Level7b.jpeg", firebaseLink, 7, gamemode);
                    level.Show();
                }
                else
                {
                    FindingCallNumbersLevel level = new FindingCallNumbersLevel("Images/FindingCallNumbersBackgrounds/Level7c.jpeg", firebaseLink, 7, gamemode);
                    level.Show();
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("You Cannot Replay Adventure Map Levels", "Level 7 Completed!");
            }
        }

        private void btnEight_Click(object sender, RoutedEventArgs e)
        {
            if (userLevel == 7)
            {
                if (gamemode == 0)
                {
                    ReplacingBooksLevel level = new ReplacingBooksLevel("Images/ReplacingBooksBackgrounds/Level8a.jpg", firebaseLink, 8, gamemode);
                    level.Show();
                }
                else if (gamemode == 1)
                {
                    IdentifyingAreasLevel level = new IdentifyingAreasLevel("Images/IdentifyingAreasBackgrounds/Level8b.jpeg", firebaseLink, 8, gamemode);
                    level.Show();
                }
                else
                {
                    FindingCallNumbersLevel level = new FindingCallNumbersLevel("Images/FindingCallNumbersBackgrounds/Level8c.jpeg", firebaseLink, 8, gamemode);
                    level.Show();
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("You Cannot Replay Adventure Map Levels", "Level 8 Completed!");
            }
        }

        private void btnNine_Click(object sender, RoutedEventArgs e)
        {
            if (userLevel == 8)
            {
                if (gamemode == 0)
                {
                    ReplacingBooksLevel level = new ReplacingBooksLevel("Images/ReplacingBooksBackgrounds/Level9a.jpg", firebaseLink, 9, gamemode);
                    level.Show();
                }
                else if (gamemode == 1)
                {
                    IdentifyingAreasLevel level = new IdentifyingAreasLevel("Images/IdentifyingAreasBackgrounds/Level9b.jpeg", firebaseLink, 9, gamemode);
                    level.Show();
                }
                else
                {
                    FindingCallNumbersLevel level = new FindingCallNumbersLevel("Images/FindingCallNumbersBackgrounds/Level9c.jpeg", firebaseLink, 9, gamemode);
                    level.Show();
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("You Cannot Replay Adventure Map Levels", "Level 9 Completed!");
            }
        }

        private void btnTen_Click(object sender, RoutedEventArgs e)
        {
            if (userLevel == 9)
            {
                if (gamemode == 0)
                {
                    ReplacingBooksLevel level = new ReplacingBooksLevel("Images/ReplacingBooksBackgrounds/Level10a.jpg", firebaseLink, 10, gamemode);
                    level.Show();
                }
                else if (gamemode == 1)
                {
                    IdentifyingAreasLevel level = new IdentifyingAreasLevel("Images/IdentifyingAreasBackgrounds/Level10b.jpg", firebaseLink, 10, gamemode);
                    level.Show();
                }
                else
                {
                    FindingCallNumbersLevel level = new FindingCallNumbersLevel("Images/FindingCallNumbersBackgrounds/Level10c.jpeg", firebaseLink, 10, gamemode);
                    level.Show();
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("You Cannot Replay Adventure Map Levels", "Level 10 Completed!");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            SubMenu subMenu = new SubMenu(firebaseLink, gamemode);
            subMenu.Show();
            this.Close();
        }
    }
}
