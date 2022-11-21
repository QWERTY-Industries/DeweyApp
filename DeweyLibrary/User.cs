using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeweyApp.MVVM.Model
{
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int ReplacingBooksLevel { get; set; }
        public int IdentifyingAreasLevel { get; set; }
        public int FindingCallNumbersLevel { get; set; }
        public bool[] Achievements { get; set; }
        public bool[] ShopItems { get; set; }
        public int DisplayPicture { get; set; }
        public string Username { get; set; }
        public int Balance { get; set; }
        public bool Developer { get; set; }

        public User()
        {

        }

        public User(string id, int rbLevel, int iaLevel, int fcnLevel, bool[] achivements, bool[] shopItems, int displayPicture, string username)
        {
            Id = id;
            ReplacingBooksLevel = rbLevel;
            IdentifyingAreasLevel = iaLevel;
            FindingCallNumbersLevel = fcnLevel;
            Achievements = achivements;
            ShopItems = shopItems;
            DisplayPicture = displayPicture;
            Username = username;
        }

        public User(string id, string email, string password, int rbLevel, int iaLevel, int fcnLevel, bool[] achivements, bool[] shopItems,
            int displayPicture, string username, int balance, bool developer)
        {
            Id = id;
            Email = email;
            Password = password;
            ReplacingBooksLevel = rbLevel;
            IdentifyingAreasLevel = iaLevel;
            FindingCallNumbersLevel = fcnLevel;
            Achievements = achivements;
            ShopItems = shopItems;
            DisplayPicture = displayPicture;
            Username = username;
            Balance = balance;
            Developer = developer;
        }
    }
}
