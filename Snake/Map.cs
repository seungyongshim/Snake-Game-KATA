namespace Snake
{
    public class Map
    {
        public Map(int height, int width)
        {
            Height = height;
            Width = width;
        }

        public int Height { get; }
        public int Width { get; }

        private class Item
        {
        }
    }
}