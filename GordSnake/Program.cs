using System;
using System.Threading;
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
            area.DrawBorder();
            var snake = new Snake(15, 15);

            Direction direction = Direction.Left;
            while (true)
            {
                direction = Input(direction);

                snake.Move(direction);

                Thread.Sleep(140);
            }
        }

        static Direction Input(Direction currentDirection)
        {
            if (!Console.KeyAvailable)
                return currentDirection;

            ConsoleKey key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (currentDirection != Direction.Down)
                        return Direction.Up;
                    break;
                case ConsoleKey.RightArrow:
                    if (currentDirection != Direction.Left)
                        return Direction.Right;
                    break;
                case ConsoleKey.DownArrow:
                    if (currentDirection != Direction.Up)
                        return Direction.Down;
                    break;
                case ConsoleKey.LeftArrow:
                    if (currentDirection != Direction.Right)
                        return Direction.Left;
                    break;
            }

            return currentDirection;
        }
    }
}
