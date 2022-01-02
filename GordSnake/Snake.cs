using System;
using System.Collections.Generic;

namespace GordSnake
{
    public class Snake
    {
        private const ConsoleColor headColor = ConsoleColor.DarkYellow;
        private const ConsoleColor bodyColor = ConsoleColor.Yellow;

        public Snake(int headX, int headY)
        {
            body.Enqueue(new Pixel(headX + 2, headY, bodyColor, PixelChars.Snake));
            body.Enqueue(new Pixel(headX + 1, headY, bodyColor, PixelChars.Snake));
            
            Head = new Pixel(headX, headY, headColor, PixelChars.Snake);
        }

        public Queue<Pixel> body = new Queue<Pixel>();
        public Pixel Head { get; private set; }


        public void Draw()
        {
            Head.Draw();

            foreach (var pixel in body)
            {
                pixel.Draw();
            }
        }

        public void Clear()
        {
            Head.Clear();

            foreach (var pixel in body)
            {
                pixel.Clear();
            }
        }


        public void Move(Direction direction, bool isEating)
        {
            Clear();

            body.Enqueue(new Pixel(Head.X, Head.Y, bodyColor, PixelChars.Snake));
            if(!isEating)
                body.Dequeue();

            switch (direction)
            {
                case Direction.Up:
                    Head = new Pixel(Head.X, Head.Y - 1, headColor, PixelChars.Snake);
                    break;
                case Direction.Right:
                    Head = new Pixel(Head.X + 1, Head.Y, headColor, PixelChars.Snake);
                    break;
                case Direction.Down:
                    Head = new Pixel(Head.X, Head.Y + 1, headColor, PixelChars.Snake);
                    break;
                case Direction.Left:
                    Head = new Pixel(Head.X - 1, Head.Y, headColor, PixelChars.Snake);
                    break;
            }

            Draw();
        }
    }
}
