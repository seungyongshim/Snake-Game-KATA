using FluentAssertions;
using Xunit;
using System.Linq;

namespace Snake.Tests
{
    public class SnakeSpec
    {
        [Fact]
        public void Should_Be_Move_Right()
        {
            // arrange
            var snake = new Snake(5, 5);

            // act
            snake.Move();

            // assert
            snake.Body.ToArray().Should().BeEquivalentTo(new[] { (5, 6) });
        }

        [Fact]
        public void Should_Be_Move_Left()
        {
            // arrange
            var snake = new Snake(4, 5)
            {
                Head = Direction.Left
            };

            // act
            snake.Move();

            // assert
            snake.Body.ToArray().Should().BeEquivalentTo(new[] { (4, 4) });
        }

        [Fact]
        public void Should_Be_Move_Up()
        {
            // arrange
            var snake = new Snake(2, 3)
            {
                Head = Direction.Up
            };

            // act
            snake.Move();

            // assert
            snake.Body.ToArray().Should().BeEquivalentTo(new[] { (1, 3) });
        }

        [Fact]
        public void Should_Be_Move_Down()
        {
            // arrange
            var snake = new Snake(4, 7)
            {
                Head = Direction.Down
            };

            // act
            snake.Move();

            // assert
            snake.Body.ToArray().Should().BeEquivalentTo(new[] { (5, 7) });
        }
    }
}