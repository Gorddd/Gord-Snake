using System;
using System.Threading;


namespace GordSnake
{
    class Program
    {
        static void ShowScore(int score)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(0, 19);
            Console.Write($"Score: {score}");
        }

        static void Main()
        {
            Console.CursorVisible = false;

            int score = 0;
            var area = new Area(30, 20);
            var snake = new Snake(15, 15);

            area.DrawBorder();
            area.CreateFood(snake);
            
            Direction direction = Direction.Left;
            while (true)
            {
                ShowScore(score);

                direction = Input(direction);

                if (area.EndingCheck(snake))
                    break;
                snake.Move(direction, area.EatingCheck(snake, ref score));


                Thread.Sleep(140);
            }

            Console.SetCursorPosition(0, 19);
            Console.Write($"Your score: {score}");
            Console.ReadKey();
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
