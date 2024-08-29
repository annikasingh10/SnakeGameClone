using System;

namespace LAB_4_The_Project
{
    class Program
    {
        static Int32 MeX = 0, MeY = 0, oldMeX, oldMeY;
        static ConsoleKey k = ConsoleKey.NoName;
        const char Cursor = 'X';

        static Random rnd = new Random();

        static int syswidth = Console.WindowWidth;
        static int sysheight = Console.WindowHeight;

        static Int32 points = 0;
        static Int32 ScoreX = 1;
        static Int32 ScoreY = 1;

        static int numtargets = 8;
        static Int32[] targetX = new int[numtargets];
        static Int32[] targetY = new int[numtargets];

        static int badnumtargets = 3;
        static Int32[] badtargetX = new int[numtargets];
        static Int32[] badtargetY = new int[numtargets];

        static Int32 i;
        static bool gameend = false;

        static void Main(string[] args)
        {
            instructions();

            static void instructions()
            {
                do
                {
                    Console.WriteLine("Welcome to the 'X & O' game!");
                    Console.WriteLine(" ");
                    Console.WriteLine("The goal of this game is to collect as many points as you can!");
                    Console.WriteLine("Your character is 'X' and your target points are 'O' ");
                    Console.WriteLine("If you hit the right target, you will get 100 points everytime");
                    Console.WriteLine("But BEWARE! One of the target points is a bad target and if you hit the bad target, it's GAME OVER!");
                    Console.WriteLine(" ");
                    Console.WriteLine("The purpose of this game is to test your guessing skills and your luck!");
                    Console.WriteLine(" ");
                    Console.WriteLine("Press any key to play the game!");
                    getkeystroke();
                } while (k == Console.ReadKey(true).Key);

                Console.Clear();
            }

            for (int j = 0; j < numtargets; j++)
            {
                targetX[j] = rnd.Next(2, syswidth);
                targetY[j] = rnd.Next(0, sysheight);
            }
            for (int j = 0; j < badnumtargets; j++)
            {
                badtargetX[j] = rnd.Next(2, syswidth);
                badtargetY[j] = rnd.Next(0, sysheight);
            }

            {
                MeX = 10;
                MeY = 10;

                Console.CursorVisible = false;
                while (!gameover())
                {
                    getkeystroke();

                    draw();
                }
            }

            static void getkeystroke()
            {
                if (Console.KeyAvailable)
                {
                    k = Console.ReadKey(true).Key;
                    oldMeX = MeX;
                    oldMeY = MeY;
                    move();
                }
            }

            static Boolean gameover()
            {
                bool retval;
                if (k == ConsoleKey.Escape)
                {
                    retval = true;
                }
                else
                {
                    retval = false;
                }
                if (gameend)
                {
                    Console.Clear();
                    Console.WriteLine("Game over! You hit a bad target.");
                    Console.WriteLine(" ");
                    Console.WriteLine("You have collected " + points + " points. Thank you for playing!");
                    Console.WriteLine(" ");
                    Console.WriteLine("Press any key to exit the game.");
                    retval = true;

                }
                return retval;
            }
            static void draw()
            {
                Console.SetCursorPosition(MeX, MeY);
                Console.Write('X');

                Console.SetCursorPosition(oldMeX, oldMeY);
                Console.Write(' ');

                Console.SetCursorPosition(ScoreX, ScoreY);
                Console.Write("Score= " + points);

                for (i = 0; i < numtargets; i++)
                {
                    Console.SetCursorPosition(targetX[i], targetY[i]);
                    Console.Write("O");
                }

                for (i = 0; i < badnumtargets; i++)
                {
                    Console.SetCursorPosition(badtargetX[i], badtargetY[i]);
                    Console.Write("O");
                }
            }

            static void move()
            {

                if (k == ConsoleKey.UpArrow)
                {
                    MeY = MeY - 1;
                }

                if (k == ConsoleKey.LeftArrow)
                {
                    MeX = MeX - 1;

                }

                if (k == ConsoleKey.DownArrow)
                {
                    MeY = MeY + 1;
                }

                if (k == ConsoleKey.RightArrow)
                {
                    MeX = MeX + 1;
                }

                for (int j = 0; j < numtargets; j++)
                {
                    if (MeX == targetX[j] && MeY == targetY[j])
                    {
                        targetX[j] = rnd.Next(2, syswidth); // re-spawn in range of where you can move
                        targetY[j] = rnd.Next(0, sysheight);

                        points = points + 100;

                    }
                }

                if (MeX <= 1)
                {
                    MeX = syswidth - 1;
                }
                if (MeX > (syswidth - 1))
                {
                    MeX = 2;
                }

                if (MeY <= 0)
                {
                    MeY = sysheight - 1;
                }
                if (MeY > (sysheight - 1))
                {
                    MeY = 0;
                }

                for (int j = 0; j < badnumtargets; j++)
                {
                    if (MeX == badtargetX[j] && MeY == badtargetY[j])
                    {
                        gameend = true;
                    }
                }
            }


        }
    }

}


