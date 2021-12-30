using System;


namespace GordSnake
{
    public class Area
    {
        private int mapWidth;
        private int mapHeight;

        public Area(int mapWidth, int mapHeight)
        {
            Console.CursorVisible = false;
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;

            Console.SetWindowSize(mapWidth, mapHeight);
            Console.SetBufferSize(mapWidth, mapHeight);
        }
    }
}
