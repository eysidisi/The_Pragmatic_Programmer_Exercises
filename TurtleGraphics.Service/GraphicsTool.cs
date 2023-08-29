using System.Security.Cryptography;

namespace TurtleGraphics.Tests
{
    public class GraphicsTool
    {
        private const int DefaultPenNumber = 1;

        public int PenNumber { get; set; } = DefaultPenNumber;
        public bool IsPenDown { get; set; }
        public ICommandParser CommandParser { get; }
        public Coordinate PenPosition { get; private set; }
        private byte[,] canvas;

        public GraphicsTool(ICommandParser commandParser)
        {
            canvas = new byte[21, 21];
            PenPosition = new Coordinate(10, 10);
            CommandParser = commandParser;
        }

        public void ExecuteCommand(string commandStr)
        {
            ICommand command = CommandParser.Parse(commandStr);
            command.Execute(this);
        }

        private void DrawLine(int startX, int startY, int endX, int endY)
        {
            int stepX = Math.Sign(endX - startX);
            int stepY = Math.Sign(endY - startY);

            for (int x = startX; x != endX; x += stepX)
            {
                canvas[x, startY] = (byte)PenNumber;
            }
            for (int y = startY; y != endY; y += stepY)
            {
                canvas[startX, y] = (byte)PenNumber;
            }
            canvas[endX, endY] = (byte)PenNumber;
        }

        public void Move(int distanceX, int distanceY)
        {
            int endX = PenPosition.X + distanceX;
            int endY = PenPosition.Y + distanceY;

            if (IsPenDown)
                DrawLine(PenPosition.X, PenPosition.Y, endX, endY);

            PenPosition = new Coordinate(endX, endY);
        }

        public byte[,] GetCanvas()
        {
            return canvas;
        }
    }
}
