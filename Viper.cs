using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace Snake
{

    class Viper
    {
        public static bool isEnd;
        public static byte directionTemp;
        private static byte direction;
        int viperLength;
        public byte speed;
        public List<Point> body;
        public int points;

        private void drawHead()
        {
            Console.SetCursorPosition(body[0].X, body[0].Y);
            Console.Write("O");
        }
        public Viper()
        {
            directionTemp = 3;
            this.viperLength = 3;
            body = new List<Point>();
            body.Add(new Point(2, 0));
            body.Add(new Point(1, 0));
            body.Add(new Point(0, 0));
            points = 0;
            isEnd = false;
        }
        public void ViperMovement()
        {

            foreach (var item in this.body)
            {
                Console.SetCursorPosition(item.X, item.Y);
                Console.Write("O");
            }
            while (true)
            {
                switch (directionTemp) 
                {
                    case 6:
                        if (Viper.direction != 12)
                            Viper.direction = directionTemp;
                        break;
                    case 12:
                        if (Viper.direction != 6)
                            Viper.direction = directionTemp;
                        break;
                    case 9:
                        if (Viper.direction != 3)
                            Viper.direction = directionTemp;
                        break;
                    case 3:
                        if (Viper.direction != 9)
                            Viper.direction = directionTemp;
                        break;
                }
                
                switch (direction)
                {
                    case 3:
                        body.Insert(0, new Point(body[0].X + 1, body[0].Y));
                        break;
                    case 6:
                        body.Insert(0, new Point(body[0].X, body[0].Y + 1));
                        break;
                    case 9:
                        body.Insert(0, new Point(body[0].X - 1, body[0].Y));
                        break;
                    case 12:
                        body.Insert(0, new Point(body[0].X, body[0].Y - 1));
                        break;
                }

                for (int i = 1; i <= viperLength; i++)
                {
                    if ((body[0].X == body[i].X && body[0].Y == body[i].Y))
                    {
                        isEnd = true;
                        break;
                    }
                }
                if (isEnd == false)
                    if (body[0].X >= 80 || body[0].X < 0 || body[0].Y >= 24 || body[0].Y < 0)
                    {
                        isEnd = true;
                    }

                if (isEnd == true)
                {
                    Console.Clear();
                    Console.WriteLine($"Ilość zdobytego papu: {this.points}");
                    break;
                }

                if (body[0].X == Food.x && body[0].Y == Food.y)
                {
                    this.points++;
                    this.viperLength++;
                    drawHead();
                    Food.NewFoodAppear(this.body);
                }
                else
                {
                    Console.SetCursorPosition(body[this.viperLength].X, body[this.viperLength].Y);
                    Console.Write(" ");
                    body.RemoveAt(this.viperLength);
                    drawHead();
                }
                Thread.Sleep(1000 / this.speed);
            }
        }


    }
}
