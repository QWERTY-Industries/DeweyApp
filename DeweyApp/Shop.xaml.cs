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
    /// Interaction logic for Shop.xaml
    /// </summary>
    public partial class Shop : Window
    {
        FirebaseLink firebaseLink;

        BitmapImage bitmapImage = new BitmapImage();
        Uri uriSource;

        public Shop(FirebaseLink fbl)
        {
            InitializeComponent();
            firebaseLink = fbl;

            bool[] obtainedAchievements = firebaseLink.GetUserAchievements();

            lstItems.Items.Add("Dewey Pamphlet");
            lstItems.Items.Add("Dewey Manual");
            lstItems.Items.Add("Dewey Encyclopedia");

            lstItems.Items.Add("More Sorting?");
            lstItems.Items.Add("It'll be Fun!");

            lstItems.Items.Add("Robot Bobble Head");
            lstItems.Items.Add("Goblin Bobble Head");
            lstItems.Items.Add("Knight Bobble Head");

            lstItems.Items.Add("Check Out Time");
            lstItems.Items.Add("Group Picture!");

            lblTitle.Content = "Dewey Pamphlet";
            lblCost.Content = 50 + " Coins";
            lblType.Content = "BADGE";

            bool purchased = firebaseLink.GetPurchased(0);

            uriSource = new Uri("Images/Badges/PamphletBadge.jpg", UriKind.Relative);

            if (purchased == true)
                lblOwned.Content = "Owned";
            else
                lblOwned.Content = "Not Owned";

            lblBalance.Content = firebaseLink.GetBalance() + " Coins";

            imgItem.Source = new BitmapImage(uriSource);
        }

        private void btnViewItem_Click(object sender, RoutedEventArgs e)
        {
            bool purchased = false;

            if (lstItems.SelectedItem.ToString() == "Dewey Pamphlet")
            {
                lblTitle.Content = "Dewey Pamphlet";
                lblCost.Content = 50 + " Coins";
                lblType.Content = "BADGE";
                purchased = firebaseLink.GetPurchased(0);

                uriSource = new Uri("Images/Badges/PamphletBadge.jpg", UriKind.Relative);
            }
            else if (lstItems.SelectedItem.ToString() == "Dewey Manual")
            {
                lblTitle.Content = "Dewey Manual";
                lblCost.Content = 100 + " Coins";
                lblType.Content = "BADGE";
                purchased = firebaseLink.GetPurchased(1);

                uriSource = new Uri("Images/Badges/ManualBadge.jpg", UriKind.Relative);
            }
            else if (lstItems.SelectedItem.ToString() == "Dewey Encyclopedia")
            {
                lblTitle.Content = "Dewey Encyclopedia";
                lblCost.Content = 150 + " Coins";
                lblType.Content = "BADGE";
                purchased = firebaseLink.GetPurchased(2);

                uriSource = new Uri("Images/Badges/EncyclopediaBadge.jpg", UriKind.Relative);
            }
            else if(lstItems.SelectedItem.ToString() == "More Sorting?")
            {
                lblTitle.Content = "More Sorting?";
                lblCost.Content = 200 + " Coins";
                lblType.Content = "AVATAR";
                purchased = firebaseLink.GetPurchased(3);

                uriSource = new Uri("Images/Avatars/ManAvatar.jpg", UriKind.Relative);
            }
            else if (lstItems.SelectedItem.ToString() == "It'll be Fun!")
            {
                lblTitle.Content = "It'll be Fun!";
                lblCost.Content = 200 + " Coins";
                lblType.Content = "AVATAR";
                purchased = firebaseLink.GetPurchased(4);

                uriSource = new Uri("Images/Avatars/WomanAvatar.jpg", UriKind.Relative);
            }
            else if (lstItems.SelectedItem.ToString() == "Robot Bobble Head")
            {
                lblTitle.Content = "Robot Bobble Head";
                lblCost.Content = 200 + " Coins";
                lblType.Content = "BADGE";
                purchased = firebaseLink.GetPurchased(5);

                uriSource = new Uri("Images/Badges/RobotBadge.jpg", UriKind.Relative);
            }
            if (lstItems.SelectedItem.ToString() == "Goblin Bobble Head")
            {
                lblTitle.Content = "Goblin Bobble Head";
                lblCost.Content = 200 + " Coins";
                lblType.Content = "BADGE";
                purchased = firebaseLink.GetPurchased(6);

                uriSource = new Uri("Images/Badges/GoblinBadge.jpg", UriKind.Relative);
            }
            else if (lstItems.SelectedItem.ToString() == "Knight Bobble Head")
            {
                lblTitle.Content = "Knight Bobble Head";
                lblCost.Content = 200 + " Coins";
                lblType.Content = "BADGE";
                purchased = firebaseLink.GetPurchased(7);

                uriSource = new Uri("Images/Badges/KnightBadge.jpg", UriKind.Relative);
            }
            else if (lstItems.SelectedItem.ToString() == "Check Out Time")
            {
                lblTitle.Content = "Check Out Time";
                lblCost.Content = 200 + " Coins";
                lblType.Content = "AVATAR";
                purchased = firebaseLink.GetPurchased(8);

                uriSource = new Uri("Images/Avatars/BookAvatar.jpg", UriKind.Relative);
            }
            else if (lstItems.SelectedItem.ToString() == "Group Picture!")
            {
                lblTitle.Content = "Group Picture!";
                lblCost.Content = 500 + " Coins";
                lblType.Content = "AVATAR";
                purchased = firebaseLink.GetPurchased(9);

                uriSource = new Uri("Images/Avatars/GroupAvatar.jpg", UriKind.Relative);
            }

            //switch(lstItems.SelectedItem.ToString())
            //{
            //    case "Dewey Pamphlet":
            //        break;
            //    case "Dewey Manual":
            //        break;
            //    case "Dewey Encyclopedia":
            //        break;
            //    case "More Sorting?":
            //        break;
            //    case "It'll be Fun!":
            //        break;
            //    case "Robot Bobble Head":
            //        break;
            //    case "Goblin Bobble Head":
            //        break;
            //    case "Knight Bobble Head":
            //        break;
            //    case "Check Out Time":
            //        break;
            //    case "Group Picture!":
            //        break;
            //    case null:
            //        break;
            //}

            if (purchased == true)
                lblOwned.Content = "Owned";
            else
                lblOwned.Content = "Not Owned";

            imgItem.Source = new BitmapImage(uriSource);
        }

        private void btnBuyItem_Click(object sender, RoutedEventArgs e)
        {
            int userBalance = firebaseLink.GetBalance();

            if (lstItems.SelectedItem.ToString() == "Dewey Pamphlet")
            {
                if (firebaseLink.GetPurchased(0) == false)
                {
                    if (userBalance >= 50)
                    {
                        firebaseLink.Buy(0, 50);
                        lblOwned.Content = "Owned";
                    }
                    else
                    {
                        MessageBox.Show("This Item Costs " + 50 + " Coins and you only have " + userBalance + " Coins", "Not Enough Coins :(");
                    }
                }
                else
                {
                    MessageBox.Show("You already Own this Item :o");
                }
            }
            else if (lstItems.SelectedItem.ToString() == "Dewey Manual")
            {
                if (firebaseLink.GetPurchased(1) == false)
                {
                    if (userBalance >= 100)
                    {
                        firebaseLink.Buy(1, 100);
                        lblOwned.Content = "Owned";
                    }
                    else
                    {
                        MessageBox.Show("This Item Costs " + 100 + " Coins and you only have " + userBalance + " Coins", "Not Enough Coins :(");
                    }
                }
                else
                {
                    MessageBox.Show("You already Own this Item :o");
                }
            }
            else if (lstItems.SelectedItem.ToString() == "Dewey Encyclopedia")
            {
                if (firebaseLink.GetPurchased(2) == false)
                {
                    if (userBalance >= 150)
                    {
                        firebaseLink.Buy(2, 150);
                        lblOwned.Content = "Owned";
                    }
                    else
                    {
                        MessageBox.Show("This Item Costs " + 150 + " Coins and you only have " + userBalance + " Coins", "Not Enough Coins :(");
                    }
                }
                else
                {
                    MessageBox.Show("You already Own this Item :o");
                }
            }
            else if (lstItems.SelectedItem.ToString() == "More Sorting?")
            {
                if (firebaseLink.GetPurchased(3) == false)
                {
                    if (userBalance >= 200)
                    {
                        firebaseLink.Buy(3, 200);
                        lblOwned.Content = "Owned";
                    }
                    else
                    {
                        MessageBox.Show("This Item Costs " + 200 + " Coins and you only have " + userBalance + " Coins", "Not Enough Coins :(");
                    }
                }
                else
                {
                    MessageBox.Show("You already Own this Item :o");
                }
            }
            else if (lstItems.SelectedItem.ToString() == "It'll be Fun!")
            {
                if (firebaseLink.GetPurchased(4) == false)
                {
                    if (userBalance >= 200)
                    {
                        firebaseLink.Buy(4, 200);
                        lblOwned.Content = "Owned";
                    }
                    else
                    {
                        MessageBox.Show("This Item Costs " + 200 + " Coins and you only have " + userBalance + " Coins", "Not Enough Coins :(");
                    }
                }
                else
                {
                    MessageBox.Show("You already Own this Item :o");
                }
            }
            else if (lstItems.SelectedItem.ToString() == "Robot Bobble Head")
            {
                if (firebaseLink.GetPurchased(5) == false)
                {
                    if (userBalance >= 200)
                    {
                        firebaseLink.Buy(5, 200);
                        lblOwned.Content = "Owned";
                    }
                    else
                    {
                        MessageBox.Show("This Item Costs " + 200 + " Coins and you only have " + userBalance + " Coins", "Not Enough Coins :(");
                    }
                }
                else
                {
                    MessageBox.Show("You already Own this Item :o");
                }
            }
            else if (lstItems.SelectedItem.ToString() == "Goblin Bobble Head")
            {
                if (firebaseLink.GetPurchased(6) == false)
                {
                    if (userBalance >= 200)
                    {
                        firebaseLink.Buy(6, 200);
                        lblOwned.Content = "Owned";
                    }
                    else
                    {
                        MessageBox.Show("This Item Costs " + 200 + " Coins and you only have " + userBalance + " Coins", "Not Enough Coins :(");
                    }
                }
                else
                {
                    MessageBox.Show("You already Own this Item :o");
                }
            }
            else if (lstItems.SelectedItem.ToString() == "Knight Bobble Head")
            {
                if (firebaseLink.GetPurchased(7) == false)
                {
                    if (userBalance >= 200)
                    {
                        firebaseLink.Buy(7, 200);
                        lblOwned.Content = "Owned";
                    }
                    else
                    {
                        MessageBox.Show("This Item Costs " + 200 + " Coins and you only have " + userBalance + " Coins", "Not Enough Coins :(");
                    }
                }
                else
                {
                    MessageBox.Show("You already Own this Item :o");
                }
            }
            else if (lstItems.SelectedItem.ToString() == "Check Out Time")
            {
                if (firebaseLink.GetPurchased(8) == false)
                {
                    if (userBalance >= 200)
                    {
                        firebaseLink.Buy(8, 200);
                        lblOwned.Content = "Owned";
                    }
                    else
                    {
                        MessageBox.Show("This Item Costs " + 200 + " Coins and you only have " + userBalance + " Coins", "Not Enough Coins :(");
                    }
                }
                else
                {
                    MessageBox.Show("You already Own this Item :o");
                }
            }
            else if (lstItems.SelectedItem.ToString() == "Group Picture!")
            {
                if (firebaseLink.GetPurchased(9) == false)
                {
                    if (userBalance >= 500)
                    {
                        firebaseLink.Buy(9, 500);
                        lblOwned.Content = "Owned";
                    }
                    else
                    {
                        MessageBox.Show("This Item Costs " + 500 + " Coins and you only have " + userBalance + " Coins", "Not Enough Coins :(");
                    }
                }
                else
                {
                    MessageBox.Show("You already Own this Item :o");
                }
            }
            
            lblBalance.Content = firebaseLink.GetBalance() + " Coins";
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu(firebaseLink);
            mainMenu.Show();
            this.Close();
        }
    }
}
