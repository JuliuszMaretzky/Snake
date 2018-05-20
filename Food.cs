using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Snake
{
    class Food
    {
        public static int x = 40, y = 12;
        static Random rand = new Random();

        public static void Appear()
        {
            Console.SetCursorPosition(x, y);
            Console.Write("X");
        }


        public static void NewFoodAppear(List<Point> body)
        {
            bool ok = true;
            int xx, yy;
            do
            {
                xx = rand.Next(0, 79);
                yy = rand.Next(0, 23);
                foreach (var item in body)
                {
                    if (xx == item.X && yy == item.Y)
                    {
                        ok = false;
                        break;
                    }
                }
            } while (ok == false);
            x = xx;
            y = yy;

            Console.SetCursorPosition(x, y);
            Console.Write("X");
        }
    }
}
