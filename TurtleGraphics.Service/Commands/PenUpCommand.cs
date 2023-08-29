using TurtleGraphics.Tests;

namespace TurtleGraphics.Service.Commands
{
    internal class PenUpCommand : ICommand
    {
        public void Execute(GraphicsTool graphicsTool)
        {
            graphicsTool.IsPenDown = false;
        }
    }
}