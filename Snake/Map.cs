using System;
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
        public Snake Snake { get; private set; }

        public override string ToString()
        {
            var Items = new Item[Height][];

            for (var i = 0; i < Height; i++)
            {
                Items[i] = new Item[Width];
            }

            if (Snake != null)
            {
                foreach (var (y, x) in Snake.Body)
                {
                    Items[y][x].SetSnake();
                }
            }

            return Items.Select(y => y.Aggregate(Empty, (c, i) => c + i + " "))
                        .Aggregate(Empty, (c, i) => c + i + "\n");
        }

        public struct Item
        {
            public bool IsSnake { get; private set; }

            public override string ToString()
            {
                return IsSnake? "O": ".";
            }

            public void SetSnake()
            {
                IsSnake = true;
            }
        }

        public void GenerateSnake()
        {
            Snake = new Snake(Math.Abs(Width / 2), Math.Abs(Height / 2));
            Snake.Move(Apple.Exist);
        }

        public void SnakeMove()
        {
            Snake.Move();
        }
    }
}