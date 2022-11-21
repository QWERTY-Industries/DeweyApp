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
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DeweyApp
{
    /// <summary>
    /// Interaction logic for ChallengeLevels.xaml
    /// </summary>
    public partial class ChallengeLevels : Window
    {
        FirebaseLink firebaseLink;
        int gamemode;

        string[] rbBackgrounds = { "Images/ReplacingBooksBackgrounds/Level1a.jpg", "Images/ReplacingBooksBackgrounds/Level2a.jpg",
            "Images/ReplacingBooksBackgrounds/Level3a.jpg", "Images/ReplacingBooksBackgrounds/Level4a.jpg", "Images/ReplacingBooksBackgrounds/Level5a.jpg",
        "Images/ReplacingBooksBackgrounds/Level6a.jpg", "Images/ReplacingBooksBackgrounds/Level7a.jpg", "Images/ReplacingBooksBackgrounds/Level8a.jpg",
        "Images/ReplacingBooksBackgrounds/Level9a.jpg", "Images/ReplacingBooksBackgrounds/Level10a.jpg"};

        string[] iaBackgrounds = { "Images/IdentifyingAreasBackgrounds/Level1b.jpg", "Images/IdentifyingAreasBackgrounds/Level2b.jpeg",
            "Images/IdentifyingAreasBackgrounds/Level3b.jpg", "Images/IdentifyingAreasBackgrounds/Level4b.jpeg", "Images/IdentifyingAreasBackgrounds/Level5b.jpeg",
        "Images/IdentifyingAreasBackgrounds/Level6b.jpeg", "Images/IdentifyingAreasBackgrounds/Level7b.jpeg", "Images/IdentifyingAreasBackgrounds/Level8b.jpeg",
        "Images/IdentifyingAreasBackgrounds/Level9b.jpeg", "Images/IdentifyingAreasBackgrounds/Level10b.jpg"};

        string[] fcnBackgrounds = { "Images/FindingCallNumbersBackgrounds/Level1c.jpeg", "Images/FindingCallNumbersBackgrounds/Level2c.jpeg",
            "Images/FindingCallNumbersBackgrounds/Level3c.jpeg", "Images/FindingCallNumbersBackgrounds/Level4c.jpeg", "Images/FindingCallNumbersBackgrounds/Level5c.jpeg",
        "Images/FindingCallNumbersBackgrounds/Level6c.jpeg", "Images/FindingCallNumbersBackgrounds/Level7c.jpeg", "Images/FindingCallNumbersBackgrounds/Level8c.jpeg",
        "Images/FindingCallNumbersBackgrounds/Level9c.jpeg", "Images/FindingCallNumbersBackgrounds/Level10c.jpeg"};

        Random random = new Random();

        public ChallengeLevels(int percentage, FirebaseLink fbl, int mode)
        {
            InitializeComponent();
            firebaseLink = fbl;

            lblPercentage.Content = percentage + "%";

            if (percentage == 100)
            {
                lblCoins.Content = "+10 Coins";
            }

            firebaseLink = fbl;
            gamemode = mode;

            //if (gamemode == 0)
            //{
            //    // Taken From StackOverflow
            //    // Authour Gaessaki
            //    // Year 2015
            //    // https://stackoverflow.com/questions/28437096/how-do-i-programmatically-change-the-title-in-a-wpf-window
            //    this.Title = "Replacing Books Challenge Levels";
            //    //****************
            //}
            //else if (gamemode == 1)
            //{
            //    this.Title = "Identifying Areas Challenge Levels";
            //}
            //else
            //{
            //    this.Title = "Finding Call Numbers Challenge Levels";
            //}

            BitmapImage bitmapImage = new BitmapImage();
            Uri UriSource;

            if (gamemode == 0)
            {
                // Taken From StackOverflow
                // Authour Gaessaki
                // Year 2015
                // https://stackoverflow.com/questions/28437096/how-do-i-programmatically-change-the-title-in-a-wpf-window
                this.Title = "Replacing Books Challenge Levels";
                //****************

                UriSource = new Uri("Images/ReplacingBooksBackgrounds/ChallengeLevelsA.jpg", UriKind.Relative);
            }
            else if (gamemode == 1)
            {
                this.Title = "Identifying Areas Challenge Levels";

                UriSource = new Uri("Images/IdentifyingAreasBackgrounds/ChallengeLevelsB.jpg", UriKind.Relative);
            }
            else
            {
                this.Title = "Finding Call Numbers Challenge Levels";

                UriSource = new Uri("Images/FindingCallNumbersBackgrounds/ChallengeLevelsC.jpg", UriKind.Relative);
            }

            image.Source = new BitmapImage(UriSource);
            ImageSource newImage = image.Source;

            Background = new ImageBrush(newImage);
            image.Stretch = Stretch.Fill;
        }

        public ChallengeLevels(FirebaseLink fbl, int mode)
        {
            InitializeComponent();
            firebaseLink = fbl;
            gamemode = mode;

            BitmapImage bitmapImage = new BitmapImage();
            Uri UriSource;

            if (gamemode == 0)
            {
                // Taken From StackOverflow
                // Authour Gaessaki
                // Year 2015
                // https://stackoverflow.com/questions/28437096/how-do-i-programmatically-change-the-title-in-a-wpf-window
                this.Title = "Replacing Books Challenge Levels";
                //****************

                UriSource = new Uri("Images/ReplacingBooksBackgrounds/ChallengeLevelsA.jpg", UriKind.Relative);
            }
            else if (gamemode == 1)
            {
                this.Title = "Identifying Areas Challenge Levels";

                UriSource = new Uri("Images/IdentifyingAreasBackgrounds/ChallengeLevelsB.jpg", UriKind.Relative);
            }
            else
            {
                this.Title = "Finding Call Numbers Challenge Levels";

                UriSource = new Uri("Images/FindingCallNumbersBackgrounds/ChallengeLevelsC.jpg", UriKind.Relative);
            }

            image.Source = new BitmapImage(UriSource);
            ImageSource newImage = image.Source;

            Background = new ImageBrush(newImage);
            image.Stretch = Stretch.Fill;
        }

        //private void btnPlay_Click(object sender, RoutedEventArgs e)
        //{
        //    Level level = new Level("/Images/ComputerScience.jpg", firebaseLink, 11);
        //    level.Show();
        //    this.Close();
        //}

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            int randomPosition = random.Next(10);
            string background;

            if (gamemode == 0)
            {
                background = rbBackgrounds[randomPosition];
                ReplacingBooksLevel level = new ReplacingBooksLevel(background, firebaseLink, 11, gamemode);
                level.Show();
            }
            else if (gamemode == 1)
            {
                background = iaBackgrounds[randomPosition];
                IdentifyingAreasLevel level = new IdentifyingAreasLevel(background, firebaseLink, 11, gamemode);
                level.Show();
            }
            else
            {
                background = fcnBackgrounds[randomPosition];
                FindingCallNumbersLevel level = new FindingCallNumbersLevel(background, firebaseLink, 11, gamemode);
                level.Show();
            }

            this.Close();

            //https://www.c-sharpcorner.com/article/how-to-select-a-random-string-from-an-array-of-strings/
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            SubMenu subMenu = new SubMenu(firebaseLink, gamemode);
            subMenu.Show();
            this.Close();
        }
    }
}
