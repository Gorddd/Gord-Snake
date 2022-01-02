using System;


namespace GordSnake
{
    public class Area
    {
        private int mapWidth;
        private int mapHeight;

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
    }
}
