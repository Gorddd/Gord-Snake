using System;
using System.Threading;
using System.IO;


namespace GordSnake
{
    class Program
    {
        static int Record;

        static void ShowScore(int score)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(0, 19);
            Console.Write($"Score: {score} Record: {Record}");
        }

        static void ReadRecord()
        {
            var sr = new StreamReader("Record.txt", false);
            Record = Convert.ToInt32(sr.ReadToEnd());
            sr.Close();
        }

        static void WriteNewRecord()
        {
            var sw = new StreamWriter("Record.txt");
            sw.Write(Record);
            sw.Close();
        }

        static void Main()
        {
            Console.CursorVisible = false;

            int score = 0;
            ReadRecord();

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
            if (score > Record)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"New record: {score} Old record: {Record}");
                Record = score;
                WriteNewRecord();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Your score: {score} Record: {Record}");
            }
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
