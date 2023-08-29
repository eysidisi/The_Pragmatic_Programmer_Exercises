using TurtleGraphics.Tests;

namespace TurtleGraphics.Service.Commands
{
    internal class PenSelectCommand : ICommand
    {
        private int penNumber;

        public PenSelectCommand(int penNumber)
        {
            this.penNumber = penNumber;
        }

        public void Execute(GraphicsTool graphicsTool)
        {
            graphicsTool.PenNumber = penNumber;
        }
    }
}