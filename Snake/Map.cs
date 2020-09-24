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
        public Snake Snake { get; private set; }
        public (int Y, int X) ApplePos { get; internal set; }
        public bool IsNotGameOver { get; internal set; } = true;

        public override string ToString()
        {
            return Join(',', GetResult());
        }

        internal IEnumerable<Item> GetResult()
        {
            var Items = new Item[Height, Width];

            if (Snake != null)
            {
                foreach (var (y, x) in Snake.Body)
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

        internal void Update(Snake snake)
        {
            Snake = snake;
        }

        public void MakeApple()
        {
            var Rand = new Random();

            (int, int) make()
            {
                var apple = (Rand.Next(0, Height), Rand.Next(0, Width));

                if (Snake.Body.Any(x => x == apple))
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

        public void GenerateSnake()
        {
            var x = Math.Abs(Width / 2);
            var y = Math.Abs(Height / 2);

            Snake = new Snake(y, x);
            Snake.Move((y, x + 1));
        }

        public void SnakeMove()
        {
            var (ateApple, crashBody) = Snake.Move(ApplePos);

            if (ateApple)
            {
                MakeApple();
            }

            IsNotGameOver = !crashBody;
            
        }
    }
}