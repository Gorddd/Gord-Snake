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

            //Font.SetConsoleFont();
            //int value = 977788899;
            //Console.OutputEncoding = Encoding.UTF8;
            //Console.WriteLine("Price: " + value.ToString("C", CultureInfo.CreateSpecificCulture("fr-FR")));

            Console.ReadKey();
        }
    }
}
