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
            bodyAndHead.Enqueue(new Pixel(headX + 1, headY, bodyColor, PixelChars.Snake));

            Head = new Pixel(headX, headY, headColor, PixelChars.Snake);
            bodyAndHead.Enqueue(Head);
        }

        private Queue<Pixel> bodyAndHead = new Queue<Pixel>();
        public Pixel Head { get; private set; }


        public void Draw()
        {
            foreach (var pixel in bodyAndHead)
            {
                pixel.Draw();
            }
        }

        public void Clear()
        {
            foreach (var pixel in bodyAndHead)
            {
                pixel.Clear();
            }
        }
    }
}
