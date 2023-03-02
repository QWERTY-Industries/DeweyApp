using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeweyApp.MVVM.Model;
using Firebase.Database;
using Firebase.Database.Query;
using FireSharp.Response;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Windows.Markup;
//using System.DirectoryServices;
using System.Configuration;

namespace DeweyApp.MVVM.ViewModel
{
    public class FirebaseLink
    {
        User user = new User();

        User[] leaderboardUsers = new User[10];

        //Q Initialize Firebase
        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "pvwjAGIyZkYkBeJLL7IG1rP2xu23omTDfjLnKKHk",
            BasePath = "https://deweyapp-b42dc-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;

        string basePath = "https://deweyapp-b42dc-default-rtdb.firebaseio.com/";

        //Q The following code deals with signing up and logging in users QQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQ

        //Q The Method below will Generate a UserId
        private string CreateId()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            return finalString;

            //Q Reference this Correctly
            //https://stackoverflow.com/questions/1344221/how-can-i-generate-random-alphanumeric-strings
        }

        //Q The Method below will add a User to Firebase
        public void SignUpUser(string email, string password)
        {
            string firebaseUserId = CreateId();

            bool[] achievements = { false, false, false, false, false, false, false, false, false, false };
            bool[] items = { false, false, false, false, false, false, false, false, false, false };

            User newUser = new User(firebaseUserId, email, password, 0, 0, 0, achievements, items, 0, "DeweyUser", 60, false);

            client = new FireSharp.FirebaseClient(config);

            var result = new FirebaseClient(basePath).Child("Users").Child(firebaseUserId).PutAsync(newUser);

            //Q Reference this Correctly
            //https://www.youtube.com/watch?v=GH_mHALFUTU
        }

        //Q The Method below will Retrive a User from Firebase
        public bool LogInUser(string email, string password)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Users");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            bool allowAccess = false;

            foreach (var u in data)
            {
                if (JsonConvert.DeserializeObject<User>(((JProperty)u).Value.ToString()).Email == email &&
                    JsonConvert.DeserializeObject<User>(((JProperty)u).Value.ToString()).Password == password)
                {
                    string id = JsonConvert.DeserializeObject<User>(((JProperty)u).Value.ToString()).Id;
                    int rbLevel = JsonConvert.DeserializeObject<User>(((JProperty)u).Value.ToString()).ReplacingBooksLevel;
                    int iaLevel = JsonConvert.DeserializeObject<User>(((JProperty)u).Value.ToString()).IdentifyingAreasLevel;
                    int fcnLevel = JsonConvert.DeserializeObject<User>(((JProperty)u).Value.ToString()).FindingCallNumbersLevel;
                    bool[] achievements = JsonConvert.DeserializeObject<User>(((JProperty)u).Value.ToString()).Achievements;
                    bool[] items = JsonConvert.DeserializeObject<User>(((JProperty)u).Value.ToString()).ShopItems;
                    int picture = JsonConvert.DeserializeObject<User>(((JProperty)u).Value.ToString()).DisplayPicture;
                    string username = JsonConvert.DeserializeObject<User>(((JProperty)u).Value.ToString()).Username;
                    int balance = JsonConvert.DeserializeObject<User>(((JProperty)u).Value.ToString()).Balance;
                    bool developer = JsonConvert.DeserializeObject<User>(((JProperty)u).Value.ToString()).Developer;

                    // Log In User
                    user = new User(id, email, password, rbLevel, iaLevel, fcnLevel, achievements, items, picture, username, balance, developer);

                    allowAccess = true;
                }
            }

