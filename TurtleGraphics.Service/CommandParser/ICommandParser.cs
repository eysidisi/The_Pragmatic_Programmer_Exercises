namespace TurtleGraphics.Tests
{
    public interface ICommandParser
    {
        ICommand Parse(string commandStr);
    }
}