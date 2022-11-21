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
    /// Interaction logic for Comic.xaml
    /// </summary>
    public partial class Comic : Window
    {
        FirebaseLink firebaseLink;
        int gamemode;

        public Comic(string background, FirebaseLink fbl, int mode)
        {
            InitializeComponent();
            firebaseLink = fbl;
            gamemode = mode;

            BitmapImage bitmapImage = new BitmapImage();
            Uri UriSource = new Uri(background, UriKind.Relative);

            image.Source = new BitmapImage(UriSource);
            ImageSource newImage = image.Source;

            Background = new ImageBrush(newImage);
            image.Stretch = Stretch.Fill;

            //https://social.msdn.microsoft.com/Forums/vstudio/en-US/ab245116-547a-451f-a362-97cf17a524cf/how-to-set-background-image-in-the-button-at-runtime-in-wpf?forum=wpf
        }
        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            AdventureMap adventureMap = new AdventureMap(firebaseLink, gamemode);
            adventureMap.Show();
            this.Close();
        }
    }
}
