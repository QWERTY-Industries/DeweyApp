using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
//using System.Windows.Automation.Peers;

namespace DeweyApp.MVVM.ViewModel
{
    public class CallNumberOperation
    {
        Random random = new Random();

        Dictionary<string, string> deweyCategoriesDictionary = new Dictionary<string, string>() {
            {"000", "General Knowledge"},
            {"100", "Phsycology and Philosophy"},
            {"200", "Religions and Mythology" },
            {"300", "Social Sciences and Folklore" },
            {"400", "Languages and Grammer" },
            {"500", "Math and Science" },
            {"600", "Medicine and Technology" },
            {"700", "Arts and Recriation" },
            {"800", "Literature" },
            {"900", "Geography and History" }
        };
        // https://www.tutorialsteacher.com/csharp/csharp-dictionary

        //Q Generates a random three digit INT (248)
        public int NumberGenerator()
        {
            int number = random.Next(0, 1000);
            return number;

            //https://www.codegrepper.com/code-examples/csharp/random+number+1+to+1000+c%23
        }

        //Q Places 0's in front of a DOUBLE so that the left of the point is always 3 numbers (24.82 --> 024.82)
        public string NumberPadder(double wholeNumber)
        {   
            string format = "000.##";
            string paddedNumber = wholeNumber.ToString(format);
            return paddedNumber;

            //https://docs.microsoft.com/en-us/dotnet/standard/base-types/how-to-pad-a-number-with-leading-zeros
        }

        //Q Generates a random DOUBLE rounded to 2 decimal places (0.24)
        public double DecimalGenerator()
        {
            double decimalNumber = random.NextDouble();
            double shortDecimal = Math.Round(decimalNumber, 2);
            return shortDecimal;

            //https://www.codegrepper.com/code-examples/csharp/random+number+1+to+1000+c%23
        }

        //Q Generates a random upercase CHAR (B)
        public char LetterGenerator()
        {
            int number = random.Next(0, 26); // Zero to 25
            char lower = (char)('a' + number);
            char upper = char.ToUpper(lower);
            return upper;

            //https://stackoverflow.com/questions/15249138/pick-random-char
            //http://www.java2s.com/Tutorials/CSharp/System/Char/C_Char_ToUpper_Char_.htm#:~:text=ToUpper(Char)%20method%20returns%20The,equivalent%2C%20or%20is%20not%20alphabetic.
        }

        //https://libguides.pratt.edu/finding-books/reading-dewey-call-numbers

        //Q Generates a random STRING in call number format (248.24H248)
        public string CallNumberGenerator()
        {
            int fNumber = NumberGenerator();

            double decimalNumber = DecimalGenerator();

            double firstNumberAndDecimal = fNumber + decimalNumber;
            string firstNumber = NumberPadder(firstNumberAndDecimal);

            char letter = LetterGenerator();

            int sNumber = NumberGenerator();
            string secondNumber = NumberPadder(sNumber);

            //Q 629 .41 T939
            string callNumber = firstNumber + letter + secondNumber;
            return callNumber;
        }

        //Q Returns a LIST<STRING> with 10 random call numbers
        public List<string> getCallNumbers()
        {
            //string[] callNumbers = new string[10];
            List<string> callNumbersList = new List<string>();

            for (int i = 0; i < 10; i++)
            {
                callNumbersList.Add(CallNumberGenerator());
            }

            return callNumbersList;
        }

        //Q Returns an INT to represent the percentage similarity between 2 LIST<STRING>'s
        public int compareCallNumbers(List<string> userCallNumbersList, List<string> sortedCallNumbersList) /*string[] userCallNumbers, string[] sortedCallNumbers*/
        {
            int percentage = 0;

            for (int i = 0; i < userCallNumbersList.Count; i++)
            {
                if (userCallNumbersList.ElementAt(i) == sortedCallNumbersList.ElementAt(i)) /*userCallNumbers[i] == sortedCallNumbers[i]*/
                {
                    percentage = percentage + 10;
                }
            }

            return percentage;
        }

        // AutoSort Method - Only works if matching descriptions to call numbers
        public List<string> IaAutoSort(List<string> matchesList, int type)
        {
            List<string> answers = new List<string>();

            if (type == 1)
            {
                foreach (string key in matchesList)
                {
                    string test = key;
                    answers.Add(deweyCategoriesDictionary[key]);
                }
            }

            return answers;
        }

