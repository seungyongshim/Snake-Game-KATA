using System.Linq;

namespace Snake
{
    using static System.String;

    public class Map
    {
        public Map(int height, int width)
        {
            Height = height;
            Width = width;
        }

        public int Height { get; }
        public int Width { get; }
        
        
        public override string ToString()
        {
            var Items = new Item[Height][];

            for (var i = 0; i < Height; i++)
            {
                Items[i] = new Item[Width];
            }

            return Items.Select(y => y.Aggregate(Empty, (c, i) => c + i + " "))
                        .Aggregate(Empty, (c, i) => c + i + "\n");
        }

        public struct Item
        {
            public override string ToString()
            {
                return ".";
            }
        }
    }
}