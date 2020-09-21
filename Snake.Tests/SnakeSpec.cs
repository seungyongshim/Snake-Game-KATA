using FluentAssertions;
using Xunit;

namespace Snake.Tests
{
    public class SnakeSpec
    {
        [Fact]
        public void Should_Be_Right_Forward_Move()
        {
            // arrange
            var snake = new Snake(5, 5);

            // act
            snake.Move();

            // assert
            snake.Body.ToArray().Should().BeEquivalentTo(new[] { (5, 6) });
        }
    }
}