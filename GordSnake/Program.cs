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
            area.DrawBorder();

            Font.SetConsoleFont();

            Console.ReadKey();
        }
    }
}
