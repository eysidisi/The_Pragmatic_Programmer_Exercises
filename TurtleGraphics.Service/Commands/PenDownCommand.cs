using TurtleGraphics.Tests;

namespace TurtleGraphics.Service.Commands
{
    internal class PenDownCommand : ICommand
    {
        public void Execute(GraphicsTool graphicsTool)
        {
            graphicsTool.IsPenDown = true;
        }
    }
}