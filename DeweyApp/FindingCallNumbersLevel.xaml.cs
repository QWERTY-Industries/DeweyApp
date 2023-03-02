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
    /// Interaction logic for FindingCallNumbersLevel.xaml
    /// </summary>
    public partial class FindingCallNumbersLevel : Window
    {
        FirebaseLink firebaseLink;
        int gamemode;

        int level;

        int percentage;

        TreeLink treeLink = new TreeLink();

        string onePositionId;

        public FindingCallNumbersLevel(string background, FirebaseLink fbl, int lvl, int mode)
        {
            InitializeComponent();

            firebaseLink = fbl;
            level = lvl;
            gamemode = mode;

            treeLink.ReadFromFile();

            Category TopLevelCategory;
            Category MiddleLevelCategory;
            Category BottomLevelCategory;

            //string randomLevel3Position = treeLink.RandomLevel3Position();

            //Category randomTopLevelCategory = treeLink.Level3PositionFromTree(randomLevel3Position);
            //lblBottomTitle.Content = randomTopLevelCategory.name;

            //string firstNumber = randomLevel3Position.Substring(0, 1);
            //string secondNumber = randomLevel3Position.Substring(1, 1);
            //string thirdNumber = randomLevel3Position.Substring(2, 1);

            // Selects a Random Position at each Level /////////////
            string[] fourPositionsLevel1 = treeLink.NumberGenerator4from7();
            string onePositionLevel1 = fourPositionsLevel1[0];

            string[] fourPositionsLevel2 = treeLink.NumberGenerator4from10();
            string onePositionLevel2 = fourPositionsLevel2[0];

            string[] fourPositionsLevel3 = treeLink.NumberGenerator4from4();
            string onePositionLevel3 = fourPositionsLevel3[0];

            //List<string> fourPositionsIds = new List<string>;

            //for (int i = 0; i < 4; i++)
            //{
            //    fourPositionsIds.Add(fourPositionsLevel1[i] + "" + fourPositionsLevel2[i] + "" + fourPositionsLevel3[i]);
            //}

            //string onePositionId = fourPositionsIds[0];

            onePositionId = fourPositionsLevel1[0] + fourPositionsLevel2[0] + fourPositionsLevel3[0];
            string name = treeLink.FindCategory(onePositionId, 3).name;
            lblBottomCategory.Content = name;

            //List<string> shuffledPositionsIds = fourPositionsIds.OrderBy(x => Guid.NewGuid()).ToList();

            List<string> shuffledLevel1Ids = fourPositionsLevel1.OrderBy(x => Guid.NewGuid()).ToList();
            List<string> shuffledLevel2Ids = fourPositionsLevel2.OrderBy(x => Guid.NewGuid()).ToList();
            List<string> shuffledLevel3Ids = fourPositionsLevel3.OrderBy(x => Guid.NewGuid()).ToList();

            for (int i = 0; i < 4; i++)
            {
                TopLevelCategory = treeLink.RandomLevel1FromTree(shuffledLevel1Ids.ElementAt(i));
                lsbTopLevelCategories.Items.Add(TopLevelCategory.id + " - " + TopLevelCategory.name);

                MiddleLevelCategory = treeLink.RandomLevel2FromTree(shuffledLevel1Ids.ElementAt(i), shuffledLevel2Ids.ElementAt(i));
                lsbMiddleLevelCategories.Items.Add(MiddleLevelCategory.id + " - " + MiddleLevelCategory.name);

                BottomLevelCategory = treeLink.RandomLevel3FromTree(shuffledLevel1Ids.ElementAt(i), shuffledLevel2Ids.ElementAt(i), shuffledLevel3Ids.ElementAt(i));
                lsbBottomLevelCategories.Items.Add(BottomLevelCategory.name);
            }

            //for (int i = 0; i < 3; i++)
            //{
            //    TopLevelCategory = treeLink.RandomLevel1FromTree(firstNumber);
            //    lsbTopLevelCategories.Items.Add(TopLevelCategory.id + " - " + TopLevelCategory.name);

            //    MiddleLevelCategory = treeLink.RandomLevel2FromTree(firstNumber, secondNumber);
            //    lsbMiddleLevelCategories.Items.Add(MiddleLevelCategory.id + " - " + MiddleLevelCategory.name);

            //    BottomLevelCategory = treeLink.RandomLevel3FromTree(firstNumber, secondNumber, thirdNumber);
            //    lsbBottomLevelCategories.Items.Add(BottomLevelCategory.id + " - " + BottomLevelCategory.name);
            //}

            BitmapImage bitmapImage = new BitmapImage();
            Uri UriSource = new Uri(background, UriKind.Relative);

            image.Source = new BitmapImage(UriSource);
            ImageSource newImage = image.Source;

            Background = new ImageBrush(newImage);
            image.Stretch = Stretch.Fill;

            // https://social.msdn.microsoft.com/Forums/vstudio/en-US/ab245116-547a-451f-a362-97cf17a524cf/how-to-set-background-image-in-the-button-at-runtime-in-wpf?forum=wpf
        }

        private void btnConfirmTop_Click(object sender, RoutedEventArgs e)
        {
            System.Collections.IList selectedItems = lsbTopLevelCategories.SelectedItems;
            string userAnswer = selectedItems.ToString().Substring(0, 3);
            string correctAnswer = treeLink.FindCategory(onePositionId, 1).id;

            if (userAnswer == correctAnswer)
            {
                lsbTopLevelCategories.Visibility = Visibility.Hidden;
                lblTopSelection.Content = userAnswer;
                lblTopSelection.Visibility = Visibility.Visible;

                lsbMiddleLevelCategories.Visibility = Visibility.Visible;
                btnConfirmMiddle.Visibility = Visibility.Visible;

                btnConfirmTop.Visibility = Visibility.Hidden;
            }
            else
            {
                lsbTopLevelCategories.Visibility= Visibility.Hidden;

                lblPercentage.Content = "0%";
                btnContinue.Visibility = Visibility.Hidden;
                btnConfirmTop.Visibility = Visibility.Hidden;
            }
        }

        private void btnConfirmMiddle_Click(object sender, RoutedEventArgs e)
        {
            System.Collections.IList selectedItems = lsbMiddleLevelCategories.SelectedItems;
            string correctAnswer = treeLink.FindCategory(onePositionId, 1).id;

            //string userAnswer = lsbMiddleLevelCategories.Items[0].ToString().Substring(0, 3);

            string userAnswerOLD = selectedItems.ToString().Substring(0, 3);

            if (lsbMiddleLevelCategories.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                {
                    string userAnswer = lsbMiddleLevelCategories.Items[0].ToString().Substring(0, 3);
                    if (lsbMiddleLevelCategories.Items[i].ToString().Substring(0, 3) == correctAnswer)
                    {
                        lsbMiddleLevelCategories.Visibility = Visibility.Hidden;
                        btnConfirmMiddle.Visibility = Visibility.Hidden;
                        lblMiddleSelection.Content = lsbMiddleLevelCategories.Items[0].ToString();
                        lblMiddleSelection.Visibility = Visibility.Visible;

                        lsbBottomLevelCategories.Visibility = Visibility.Visible;
                        btnConfirmBottom.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        lsbTopLevelCategories.Visibility = Visibility.Hidden;
                        btnConfirmTop.Visibility = Visibility.Hidden;

                        lsbMiddleLevelCategories.Visibility = Visibility.Hidden;
                        btnConfirmMiddle.Visibility = Visibility.Hidden;

                        lblPercentage.Content = "33%";
                        btnContinue.Visibility = Visibility.Visible;
                    }
                }
            }

            //https://stackoverflow.com/questions/13149486/delete-selected-items-from-listbox
            
            //System.Collections.IList selectedItems = lsbMiddleLevelCategories.SelectedItems;
            //string userAnswer = selectedItems.ToString().Substring(0, 3);
            //string correctAnswer = treeLink.FindCategory(onePositionId, 1).id;

            //if (userAnswer == correctAnswer)
            //{
            //    lsbMiddleLevelCategories.Visibility = Visibility.Hidden;
            //    btnConfirmMiddle.Visibility = Visibility.Hidden;
            //    lblMiddleSelection.Content = userAnswer;
            //    lblMiddleSelection.Visibility = Visibility.Visible;

            //    lsbBottomLevelCategories.Visibility = Visibility.Visible;
            //    btnConfirmBottom.Visibility = Visibility.Visible;
            //}
            //else
            //{
            //    lsbTopLevelCategories.Visibility = Visibility.Hidden;
            //    btnConfirmTop.Visibility = Visibility.Hidden;

            //    lsbMiddleLevelCategories.Visibility = Visibility.Hidden;
            //    btnConfirmMiddle.Visibility= Visibility.Hidden;

            //    lblPercentage.Content = "33%";
            //    btnContinue.Visibility = Visibility.Visible;
            //}
        }

        private void btnConfirmBottom_Click(object sender, RoutedEventArgs e)
        {
            System.Collections.IList selectedItems = lsbTopLevelCategories.SelectedItems;
            string userAnswer = selectedItems.ToString().Substring(0, 3);
            string correctAnswer = treeLink.FindCategory(onePositionId, 1).id;

            if (userAnswer == correctAnswer)
            {
                lsbBottomLevelCategories.Visibility = Visibility.Hidden;
                btnConfirmBottom.Visibility = Visibility.Hidden;
                lblTopSelection.Content = userAnswer;
                lblTopSelection.Visibility = Visibility.Visible;

                lblPercentage.Content = "100%";
                lblPercentage.Visibility = Visibility.Visible;
                btnContinue.Visibility= Visibility.Visible;
            }
            else
            {
                lsbTopLevelCategories.Visibility = Visibility.Hidden;
                btnConfirmTop.Visibility = Visibility.Hidden;

                lblPercentage.Content = "66%";
                btnContinue.Visibility = Visibility.Visible;

                lblTopSelection.Visibility = Visibility.Hidden;
            }
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
    }
}
