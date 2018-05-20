using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Snake
{

    class Program
    {

        static void SnakeControl()
        {
            ConsoleKeyInfo dir;

            while (Viper.isEnd == false)
            {
                dir = Console.ReadKey(intercept: true);
                switch (dir.Key)
                {
                    case ConsoleKey.DownArrow:
                        Viper.directionTemp = 6;
                        break;
                    case ConsoleKey.UpArrow:
                        Viper.directionTemp = 12;
                        break;
                    case ConsoleKey.LeftArrow:
                        Viper.directionTemp = 9;
                        break;
                    case ConsoleKey.RightArrow:
                        Viper.directionTemp = 3;
                        break;
                    case ConsoleKey.Escape:
                        Viper.isEnd = true;
                        break;
                    default:
                        break;
                }
            }
        }


        static void Main(string[] args)
        {
            Console.Title = "The O-Adder";
            Viper snake;
            Thread secondThread;
            bool wantToPlay = true;
            bool validSpeed;

            Console.Clear();
            Console.SetWindowSize(80, 24);
            Console.CursorVisible = false;


            while (wantToPlay == true)
            {
                snake = new Viper();
                secondThread = new Thread(SnakeControl);
                do
                {
                    Console.Clear();
                    Console.WriteLine("Wybierz prędkość całkowitą z zakresu 1-20");
                    validSpeed = true;
                    try
                    {
                        snake.speed = Convert.ToByte(Console.ReadLine());
                    }
                    catch (System.FormatException)
                    {
                        validSpeed = false;
                        Console.Clear();
                    }
                    catch (System.OverflowException)
                    {
                        validSpeed = false;
                        Console.Clear();
                    }
                    if (snake.speed > 20 || snake.speed < 1)
                    {
                        validSpeed = false;
                        Console.Clear();
                    }

                } while (validSpeed == false);


                Console.Clear();
                Food.Appear();
                secondThread.Start();
                snake.ViperMovement();
                secondThread.Abort();
                Console.WriteLine("Jeszcze raz?\nT/N");
                ConsoleKeyInfo wannaTryAgain = Console.ReadKey();
                if (wannaTryAgain.Key != ConsoleKey.T)
                    wantToPlay = false;
            }



        }
    }
}