        public int checkMatch(List<string> userItemsList, List<string> matchesList, int type)
        {
            int percentage = 0;
            Dictionary<string, string> selectedCategoriesDictionary;

            if (type == 0)
            {
                selectedCategoriesDictionary = new Dictionary<string, string>() {
                { userItemsList[0], matchesList[0] },
                { userItemsList[1], matchesList[1] },
                { userItemsList[2], matchesList[2] },
                { userItemsList[3], matchesList[3] } };
            }
            else
            {
                selectedCategoriesDictionary = new Dictionary<string, string>() {
                { matchesList[0], userItemsList[0] },
                { matchesList[1], userItemsList[1] },
                { matchesList[2], userItemsList[2] },
                { matchesList[3], userItemsList[3] } };
            }

            foreach (string key in selectedCategoriesDictionary.Keys)
            {
                string test = key;
                if (selectedCategoriesDictionary.ContainsKey(key) && selectedCategoriesDictionary[key] == deweyCategoriesDictionary[key])
                {
                    percentage = percentage + 25;
                }
            }

            return percentage;
        }

        //public int checkMatch(List<string> userItemsList, List<string> matchesList, int type)
        //{
        //    int percentage = 0;

        //    for (int i = 0; i < matchesList.Count; i++)
        //    {
        //        string test = deweyCategoriesDictionary.ElementAt(i).Key;
        //        if (type == 0)
        //        {
        //            switch (userItemsList.ElementAt(i))
        //            {
        //                case "000" :
        //                    if (matchesList.ElementAt(i) == deweyCategoriesDictionary["000"]) /*"General Knowledge")*/
        //                    {
        //                        percentage = percentage + 25;
        //                    }
        //                    break;
        //                case "100":
        //                    if (matchesList.ElementAt(i) == deweyCategoriesDictionary["100"]) //"Phsycology and Philosophy")
        //                    {
        //                        percentage = percentage + 25;
        //                    }
        //                    break;
        //                case "200":
        //                    if (matchesList.ElementAt(i) == deweyCategoriesDictionary["200"]) //"Religions and Mythology")
        //                    {
        //                        percentage = percentage + 25;
        //                    }
        //                    break;
        //                case "300":
        //                    if (matchesList.ElementAt(i) == deweyCategoriesDictionary["300"]) //"Social Sciences and Folklore")
        //                    {
        //                        percentage = percentage + 25;
        //                    }
        //                    break;
        //                case "400":
        //                    if (matchesList.ElementAt(i) == deweyCategoriesDictionary["400"]) //"Languages and Grammer")
        //                    {
        //                        percentage = percentage + 25;
        //                    }
        //                    break;
        //                case "500":
        //                    if (matchesList.ElementAt(i) == deweyCategoriesDictionary["500"]) //"Math and Science")
        //                    {
        //                        percentage = percentage + 25;
        //                    }
        //                    break;
        //                case "600":
        //                    if (matchesList.ElementAt(i) == deweyCategoriesDictionary["600"]) //"Medicine and Technology")
        //                    {
        //                        percentage = percentage + 25;
        //                    }
        //                    break;
        //                case "700":
        //                    if (matchesList.ElementAt(i) == deweyCategoriesDictionary["700"]) //"Arts and Recriation")
        //                    {
        //                        percentage = percentage + 25;
        //                    }
        //                    break;
        //                case "800":
        //                    if (matchesList.ElementAt(i) == deweyCategoriesDictionary["800"]) //"Literature")
        //                    {
        //                        percentage = percentage + 25;
        //                    }
        //                    break;
        //                default:
        //                    if (matchesList.ElementAt(i) == deweyCategoriesDictionary["900"]) //"Geography and History")
        //                    {
        //                        percentage = percentage + 25;
        //                    }
        //                    break;
        //            }
        //            // https://www.w3schools.com/cs/cs_switch.php
        //        }
        //        else
        //        {
        //            switch (userItemsList.ElementAt(i))
        //            {
        //                case "General Knowledge":
        //                    if (matchesList.ElementAt(i) == "000")
        //                    {
        //                        percentage = percentage + 25;
        //                    }
        //                    break;
        //                case "Phsycology and Philosophy":
        //                    if (matchesList.ElementAt(i) == "100")
        //                    {
        //                        percentage = percentage + 25;
        //                    }
        //                    break;
        //                case "Religions and Mythology":
        //                    if (matchesList.ElementAt(i) == "200")
        //                    {
        //                        percentage = percentage + 25;
        //                    }
        //                    break;
        //                case "Social Sciences and Folklore":
        //                    if (matchesList.ElementAt(i) == "300")
        //                    {
        //                        percentage = percentage + 25;
        //                    }
        //                    break;
        //                case "Languages and Grammer":
        //                    if (matchesList.ElementAt(i) == "400")
        //                    {
        //                        percentage = percentage + 25;
        //                    }
        //                    break;
        //                case "Math and Science":
        //                    if (matchesList.ElementAt(i) == "500")
        //                    {
        //                        percentage = percentage + 25;
        //                    }
        //                    break;
        //                case "Medicine and Technology":
        //                    if (matchesList.ElementAt(i) == "600")
        //                    {
        //                        percentage = percentage + 25;
        //                    }
        //                    break;
        //                case "Arts and Recriation":
        //                    if (matchesList.ElementAt(i) == "700")
        //                    {
        //                        percentage = percentage + 25;
        //                    }
        //                    break;
        //                case "Literature":
        //                    if (matchesList.ElementAt(i) == "800")
        //                    {
        //                        percentage = percentage + 25;
        //                    }
        //                    break;
        //                default:
        //                    if (matchesList.ElementAt(i) == "900")
        //                    {
        //                        percentage = percentage + 25;
        //                    }
        //                    break;
        //            }
        //            // https://www.w3schools.com/cs/cs_switch.php
        //        }
        //    }

