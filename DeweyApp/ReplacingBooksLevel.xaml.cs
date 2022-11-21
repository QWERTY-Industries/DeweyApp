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
    /// Interaction logic for ReplacingBooksLevel.xaml
    /// </summary>
    public partial class ReplacingBooksLevel : Window
    {
        FirebaseLink firebaseLink;
        int gamemode;

        int level;

        //string[] callNumbers;
        List<string> callNumbersList;
        int percentage;

        CallNumberOperation callNumberOperation = new CallNumberOperation();

        //Q Returns a LEVEL WINDOW with the passed: background STRING applied, FIREBASE reference applied and a level INT applied
        public ReplacingBooksLevel(string background, FirebaseLink fbl, int lvl, int mode)
        {
            InitializeComponent();
            firebaseLink = fbl;

            addUnsortedItems();

            BitmapImage bitmapImage = new BitmapImage();
            Uri UriSource = new Uri(background, UriKind.Relative);

            image.Source = new BitmapImage(UriSource);
            ImageSource newImage = image.Source;

            Background = new ImageBrush(newImage);
            image.Stretch = Stretch.Fill;

            // https://social.msdn.microsoft.com/Forums/vstudio/en-US/ab245116-547a-451f-a362-97cf17a524cf/how-to-set-background-image-in-the-button-at-runtime-in-wpf?forum=wpf

            level = lvl;

            if (firebaseLink.GetDeveloperStatus())
            {
                btnMoveAuto.Visibility = Visibility.Visible;
            }

            gamemode = mode;
        }

        //Q Checks if the User's sorting was correct. Disables and Enables Components to stop the Level from being played after
        //Q the result has been determined
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            //string[] userCallNumbers = new string[10];
            List<string> userCallNumbers = new List<string>();

            for (int i = 0; i < lsbUserSorted.Items.Count; i++)
            {
                userCallNumbers.Add(lsbUserSorted.Items[i].ToString());
            }
            //https://stackoverflow.com/questions/30774582/how-to-convert-listbox-items-to-string-of-array-collection-in-c-sharp

            //Array.Sort(callNumbers);
            //string[] sortedCallNumbers = callNumbers;

            List<string> sortedCallNumbersList = callNumbersList.OrderBy(x => x).ToList();

            percentage = callNumberOperation.compareCallNumbers(userCallNumbers, sortedCallNumbersList/*sortedCallNumbers*/);

            lsbUnsorted.Items.Clear();
            addItems();

            lblPercentage.Content = percentage + "%";
            bgPercentage.Visibility = Visibility.Visible;

            lblUnsorted.Visibility = Visibility.Hidden;
            lblSorted.Visibility = Visibility.Visible;

            lblSortTheBooks.Visibility = Visibility.Hidden;
            lblYourAnswer.Visibility = Visibility.Visible;

            btnMoveLeft.Visibility = Visibility.Hidden;
            btnMoveRight.Visibility = Visibility.Hidden;
            btnMoveUp.Visibility = Visibility.Hidden;
            btnMoveDown.Visibility = Visibility.Hidden;

            btnMoveAuto.Visibility = Visibility.Hidden; //Q TESTING PURPOSES (Can be enabled with a Unique Code)

            btnSubmit.Visibility = Visibility.Hidden;
            btnContinue.Visibility = Visibility.Visible;
        }

        //Q Exits the Level Screen. If a user has earned progress or rewards they are allocated.
        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            if (level <= 10)
            {
                if (percentage == 100)
                {
                    firebaseLink.RbLevelUp(); //MoveToNextLevel(level);

                    if (level < 10)
                    {
                        firebaseLink.AddCoins(20);
                    }
                    else
                    {
                        firebaseLink.AddCoins(220);
                    }
                }

                AdventureMap adventureMap = new AdventureMap(firebaseLink, gamemode);
                adventureMap.Show();
                this.Close();
            }
            else
            {
                if (percentage == 100)
                {
                    firebaseLink.RbLevelUp();
                    firebaseLink.AddCoins(10);
                }

                ChallengeLevels challengeLevels = new ChallengeLevels(percentage, firebaseLink, gamemode);
                challengeLevels.Show();
                this.Close();
            }
        }

        //Q FOR TESTING PURPOSES (Can be enabled with a Unique Code)
        private void btnMoveAuto_Click(object sender, RoutedEventArgs e) // TESTING PURPOSES
        {
            //Array.Sort(callNumbers);

            //string[] sortedCallNumbers = callNumbers;
            List<string> sortedCallNumbersList = callNumbersList.OrderBy(x => x.ToString()).ToList();

            for (int i = 0; i < 10; i++)
            {
                //lsbUserSorted.Items.Add(sortedCallNumbers[i]);
                lsbUserSorted.Items.Add(sortedCallNumbersList[i]);
            }

            lsbUnsorted.Items.Clear();
        }

        //Q Moves a Call Number to the ListBox on the RIGHT (User Answer)
        private void btnMoveRight_Click(object sender, RoutedEventArgs e)
        {
            System.Collections.IList selectedItems = lsbUnsorted.SelectedItems;

            if (lsbUnsorted.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                {
                    lsbUserSorted.Items.Add(selectedItems[i]);
                    lsbUnsorted.Items.Remove(selectedItems[i]);
                }
            }

            //https://stackoverflow.com/questions/13149486/delete-selected-items-from-listbox
        }

        //Q Moves a Call Number to the ListBox on the LEFT (Unsorted)
        private void btnMoveLeft_Click(object sender, RoutedEventArgs e)
        {
            System.Collections.IList selectedItems = lsbUserSorted.SelectedItems;

            if (lsbUserSorted.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                {
                    lsbUnsorted.Items.Add(selectedItems[i]);
                    lsbUserSorted.Items.Remove(selectedItems[i]);
                }
            }
        }

        //Q Moves a Call Number UP 1 slot in the ListBox on the Left (User Answer)
        private void btnMoveUp_Click(object sender, RoutedEventArgs e)
        {
            MoveItem(-1);
        }

        //Q Moves a Call Number DOWN 1 slot in the ListBox on the Left (User Answer)
        private void btnMoveDown_Click(object sender, RoutedEventArgs e)
        {
            MoveItem(1);
        }

        //Q Used to Move Items in the direction the Passed INT Specifies

        // Taken From StackOverflow
        // Authour Save
        // Year 2012
        // https://stackoverflow.com/questions/4796109/how-to-move-item-in-listbox-up-and-down
        public void MoveItem(int direction)
        {
            if (lsbUserSorted.SelectedItem == null || lsbUserSorted.SelectedIndex < 0)
                return; // No selected item - nothing to do

            // Calculate new index using move direction
            int newIndex = lsbUserSorted.SelectedIndex + direction;

            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= lsbUserSorted.Items.Count)
                return; // Index out of range - nothing to do

            object selected = lsbUserSorted.SelectedItem;

            // Removing removable element
            lsbUserSorted.Items.Remove(selected);
            // Insert it in new position
            lsbUserSorted.Items.Insert(newIndex, selected);
            // Restore selection
            //lsbUserSorted.SetSelected(newIndex, true);
        }
        //****************

        //Q Adds Unsorted Call Numbers to the ListBox on the Left
        public void addUnsortedItems()
        {
            //callNumbers = callNumberOperation.getCallNumbers();
            callNumbersList = callNumberOperation.getCallNumbers();

            for (int i = 0; i < 10; i++)
            {
                //lsbUnsorted.Items.Add(callNumbers[i]);
                lsbUnsorted.Items.Add(callNumbersList.ElementAt(i));
            }
        }

        //Q Adds Sorted Call Numbers to the ListBox on the Left
        public void addItems()
        {
            for (int i = 0; i < 10; i++)
            {
                //lsbUnsorted.Items.Add(callNumbers[i]);
                lsbUnsorted.Items.Add(callNumbersList[i]);
            }
        }
    }
}