            return allowAccess;
        }

        //QQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQ

        //Q The following code has to do with retriving and updating user levels accross different gamemodes QQQQQQQQQQQQQQQQQQQQQQQ

        //Q Increase a User's ReplacingBooksLevel by 1
        public void RbLevelUp()
        {
            user.ReplacingBooksLevel = user.ReplacingBooksLevel + 1;

            client = new FireSharp.FirebaseClient(config);

            var result = new FirebaseClient(basePath).Child("Users").Child(user.Id).Child("ReplacingBooksLevel").PutAsync(user.ReplacingBooksLevel);
        }

        //Q Increase a User's IdentifyingAreasLevel by 1
        public void IaLevelUp()
        {
            user.IdentifyingAreasLevel = user.IdentifyingAreasLevel + 1;

            client = new FireSharp.FirebaseClient(config);

            var result = new FirebaseClient(basePath).Child("Users").Child(user.Id).Child("IdentifyingAreasLevel").PutAsync(user.IdentifyingAreasLevel);
        }

        //Q Increase a User's FindingCallNumbersLevel by 1
        public void FcnRbLevelUp()
        {
            user.FindingCallNumbersLevel = user.FindingCallNumbersLevel + 1;

            client = new FireSharp.FirebaseClient(config);

            var result = new FirebaseClient(basePath).Child("Users").Child(user.Id).Child("FindingCallNumbersLevel").PutAsync(user.FindingCallNumbersLevel);
        }

        //Q Retrieve a User's Total Level (ReplacingBooksLevel + IdentifyingAreasLevel + FindingCallNumbersLevel)
        public int getUserTotalLevel()
        {
            int totalLevel = user.ReplacingBooksLevel + user.IdentifyingAreasLevel + user.FindingCallNumbersLevel;
            return totalLevel;
        }

        //Q Retrieve a User's Gamemode Level
        public int getUserLevel(int mode)
        {
            if (mode == 0)
            {
                return user.ReplacingBooksLevel;
            }
            else if (mode == 1)
            {
                return user.IdentifyingAreasLevel;
            }
            else
            {
                return user.FindingCallNumbersLevel;
            }
        }
        //Q Retrieve a User's ReplacingBooksLevel
        //public int getUserRbLevel()
        //{
        //    return user.ReplacingBooksLevel;
        //}

        //Q Retrieve a User's IdentifyingAreasLevel
        //public int getUserIaLevel()
        //{
        //    return user.IdentifyingAreasLevel;
        //}

        //Q Retrieve a User's FindingCallNumbersLevel
        //public int getUserFcnLevel()
        //{
        //    return user.FindingCallNumbersLevel;
        //}

        //QQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQ

        public bool[] GetUserAchievements()
        {
            return user.Achievements;
        }

        public bool[] GetUserShopItems()
        {
            return user.ShopItems;
        }

        public bool GetObtained(int place)
        {
            bool[] achievements = user.Achievements;
            bool obtained = achievements[place];
            return obtained;
        }

        public void Obtain(int place)
        {
            user.Achievements[place] = true;

            client = new FireSharp.FirebaseClient(config);

            var result = new FirebaseClient(basePath).Child("Users").Child(user.Id).Child("Achievements").PutAsync(user.Achievements);
        }

        public bool GetPurchased(int place)
        {
            bool[] items = user.ShopItems;
            bool purchased = items[place];
            return purchased;
        }

        public int GetDisplayPicture()
        {
            return user.DisplayPicture;
        }

        public void ChangeUsername(string username)
        {
            user.Username = username;

            client = new FireSharp.FirebaseClient(config);

            var result = new FirebaseClient(basePath).Child("Users").Child(user.Id).Child("Username").PutAsync(user.Username);
        }

        public void ChangePicture(int pictureId)
        {
            user.DisplayPicture = pictureId;

            client = new FireSharp.FirebaseClient(config);

            var result = new FirebaseClient(basePath).Child("Users").Child(user.Id).Child("DisplayPicture").PutAsync(user.DisplayPicture);
        }

        public string GetUsername()
        {
            return user.Username;
        }

        public int GetBalance()
        {
            return user.Balance;
        }

        public void Buy(int place, int cost)
        {
            user.Balance = user.Balance - cost;
            user.ShopItems[place] = true;

            client = new FireSharp.FirebaseClient(config);

            var firstResult = new FirebaseClient(basePath).Child("Users").Child(user.Id).Child("Balance").PutAsync(user.Balance);
            var secondResult = new FirebaseClient(basePath).Child("Users").Child(user.Id).Child("ShopItems").PutAsync(user.ShopItems);
        }

        public void AddCoins(int coins)
        {
            user.Balance = user.Balance + coins;
            client = new FireSharp.FirebaseClient(config);
            var result = new FirebaseClient(basePath).Child("Users").Child(user.Id).Child("Balance").PutAsync(user.Balance);
        }

        public bool GetDeveloperStatus()
        {
            return user.Developer;
        }

        public void EnableDeveloperStatus()
        {
            user.Developer = true;
            var result = new FirebaseClient(basePath).Child("Users").Child(user.Id).Child("Developer").PutAsync(user.Developer);
        }

        public User GetLeaderboardPlayer(string id)
        {
            User leaderboardPlayer = new User();

            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Users");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);

            foreach (var u in data)
            {
                if (JsonConvert.DeserializeObject<User>(((JProperty)u).Value.ToString()).Id == id)
                {
                    int rbLevel = JsonConvert.DeserializeObject<User>(((JProperty)u).Value.ToString()).ReplacingBooksLevel;
                    int iaLevel = JsonConvert.DeserializeObject<User>(((JProperty)u).Value.ToString()).IdentifyingAreasLevel;
                    int fcnLevel = JsonConvert.DeserializeObject<User>(((JProperty)u).Value.ToString()).FindingCallNumbersLevel;
                    bool[] achievements = JsonConvert.DeserializeObject<User>(((JProperty)u).Value.ToString()).Achievements;
                    bool[] items = JsonConvert.DeserializeObject<User>(((JProperty)u).Value.ToString()).ShopItems;
                    int picture = JsonConvert.DeserializeObject<User>(((JProperty)u).Value.ToString()).DisplayPicture;
                    string username = JsonConvert.DeserializeObject<User>(((JProperty)u).Value.ToString()).Username;

                    leaderboardPlayer = new User(id, rbLevel, iaLevel, fcnLevel, achievements, items, picture, username);
                }
            }

            return leaderboardPlayer;
        }

        public void GenerateTopPlayers(int mode)
        {
            int[] levels = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string[] ids = new string[10];
            User[] users = new User[10];
            int gamemode = mode;

            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Users");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);

            // Leaderboard Sorting Method aka. The HARDEST Method
            // I CAN NOT belive I got my head around this xD
            foreach (var u in data)
            {
                int level;
                if (gamemode == 0)
                {
                    level = JsonConvert.DeserializeObject<User>(((JProperty)u).Value.ToString()).ReplacingBooksLevel;
                }
                else if (gamemode == 1)
                {
                    level = JsonConvert.DeserializeObject<User>(((JProperty)u).Value.ToString()).IdentifyingAreasLevel;
                }
                else
                {
                    level = JsonConvert.DeserializeObject<User>(((JProperty)u).Value.ToString()).FindingCallNumbersLevel;
                }
                
                string id = JsonConvert.DeserializeObject<User>(((JProperty)u).Value.ToString()).Id;
                
                if (levels[9] < level)
                {
                    if (levels[8] < level)
                    {
                        levels[9] = levels[8];
                        ids[9] = ids[8];

                        if (levels[7] < level)
                        {
                            levels[8] = levels[7];
                            ids[8] = ids[7];

                            if (levels[6] < level)
                            {
                                levels[7] = levels[6];
                                ids[7] = ids[6];

                                if (levels[5] < level)
                                {
                                    levels[6] = levels[5];
                                    ids[6] = ids[5];

                                    if (levels[4] < level)
                                    {
                                        levels[5] = levels[4];
                                        ids[5] = ids[4];

                                        if (levels[3] < level)
                                        {
                                            levels[4] = levels[3];
                                            ids[4] = ids[3];

                                            if (levels[2] < level)
                                            {
                                                levels[3] = levels[2];
                                                ids[3] = ids[2];

                                                if (levels[1] < level)
                                                {
                                                    levels[2] = levels[1];
                                                    ids[2] = ids[1];

                                                    if (levels[0] < level)
                                                    {
                                                        levels[1] = levels[0];
                                                        ids[1] = ids[0];

                                                        levels[0] = level;
                                                        ids[0] = id;
                                                    }
                                                    else
                                                    {
                                                        levels[1] = level;
                                                        ids[1] = id;
                                                    }
                                                }
                                                else
                                                {
                                                    levels[2] = level;
                                                    ids[2] = id;
                                                }
                                            }
                                            else
                                            {
                                                levels[3] = level;
                                                ids[3] = id;
                                            }
                                        }
                                        else
                                        {
                                            levels[4] = level;
                                            ids[4] = id;
                                        }
                                    }
                                    else
                                    {
                                        levels[5] = level;
                                        ids[5] = id;
                                    }
                                }
                                else
                                {
                                    levels[6] = level;
                                    ids[6] = id;
                                }
                            }
                            else
                            {
                                levels[7] = level;
                                ids[7] = id;
                            }
                        }
                        else
                        {
                            levels[8] = level;
                            ids[8] = id;
                        }
                    }
                    else
                    {
                        levels[9] = level;
                        ids[9] = id;
                    }
                }
            }

            for (int i = 0; i < ids.Length; i++)
            {
                leaderboardUsers[i] = GetLeaderboardPlayer(ids[i]);
            }
        }

        public string[] GetLeaderboardUsernames()
        {
            string[] leaderboardUsernames = new string[10];

            for (int i = 0; i < leaderboardUsers.Length; i++)
            {
                leaderboardUsernames[i] = leaderboardUsers[i].Username;
            }

            return leaderboardUsernames;
        }

        public string GetLeaderboardUsername(string id)
        {
            string leaderboardUsername = "";

            for (int i = 0; i < leaderboardUsers.Length; i++)
            {
                if (leaderboardUsers[i].Id == id)
                {
                    leaderboardUsername = leaderboardUsers[i].Username;
                }
            }

            return leaderboardUsername;
        }

        public int GetLeaderboardLevel(string id, int mode)
        {
            int leaderboardLevel = new int();

            if (mode == 0)
            {
                for (int i = 0; i < leaderboardUsers.Length; i++)
                {
                    if (leaderboardUsers[i].Id == id)
                    {
                        leaderboardLevel = leaderboardUsers[i].ReplacingBooksLevel;
                    }
                }
            }
            else if (mode == 1)
            {
                for (int i = 0; i < leaderboardUsers.Length; i++)
                {
                    if (leaderboardUsers[i].Id == id)
                    {
                        leaderboardLevel = leaderboardUsers[i].IdentifyingAreasLevel;
                    }
                }
            }
            else
            {
                for (int i = 0; i < leaderboardUsers.Length; i++)
                {
                    if (leaderboardUsers[i].Id == id)
                    {
                        leaderboardLevel = leaderboardUsers[i].FindingCallNumbersLevel;
                    }
                }
            }

            return leaderboardLevel;
        }

        public int GetLeaderboardPicture(string id)
        {
            int leaderboardPicture = new int();

            for (int i = 0; i < leaderboardUsers.Length; i++)
            {
                if (leaderboardUsers[i].Id == id)
                {
                    leaderboardPicture = leaderboardUsers[i].DisplayPicture;
                }
            }

            return leaderboardPicture;
        }

        public bool[] GetLeaderboardAchievements(string id)
        {
            bool[] leaderboardAchievements = new bool[10];

            for (int i = 0; i < leaderboardUsers.Length; i++)
            {
                if (leaderboardUsers[i].Id == id)
                {
                    leaderboardAchievements = leaderboardUsers[i].Achievements.ToArray();
                }
            }

            return leaderboardAchievements;
        }

        public bool[] GetLeaderboardShopItems(string id)
        {
            bool[] leaderboardShopItems = new bool[10];

            for (int i = 0; i < leaderboardUsers.Length; i++)
            {
                if (leaderboardUsers[i].Id == id)
                {
                    leaderboardShopItems = leaderboardUsers[i].ShopItems.ToArray();
                }
            }

            return leaderboardShopItems;
        }

        public string GetLeaderboardPlayer(int place)
        {
            return leaderboardUsers[place].Id;
        }
    }
}