        //    return percentage;
        //}

        //public int compareCallNumberMatches(List<string> userSortedItems, int type)
        //{
        //    int percentage = 0;
        //    List<string> sortedCallNumbersList = userSortedItems.OrderBy(x => x).ToList();
        //    List<String> allCallNumbers = new List<String> { "000", "100", "200", "300", "400", "500", "600", "700", "800", "900" };

        //    List<String> checkingCallNumbers = new List<String>();

        //    if (type == 0)
        //    {
        //        for (int i = 0; i < userSortedItems.Count; i++)
        //        {
        //            checkingCallNumbers.Add(allCallNumbers[randomNumbers.ElementAt(i)]);
        //        }

        //        for (int i = 0; i < userSortedItems.Count; i++)
        //        {
        //            if (userSortedItems.ElementAt(i) == checkingCallNumbers.ElementAt(i)) /*userCallNumbers[i] == sortedCallNumbers[i]*/
        //            {
        //                percentage = percentage + 10;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        for (int i = 0; i < userSortedItems.Count; i++)
        //        {
        //            if (userSortedItems.ElementAt(i) == userSortedItems.ElementAt(i)) /*userCallNumbers[i] == sortedCallNumbers[i]*/
        //            {
        //                percentage = percentage + 10;
        //            }
        //        }
        //    }

        //    return percentage;
        //}

        List<int> randomNumbers;

        public int[] NumberGenerator7()
        {
            int[] numbers = new int[7];
            //https://www.codegrepper.com/code-examples/csharp/random+number+1+to+1000+c%23

            randomNumbers = Enumerable.Range(0, 9).OrderBy(x => random.Next()).Take(7).ToList();
            // https://stackoverflow.com/questions/26931528/random-number-generator-with-no-duplicates

            for (int i = 0; i < 7; i++)
            {
                numbers[i] = randomNumbers.ElementAt(i); //random.Next(0, 9);
                // https://stackoverflow.com/questions/15456845/getting-a-list-item-by-index
            }

            return numbers;
        }

        //public int[] NumberGenerator5()
        //{
        //    int[] numbers = new int[5];

        //    for (int i = 0; i < 5; i++)
        //    {
        //        numbers[i] = random.Next(0, 9);
        //    }

        //    return numbers;

        //    //https://www.codegrepper.com/code-examples/csharp/random+number+1+to+1000+c%23
        //}

        public List<String> getSortingCallNumberCategories(int[] positions)
        {
            List<String> sortingCallNumberCategories = new List<String>();

            for (int i = 0; i < positions.Length; i++)
            {
                //sortingCallNumberCategories.Add(allCallNumberCategories[positions[i]]);
                sortingCallNumberCategories.Add(deweyCategoriesDictionary.ElementAt(positions[i]).Value);
                // https://stackoverflow.com/questions/40412340/c-sharp-dictionary-get-item-by-index
            }

            return sortingCallNumberCategories;
        }

        public List<String> getSortingCallNumbers(int[] positions)
        {
            List<String> sortingCallNumbers = new List<String>();

            for (int i = 0; i < positions.Length; i++)
            {
                //sortingCallNumbers.Add(allCallNumbers[positions[i]]);
                sortingCallNumbers.Add(deweyCategoriesDictionary.ElementAt(positions[i]).Key);
                // https://stackoverflow.com/questions/40412340/c-sharp-dictionary-get-item-by-index
            }

            return sortingCallNumbers;
        }
    }
}
