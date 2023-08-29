using TurtleGraphics.Service.Commands;

namespace TurtleGraphics.Tests
{
    public class DefaultParser : ICommandParser
    {
        public ICommand Parse(string commandStr)
        {
            var parsedCommand = commandStr.Split(' ');

            if (parsedCommand[0] == "P")
            {
                return new PenSelectCommand(int.Parse(parsedCommand[1]));
            }
            else if (parsedCommand[0] == "D")
            {
                return new PenDownCommand();
            }
            else if (parsedCommand[0] == "U")
            {
                return new PenUpCommand();
            }
            else if (parsedCommand[0] == "W" || parsedCommand[0] == "E" || parsedCommand[0] == "S" || parsedCommand[0] == "N")
            {
                return new PenMoveCommand(parsedCommand[0], int.Parse(parsedCommand[1]));
            }
            else
            {
                throw new Exception("Invalid command");
            }
        }
    }
}