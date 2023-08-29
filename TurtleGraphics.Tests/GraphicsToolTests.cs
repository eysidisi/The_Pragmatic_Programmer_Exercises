using Xunit;

namespace TurtleGraphics.Tests
{
    public class GraphicsToolTests
    {
        GraphicsTool graphics;
        public GraphicsToolTests()
        {
            var parser = new DefaultParser();
            graphics = new GraphicsTool(parser);
        }

        [Fact]
        public void CanSelectPen()
        {
            SelectPen2();
            Assert.Equal(2, graphics.PenNumber);
        }

        [Fact]
        public void CanDropPen()
        {
            DropPen();
            Assert.True(graphics.IsPenDown);
        }

        [Fact]
        public void CanMoveUpPen()
        {
            var commandStr = "U";
            graphics.ExecuteCommand(commandStr);
            Assert.False(graphics.IsPenDown);
        }

        [Fact]
        public void CanMovePenWest()
        {
            var commandStr = "W 10";
            graphics.ExecuteCommand(commandStr);
            Assert.Equal(0, graphics.PenPosition.X);
        }

        [Fact]
        public void CanMovePenEast()
        {
            var commandStr = "E 10";
            graphics.ExecuteCommand(commandStr);
            Assert.Equal(20, graphics.PenPosition.X);
        }

        [Fact]
        public void CanMovePenNorth()
        {
            var commandStr = "N 10";
            graphics.ExecuteCommand(commandStr);
            Assert.Equal(20, graphics.PenPosition.Y);
        }

        [Fact]
        public void CanMovePenSouth()
        {
            var commandStr = "S 10";
            graphics.ExecuteCommand(commandStr);
            Assert.Equal(0, graphics.PenPosition.Y);
        }

        [Fact]
        public void CanDrawLine()
        {
            SelectPen2();
            DropPen();
            var commandStr = "W 10";
            graphics.ExecuteCommand(commandStr);
            byte[,] pixels = graphics.GetCanvas();

            for (int i = 0; i <= 10; i++)
            {
                Assert.Equal(2, pixels[i, 10]);
            }
        }

        [Fact]
        public void DrawSquare()
        {
            SelectPen2();
            DropPen();
            var commandStr = "W 10";
            graphics.ExecuteCommand(commandStr);
            commandStr = "N 10";
            graphics.ExecuteCommand(commandStr);
            commandStr = "E 10";
            graphics.ExecuteCommand(commandStr);
            commandStr = "S 10";
            graphics.ExecuteCommand(commandStr);

            byte[,] pixels = graphics.GetCanvas();

            for (int xCoord = 0; xCoord <= 10; xCoord++)
            {
                Assert.Equal(2, pixels[xCoord, 10]);
                Assert.Equal(2, pixels[xCoord, 20]);
            }

            for (int yCoord = 10; yCoord <= 20; yCoord++)
            {
                Assert.Equal(2, pixels[0, yCoord]);
                Assert.Equal(2, pixels[10, yCoord]);
            }
        }

        private void SelectPen2()
        {
            string commandStr = "P 2";
            graphics.ExecuteCommand(commandStr);
        }

        private void DropPen()
        {
            string commandStr = "D";
            graphics.ExecuteCommand(commandStr);
        }
    }
}