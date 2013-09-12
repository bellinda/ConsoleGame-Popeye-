using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace ConsoleGame
{
    class PrintInscriptions
    {
        static int row = 2;
        static int col = 40;
        public static void SetIntroPositionsAndColors()
        {
            try
            {
                StreamReader picture = new StreamReader(@"..\..\popeyePicture.txt"); //the file should be added in the Debug-folder
                using (picture)
                {
                    Console.WindowHeight = Console.BufferHeight = Console.LargestWindowHeight;
                    Console.WindowWidth = Console.BufferWidth = Console.LargestWindowWidth;
                    Console.CursorVisible = false;
                    Console.ForegroundColor = ConsoleColor.White;
                    string line = picture.ReadLine();
                    while (line != null)
                    {
                        Console.WriteLine(line);
                        line = picture.ReadLine();
                    }
                    PrintNiceAlphabet("do you know who i am", col, row, ConsoleColor.DarkGreen);
                    Thread.Sleep(1000);
                    row = 20;
                    col = 60;
                    PrintNiceAlphabet("i am popeye", col, row, ConsoleColor.Green);
                    Thread.Sleep(1000);
                    row = 35;
                    col = 25;
                    PrintNiceAlphabet("the spinach destroyer", col, row, ConsoleColor.DarkGreen);
                    Thread.Sleep(2000);
                    Console.ResetColor();

                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Missing file with the popeye picture!");
            }
            Console.Clear();
            StreamReader pictureAgain = new StreamReader(@"..\..\popeyePicture.txt");
            using (pictureAgain)
            {
                string line = pictureAgain.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = pictureAgain.ReadLine();
                }
                ConsoleGame.PrintOnStringPosition(40, 5, "S, P, I, N, A, C, H - bonus (10 points)", ConsoleColor.Green);
                ConsoleGame.PrintOnStringPosition(40, 10, "B - bomb (clean the screen)", ConsoleColor.Blue);
                ConsoleGame.PrintOnStringPosition(40, 15, "#,@,*,& - enemys", ConsoleColor.Red);
                ConsoleGame.PrintOnStringPosition(40, 20, "Every 200 points - new live (in case you have less than 3 lives", ConsoleColor.Gray);
                ConsoleGame.PrintOnStringPosition(40, 25, @"Every whole collected word ""SPINACH"" - next level", ConsoleColor.Gray);
                ConsoleGame.PrintOnStringPosition(40, 30, @"With every new level => increasing the speed", ConsoleColor.Gray);
                ConsoleGame.PrintOnStringPosition(40, 35, @"Press [Spacebar] for #pause# in the game", ConsoleColor.Red);
                Thread.Sleep(4000);
                col = 35;
                PrintNiceAlphabet("lets dance", col, row + 5, ConsoleColor.Blue);
                Thread.Sleep(3500);
                row = 2;
                col = 40;
            }
        }

        public static void PrintNiceAlphabet(string str, int col, int row, ConsoleColor color)
        {
            str = str.ToLower();
            int wordCounter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                int indexCurrentLetter = (int)str[i] - 97;
                string currentLetter = String.Empty;
                if (row == 35 || row == 25)
                {
                    if (col >= 135)
                    {
                        col = 45;
                        row += 10;
                        Console.SetCursorPosition(col, row);
                    }
                    else
                    {
                        Console.SetCursorPosition(col, row);
                    }
                }
                else
                {
                    if (wordCounter < 3)
                    {
                        Console.SetCursorPosition(col, row);
                    }
                    else
                    {
                        col = 40;
                        row = 10; ;
                        Console.SetCursorPosition(col, row);
                        wordCounter = 0;
                    }
                }
                if (str[i] == ' ')
                {
                    col += 5;
                    wordCounter++;
                }
                else
                {
                    currentLetter = Alphabet.alphabet[indexCurrentLetter];
                    ConsoleGame.PrintOnStringPosition(col, row, currentLetter, color);
                    if (str[i] == 'w')
                    {
                        col += 12;
                    }
                    else
                    {
                        col += 10;
                    }
                    if (str[i] == ' ')
                    {
                        col += 4;
                    }
                }
            }
        }
    }
}
