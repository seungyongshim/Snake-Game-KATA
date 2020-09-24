using System;
using System.Collections.Generic;
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
        public ICollection<(int Y, int X)> SnakePos { get;  set; }
        public (int Y, int X) ApplePos { get; internal set; }
        public bool IsNotGameOver { get; internal set; } = true;

        public override string ToString()
        {
            return Join(',', GetResult());
        }

        internal IEnumerable<Item> GetResult()
        {
            var Items = new Item[Height, Width];

            if (SnakePos != null)
            {
                foreach (var (y, x) in SnakePos)
                {
                    Items[y, x].SetSnake();
                }
            }

            if (ApplePos != default)
            {
                Items[ApplePos.Y, ApplePos.X].SetApple();
            }

            return Items.Cast<Item>();
        }

        internal void Update(ICollection<(int , int )> snakePos)
        {
            SnakePos = snakePos;
        }

        public void MakeApple()
        {
            var Rand = new Random();

            (int, int) make()
            {
                var apple = (Rand.Next(0, Height), Rand.Next(0, Width));

                if (SnakePos.Any(x => x == apple))
                {
                    return make();
                }

                return apple;
            }

            ApplePos = make();
        }

        public struct Item
        {
            public bool IsSnake { get; private set; }
            public bool IsApple { get; private set; }

            public override string ToString()
            {
                return IsSnake? "O": 
                       IsApple? "@": ".";
            }

            public void SetSnake()
            {
                IsSnake = true;
            }

            internal void SetApple()
            {
                IsApple = true;
            }
        }
    }
}