using System;


namespace GordSnake
{
    public static class PixelChars
    {
        public const char Brick = '▓';
        public const char Snake = '@';
    }


    public readonly struct Pixel
    {
        public Pixel(int x, int y, ConsoleColor color, char pixelChar)
        {
            X = x;
            Y = y;
            Color = color;
            PixelChar = pixelChar;
        }

        public int X{ get; }

        public int Y { get; }

        public ConsoleColor Color { get; }

        public char PixelChar { get; }

        public void Draw()
        {
            Console.ForegroundColor = Color;

            Console.SetCursorPosition(X, Y);
            Console.Write(PixelChar);
        }

        public void Clear()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
        }
    }
}
