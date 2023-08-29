using TurtleGraphics.Tests;

namespace TurtleGraphics.Service.Commands
{
    internal class PenMoveCommand : ICommand
    {
        private string direction;
        private int distance;

        public PenMoveCommand(string direction, int distance)
        {
            this.direction = direction;
            this.distance = distance;
        }

        public void Execute(GraphicsTool graphicsTool)
        {
            if (direction == "W" || direction == "E" || direction == "N" || direction == "S")
            {
                int deltaX = 0;
                int deltaY = 0;

                if (direction == "W") deltaX = -distance;
                else if (direction == "E") deltaX = distance;
                else if (direction == "N") deltaY = distance;
                else if (direction == "S") deltaY = -distance;

                graphicsTool.Move(deltaX, deltaY);
            }
            else
            {
                throw new ArgumentException("Invalid direction");
            }
        }
    }
}