using System;
using System.Linq;


namespace GordSnake
{
    public class Area
    {
        private int mapWidth;
        private int mapHeight;

        private Pixel food;

        public Area(int mapWidth, int mapHeight)
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;

            Console.SetWindowSize(mapWidth, mapHeight);
            Console.SetBufferSize(mapWidth, mapHeight);
        }

        public void DrawBorder()
        {
            for (int i = 0; i < mapWidth; i++)
            {
                new Pixel(i, 1, ConsoleColor.Gray, PixelChars.Brick).Draw();
                new Pixel(i, mapHeight - 1, ConsoleColor.Gray, PixelChars.Brick).Draw();
            }

            for (int i = 1; i < mapHeight - 1; i++)
            {
                new Pixel(0, i, ConsoleColor.Gray, PixelChars.Brick).Draw();
                new Pixel(mapWidth - 1, i, ConsoleColor.Gray, PixelChars.Brick).Draw();
            }
        }

        public void CreateFood(Snake snake)
        {
            Random random = new Random();

            do
            {
                food = new Pixel(random.Next(1, mapWidth - 1), random.Next(1, mapHeight - 2), ConsoleColor.Green, PixelChars.Food);
            } while (snake.Head.X == food.X && snake.Head.Y == food.Y
                     || snake.body.Any(b => b.X == food.X && b.Y == food.Y));

            food.Draw();
        }

        public bool EatingCheck(Snake snake, ref int score)
        {
            if (snake.Head.X == food.X && snake.Head.Y == food.Y)
            {
                score++;
                CreateFood(snake);
                return true;
            }

            return false;
        }

        public bool EndingCheck(Snake snake)
        {
            if (snake.Head.X == 0 || snake.Head.Y == 0
             || snake.Head.X == mapWidth - 1 || snake.Head.Y == mapHeight - 2
             || snake.body.Any(b => b.X == snake.Head.X && b.Y == snake.Head.Y))
                return true;

            return false;
        }
    }
}
