using System;

namespace AgitoChallenge
{
    class Program
    {
        private const int ARRAY_LENGTH = 9;
        private const string ENTRY_STRING = "abccddbeea";

        static void Main(string[] args)
        {
            Console.WriteLine("İlk soru:");
            QuestionOne();
            Console.WriteLine("------------------------------------\nİkinci Soru:");
            QuestionTwo();
            Console.ReadLine();
        }

        private static void QuestionTwo()
        {
            char[] chars = ENTRY_STRING.ToCharArray();
            char[] addedChars = new char[0];
            int minusScoreCount = 0;

            for (int i = 0; i < chars.Length; i++)
            {
                if (CheckIfCharExists(addedChars, chars[i]))
                {
                    minusScoreCount--;
                }
                else
                {
                    PrintMinuses(minusScoreCount);
                    Console.WriteLine(chars[i]);
                    minusScoreCount++;
                    addedChars = AddToAddedChars(addedChars, chars[i]);
                }
            }
        }

        private static char[] AddToAddedChars(char[] addedChars, char c)
        {
            char[] newChars = new char[addedChars.Length + 1];
            for (int i = 0; i < addedChars.Length; i++)
            {
                newChars[i] = addedChars[i];
            }

            newChars[newChars.Length - 1] = c;

            return newChars;
        }

        private static void PrintMinuses(int minusScoreCount)
        {
            for (int i = 0; i < minusScoreCount; i++)
            {
                Console.Write("-");
            }
        }

        private static bool CheckIfCharExists(char[] chars, char c)
        {
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i].Equals(c))
                {
                    return true;
                }
            }

            return false;
        }

        private static void QuestionOne()
        {
            Random rnd = new Random();
            int[] numbers = new int[ARRAY_LENGTH];
            int currentNumber = 0;
            int currentIndex = 0;
            int counter = 0;

            while (numbers[ARRAY_LENGTH - 1] == 0)
            {
                currentNumber = rnd.Next(1, ARRAY_LENGTH + 1);
                if (!DoesArrayContainTheNumber(numbers, currentNumber))
                {
                    numbers[currentIndex] = currentNumber;
                    currentIndex++;
                }

                counter++;
            }

            Print(numbers, counter);
        }

        public static void Print(int[] numbers, int counter)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                Console.Write($"{numbers[i]}, ");
            }

            Console.WriteLine($"{numbers[numbers.Length - 1]} Random fonksiyonu {counter} kere çalışmıştır.");
        }

        public static bool DoesArrayContainTheNumber(int[] numbers, int number)
        {
            foreach (int num in numbers)
            {
                if (num == number)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
