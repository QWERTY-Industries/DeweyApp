using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeweyApp.MVVM.ViewModel
{
    public class TreeLink
    {
        Tree<Category> deweyTree = new Tree<Category>();
        string fileName = "DeweyDecimalSystemCategories.txt";

        public void ReadFromFile()
        {
            using (StreamReader file = new StreamReader(fileName))
            {
                string ln;
                string[] partsOfLine;

                //Insert very first node
                string FirstLineOfFile = "Root";
                Category value = new Category();
                value.id = "";
                value.name = FirstLineOfFile;
                deweyTree.InsertTreeNode(value);

                while (!file.EndOfStream)// (ln = file.ReadLine()) != null)
                {
                    ln = file.ReadLine();
                    partsOfLine = ln.Split('-');
                    Category newValue = new Category();
                    newValue.id = partsOfLine[0]; //"000" -> 0
                    newValue.name = partsOfLine[1];
                    deweyTree.InsertTreeNode(newValue);
                }
                file.Close();
            }
        }

        int GetRandomTreePosition(TreeNode<Category> node)
        {
            Random random = new Random();

            List<int> positions = new List<int>();
            int randomNumber;

            for (int i = 0; i < 10; i++)
            {
                if (node.Children[i] != null)
                {
                    positions.Add(i);
                }
            }

            int number = random.Next(positions.Count);

            randomNumber = positions[number];

            return randomNumber;
        }

        public string RandomLevel3Position()
        {
            string level1Id = deweyTree.Root.Children[GetRandomTreePosition(deweyTree.Root)].Data.id; // Selects random from first level 278 = 2

            string level2Id = deweyTree.Root.Children[GetRandomTreePosition(deweyTree.Root.Children[Convert.ToInt32(level1Id)])].Data.id;
            // Selects random from second level 278 = 7

            string level3Id = deweyTree.Root.Children[GetRandomTreePosition(deweyTree.Root.Children[Convert.ToInt32(level1Id)].
                                             Children[Convert.ToInt32(level2Id)])].Data.id; // Selects random from third level 278 = 8

            string randomPosition = level1Id + "" + level2Id + "" + level3Id;

            return randomPosition;

            //Category randomLevel3Entry = new Category();

            //randomLevel3Entry.name = deweyTree.Root.Children[Convert.ToInt32(level1Id)].
            //                                        Children[Convert.ToInt32(level2Id)].
            //                                        Children[Convert.ToInt32(level3Id)].Data.name;

            //string randomPosition = level1Id + "" + level2Id + "" + level3Id;
            //randomLevel3Entry.id = level1Id + level2Id + level3Id;

            //return randomLevel3Entry;
        }

        public Category Level3PositionFromTree(string randomPosition)
        {
            string level1Id = randomPosition.Substring(0, 1);
            string level2Id = randomPosition.Substring(1, 1);
            string level3Id = randomPosition.Substring(2, 1);

            Category level3Entry = new Category();

            level3Entry.name = deweyTree.Root.Children[Convert.ToInt32(level1Id)].
                                                    Children[Convert.ToInt32(level2Id)].
                                                    Children[Convert.ToInt32(level3Id)].Data.name;

            string position = level1Id + "" + level2Id + "" + level3Id;
            level3Entry.id = level1Id + level2Id + level3Id;

            return level3Entry;
        }

        public Category RandomLevel3FromTree(string level1Id, string level2Id, string position)
        {
            int positionInt = Convert.ToInt32(position);
            int level1IdInt = Convert.ToInt32(position);
            int level2IdInt = Convert.ToInt32(level1Id);

            string level3Id = deweyTree.Root.Children[level1IdInt].Children[level2IdInt].Children[positionInt].Data.id; // Selects random from third level 278 = 8

            Category level3Entry = new Category();

            level3Entry.name = deweyTree.Root.Children[Convert.ToInt32(level1Id)].
                                              Children[Convert.ToInt32(level2Id)].
                                              Children[Convert.ToInt32(level3Id)].Data.name;

            string randomPosition = level1Id + "" + level2Id + "0";

            level3Entry.id = randomPosition;

            return level3Entry;

            //bool doAgain = true;
            //string level3Id = new string("");
            //while (doAgain == true)
            //{
            //    //string level1Id = deweyTree.Root.Children[GetRandomTreePosition(deweyTree.Root)].Data.id; // Selects random from first level 278 = 2

            //    //string level2Id = deweyTree.Root.Children[GetRandomTreePosition(deweyTree.Root.Children[Convert.ToInt32(level1Id)])].Data.id;
            //    // Selects random from second level 278 = 7

            //    level3Id = deweyTree.Root.Children[GetRandomTreePosition(deweyTree.Root.Children[Convert.ToInt32(level1Id)].
            //                                     Children[Convert.ToInt32(level2Id)])].Data.id; // Selects random from third level 278 = 8

            //    if (level3Id == alreadyGeneratedNumber)
            //    {
            //        doAgain = true;
            //    }
            //    else
            //    {
            //        doAgain = false;
            //    }
            //}

            //Category randomLevel3Entry = new Category();

            //randomLevel3Entry.name = deweyTree.Root.Children[Convert.ToInt32(level1Id)].
            //                                        Children[Convert.ToInt32(level2Id)].
            //                                        Children[Convert.ToInt32(level3Id)].Data.name;

            //string randomPosition = level1Id + "" + level2Id + "" + level3Id;
            //randomLevel3Entry.id = level1Id + level2Id + level3Id;

            //return randomLevel3Entry;
        }

        public Category RandomLevel2FromTree(string level1Id, string position)
        {
            int positionInt = Convert.ToInt32(position);
            int level1IdInt = Convert.ToInt32(level1Id);

            string level2Id = deweyTree.Root.Children[level1IdInt].Children[positionInt].Data.id;
            // Selects random from second level 278 = 7

            Category level2Entry = new Category();

            level2Entry.name = deweyTree.Root.Children[Convert.ToInt32(level1Id)].
                                              Children[Convert.ToInt32(level2Id)].
                                              Children[Convert.ToInt32(0)].Data.name;

            string randomPosition = level1Id + "" + level2Id + "0";

            level2Entry.name = deweyTree.Root.Children[Convert.ToInt32(level1Id)].
                               Children[0].
                               Children[0].Data.name;

            level2Entry.id = randomPosition;

            return level2Entry;

            //bool doAgain = true;
            //string level2Id = new string("");
            //while (doAgain == true)
            //{
            //    //string level1Id = deweyTree.Root.Children[GetRandomTreePosition(deweyTree.Root)].Data.id; // Selects random from first level 278 = 2

            //    level2Id = deweyTree.Root.Children[GetRandomTreePosition(deweyTree.Root.Children[Convert.ToInt32(level1Id)])].Data.id;
            //    // Selects random from second level 278 = 7

            //    //level3Id = deweyTree.Root.Children[GetRandomTreePosition(deweyTree.Root.Children[Convert.ToInt32(level1Id)].
            //    //                                 Children[Convert.ToInt32(level2Id)])].Data.id; // Selects random from third level 278 = 8

            //    if (level2Id == alreadyGeneratedNumber)
            //    {
            //        doAgain = true;
            //    }
            //    else
            //    {
            //        doAgain = false;
            //    }
            //}

            //Category randomLevel2Entry = new Category();

            //randomLevel2Entry.name = deweyTree.Root.Children[Convert.ToInt32(level1Id)].
            //                                        Children[Convert.ToInt32(level2Id)].
            //                                        Children[Convert.ToInt32(0)].Data.name;

            //string randomPosition = level1Id + "" + level2Id + "0";
            //randomLevel2Entry.id = randomPosition;

            //return randomLevel2Entry;
        }

        public Category RandomLevel1FromTree(string position)
        {
            int positionInt = Convert.ToInt32(position);

            string level1Id = deweyTree.Root.Children[positionInt].Data.id;

            Category level1Entry = new Category();

            level1Entry.name = deweyTree.Root.Children[Convert.ToInt32(level1Id)].
                               Children[0].
                               Children[0].Data.name;

            level1Entry.id = level1Id + "00";

            return level1Entry;

            //bool doAgain = true;
            //while (doAgain == true)
            //{
            //level1Id = deweyTree.Root.Children[GetRandomTreePosition(deweyTree.Root)].Data.id;

            //    if (level1Id == alreadyGeneratedNumber)
            //    {
            //        doAgain = true;
            //    }
            //    else
            //    {
            //        doAgain = false;
            //    }
            //}
        }

        Random random = new Random();
        List<int> randomNumbers;

        public string[] NumberGenerator4from4()
        {
            string[] numbers = new string[4];
            //https://www.codegrepper.com/code-examples/csharp/random+number+1+to+1000+c%23

            randomNumbers = Enumerable.Range(0, 4).OrderBy(x => random.Next()).Take(4).ToList();
            // https://stackoverflow.com/questions/26931528/random-number-generator-with-no-duplicates

            for (int i = 0; i < 4; i++)
            {
                numbers[i] = randomNumbers.ElementAt(i).ToString(); //random.Next(0, 9);
                // https://stackoverflow.com/questions/15456845/getting-a-list-item-by-index
            }

            return numbers;
        }

        public string[] NumberGenerator4from7()
        {
            string[] numbers = new string[4];
            //https://www.codegrepper.com/code-examples/csharp/random+number+1+to+1000+c%23

            randomNumbers = Enumerable.Range(0, 6).OrderBy(x => random.Next()).Take(4).ToList();
            // https://stackoverflow.com/questions/26931528/random-number-generator-with-no-duplicates

            for (int i = 0; i < 4; i++)
            {
                numbers[i] = randomNumbers.ElementAt(i).ToString(); //random.Next(0, 9);
                // https://stackoverflow.com/questions/15456845/getting-a-list-item-by-index
            }

            return numbers;
        }

        public string[] NumberGenerator4from10()
        {
            string[] numbers = new string[4];
            //https://www.codegrepper.com/code-examples/csharp/random+number+1+to+1000+c%23

            randomNumbers = Enumerable.Range(0, 9).OrderBy(x => random.Next()).Take(4).ToList();
            // https://stackoverflow.com/questions/26931528/random-number-generator-with-no-duplicates

            for (int i = 0; i < 4; i++)
            {
                numbers[i] = randomNumbers.ElementAt(i).ToString(); //random.Next(0, 9);
                // https://stackoverflow.com/questions/15456845/getting-a-list-item-by-index
            }

            return numbers;
        }

        //Category RandomLevel2FromTree(string alreadyGeneratedNumber)
        //{
        //    string level1Id = new string("");
        //    string level2Id = new string("");

        //    bool doAgain = true;

        //    while (doAgain == true)
        //    {
        //        level1Id = deweyTree.Root.Children[GetRandomTreePosition(deweyTree.Root)].Data.id;

        //        if (level1Id == alreadyGeneratedNumber)
        //        {
        //            doAgain = true;
        //        }
        //        else
        //        {
        //            doAgain = false;
        //        }
        //    }

        //    doAgain = true;

        //    while (doAgain == true)
        //    {
        //        level2Id = deweyTree.Root.Children[GetRandomTreePosition(deweyTree.Root.Children[Convert.ToInt32(level1Id)])].Data.id;

        //        if (level2Id == alreadyGeneratedNumber)
        //        {
        //            doAgain = true;
        //        }
        //        else
        //        {
        //            doAgain = false;
        //        }
        //    }

        //    Category level1Entry = new Category();

        //    level1Entry.name = deweyTree.Root.Children[Convert.ToInt32(level1Id)].
        //                       Children[Convert.ToInt32(level1Id)].
        //                       Children[0].Data.name;

        //    level1Entry.id = level1Id + "00";

        //    return level1Entry;
        //}

        public Category FindCategory(string id, int level)
        {
            int firstNumber = Convert.ToInt32(id.Substring(0, 1));
            int secondNumber = Convert.ToInt32(id.Substring(1, 1));
            int thirdNumber = Convert.ToInt32(id.Substring(2, 1));

            Category level1Entry = new Category();

            if (level == 0)
            {
                level1Entry.name = deweyTree.Root.Children[firstNumber].
                                   Children[0].
                                   Children[0].Data.name;

                level1Entry.id = firstNumber + "00";
            }
            else if (level == 1)
            {
                level1Entry.name = deweyTree.Root.Children[firstNumber].
                                   Children[secondNumber].
                                   Children[0].Data.name;

                level1Entry.id = firstNumber + "" + secondNumber + "0";
            }
            else
            {
                level1Entry.name = deweyTree.Root.Children[firstNumber].
                                   Children[secondNumber].
                                   Children[thirdNumber].Data.name;

                level1Entry.id = id;
            }

            return level1Entry;
        }
    }
}
