using System;
using System.Globalization;
using System.Text;

namespace GordSnake
{
    class Program
    {
        static void Main()
        {
            Console.CursorVisible = false;

            var area = new Area(30, 20);
            var snake = new Snake(15, 15);

            while (true)
            {
                area.DrawBorder();
                snake.Draw();


                Console.ReadKey();
            }

            

            
        }
    }
}
