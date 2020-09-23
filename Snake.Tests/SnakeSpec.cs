using FluentAssertions;
using System.Linq;
using Xunit;

namespace Snake.Tests
{
    public class SnakeSpec
    {
        [Fact]
        public void Should_Be_Move_Down()
        {
            // arrange
            var snake = new Snake(4, 7)
            {
                Direction = Direction.Down
            };

            // act
            snake.Move();

            // assert
            snake.Body.ToArray().Should().BeEquivalentTo(new[] { (5, 7) });
        }

        [Fact]
        public void Should_Be_Move_Down_And_Eat_Apple()
        {
            // arrange
            var snake = new Snake(4, 7)
            {
                Direction = Direction.Down
            };

            // act
            snake.Move(Apple.Exist);

            // assert
            snake.Body.ToArray().Should().BeEquivalentTo(new[] { (4, 7), (5, 7) });
        }

        [Fact]
        public void Should_Be_Move_Left()
        {
            // arrange
            var snake = new Snake(4, 5)
            {
                Direction = Direction.Left
            };

            // act
            snake.Move();

            // assert
            snake.Body.ToArray().Should().BeEquivalentTo(new[] { (4, 4) });
        }

        [Fact]
        public void Should_Be_Move_Left_And_Eat_Apple()
        {
            // arrange
            var snake = new Snake(4, 5)
            {
                Direction = Direction.Left
            };

            // act
            snake.Move(Apple.Exist);

            // assert
            snake.Body.ToArray().Should().BeEquivalentTo(new[] { (4, 5), (4, 4) });
        }

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
        public void Should_Be_Move_Right_And_Eat_Apple()
        {
            // arrange
            var snake = new Snake(5, 5);

            // act
            snake.Move(Apple.Exist);

            // assert
            snake.Body.ToArray().Should().BeEquivalentTo(new[] { (5, 5), (5, 6) });
        }

        [Fact]
        public void Should_Be_Move_Up()
        {
            // arrange
            var snake = new Snake(2, 3)
            {
                Direction = Direction.Up
            };

            // act
            snake.Move();

            // assert
            snake.Body.ToArray().Should().BeEquivalentTo(new[] { (1, 3) });
        }

        [Fact]
        public void Should_Be_Move_Up_And_Eat_Apple()
        {
            // arrange
            var snake = new Snake(2, 3)
            {
                Direction = Direction.Up
            };

            // act
            snake.Move(Apple.Exist);

            // assert
            snake.Body.ToArray().Should().BeEquivalentTo(new[] { (2, 3), (1, 3) });
        }
    }
}