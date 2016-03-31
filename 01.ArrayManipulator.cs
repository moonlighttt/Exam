using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ArrayManipulator
{
    using System.Globalization;
    using System.Threading;

    class Program
    {
        public static List<int> numbers = new List<int>();
        public static  List<string> output = new List<string>();
        
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            numbers = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            string inputCommands = Console.ReadLine();
            List<string> words = inputCommands.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
            int exchangeNum ;
            int count;

            while (words[0] != "end")
            {
                switch (words[0])
                {
                    case "exchange" :
                        exchangeNum = Convert.ToInt32(words[1]); 
                        ExchangeTheList(exchangeNum);
                        break;
                    case "max":
                        if (words[1] == "even")
                        {
                            ReturnIndexOfMaxEvenElement();
                        }
                        else if (words[1] == "odd")
                        {
                            ReturnIndexOfMaxOddElement();
                        }
                        break;
                    case "min":
                        if (words[1] == "even")
                        {
                            ReturnIndexOfMinEvenElement();
                        }
                        else if (words[1] == "odd")
                        {
                            ReturnIndexOfMinOddElement();
                        }
                        break;
                    case "first":
                        count = Convert.ToInt32(words[1]);
                        if (words[2] == "even")
                        {
                            ReturnFirstEvenEllement(count);
                             
                        }
                        else if (words[2] == "odd")
                        {
                            ReturnFirstOddEllement(count);
                        }

                        break;
                    case "last":
                        count = Convert.ToInt32(words[1]);

                        if (words[2] == "even")
                        {
                            ReturnLastEvenEllement(count);
                        }
                        else if (words[2] == "odd")
                        {
                           ReturnLastOddEllement(count);
                        }
                        break;
                }

                input = Console.ReadLine();
                words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            foreach (var VARIABLE in output)
            {
                Console.WriteLine(VARIABLE);
            }

            Console.WriteLine("[" + string.Join(", ", numbers) + "]");
        }

        private static void ReturnLastOddEllement(int count)
        {
            var lastOddEllements = numbers
                .FindAll(num => num % 2 != 0)
                .ToList();
            
            if ( count <= numbers.Count && count > -1)
            {
                //int skipEllemnts = lastOddEllements.Count - count;
                //lastOddEllements.Skip(skipEllemnts);
                for (int i = 0; i < lastOddEllements.Count() - count; i++)
                {
                    lastOddEllements.RemoveAt(i);
                }

                output.Add("[" + string.Join(", ", lastOddEllements) + "]");
            }
            else
            {
                output.Add("Invalid count");
            }
        }

        private static void ReturnLastEvenEllement(int count)
        {
            var lastOddEllements = numbers
                  .FindAll(num => num % 2 == 0)
                  .ToList();
            if (count <= numbers.Count && count > -1)
            {
               // int skipEllemnts = lastOddEllements.Count - count;
               // lastOddEllements.Skip(count);
                for (int i = 0; i < lastOddEllements.Count() - count; i++)
                {
                    lastOddEllements.RemoveAt(i);
                }

                output.Add("[" + string.Join(", ", lastOddEllements) + "]");
            }
            else
            {
                output.Add("Invalid count");
            }
        }

        private static void ReturnFirstEvenEllement(int count)
        {
            var firtsEvenEllements = numbers
                .FindAll(num => num % 2 == 0)
                .Take(count)
                .ToList();

            if (count <= numbers.Count && count > -1)
            {
                //int skipEllemnts = firtsEvenEllements.Count - count;
                //firtsEvenEllements.Skip(count);

                for (int i = firtsEvenEllements.Count() - 1; i > count; i--)
                {
                    firtsEvenEllements.RemoveAt(i);
                }
                output.Add("[" + string.Join(", ", firtsEvenEllements) + "]");
            }
            else
            {
                output.Add("Invalid count");
            }
        }

        private static void ReturnFirstOddEllement(int count)
        {
            var firstOddEllements = numbers
               .Where(num => num % 2 != 0)
               .Take(count)
               .ToList();

            if (count <= numbers.Count && count > -1)
            {
                //int skipEllemnts = firstOddEllements.Count - count;
                //firstOddEllements.Skip(count);

                for (int i = firstOddEllements.Count() - 1; i > count; i--)
                {
                    firstOddEllements.RemoveAt(i);
                }
                output.Add("[" + string.Join(", ", firstOddEllements) + "]");
            }
            else
            {
                output.Add("Invalid count");
            }
        }

        private static void ExchangeTheList(int exchangeNum)
        {
            if (numbers.Count > exchangeNum && exchangeNum > -1)
            {
                List<int> firsrPartOfTheNums = new List<int>();
                List<int> secondPartOfTheNums = new List<int>();

                for (int i = 0; i <= exchangeNum; i++)
                {
                    firsrPartOfTheNums.Add(numbers[i]);
                }
                for (int i = exchangeNum + 1; i < numbers.Count; i++)
                {
                    secondPartOfTheNums.Add(numbers[i]);
                }
                secondPartOfTheNums.AddRange(firsrPartOfTheNums);
                numbers = secondPartOfTheNums;
               
            }
            else
            { 
                output.Add("Invalid index");
            }
        }

        private static void ReturnIndexOfMinOddElement()
        {
            IList<int> minOddsNum = numbers
                .Where(num => num % 2 != 0)
                .OrderBy(num => num)
                .Take(1)
                .ToList();

            if (minOddsNum.Count != 0)
            {
                var indexOfMinOddNum = numbers.LastIndexOf(minOddsNum[0]);

                output.Add(indexOfMinOddNum.ToString());
            }
            else
            {
                string noMathes = "No matches";
                output.Add(noMathes);
            }        
        }

        private static void ReturnIndexOfMinEvenElement()
        {
            IList<int> minEvenNum = numbers
                .Where(num => num % 2 == 0)
                .OrderBy(num => num)
                .Take(1)
                .ToList();

            if (minEvenNum.Count != 0)
            {
               var indexOfMinOddNum = numbers.LastIndexOf(minEvenNum[0]);

                output.Add(indexOfMinOddNum.ToString());
            }
            else
            {
                string noMathes = "No matches";
                output.Add(noMathes);
            }        
        }

        private static void ReturnIndexOfMaxOddElement()
        {
            IList<int> minOddsNum = numbers
                .Where(num => num % 2 != 0)
                .OrderByDescending(num => num)
                .Take(1)
                .ToList();

            if (minOddsNum.Count != 0)
            {
                var indexOfMinOddNum = numbers.LastIndexOf(minOddsNum[0]);

                output.Add(indexOfMinOddNum.ToString());
            }
            else
            {
                string noMathes = "No matches";
                output.Add(noMathes);
            }        
        }

        private static void ReturnIndexOfMaxEvenElement()
        {
            IList<int> minOddsNum = numbers
               .Where(num => num % 2 == 0)
               .OrderByDescending(num => num)
               .Take(1)
               .ToList();

            if (minOddsNum.Count != 0)
            {
               var indexOfMinOddNum = numbers.LastIndexOf(minOddsNum[0]);

                output.Add(indexOfMinOddNum.ToString());
            }
            else
            {
                string noMathes = "No matches";
                output.Add(noMathes);
            } 
        }
    }
}
