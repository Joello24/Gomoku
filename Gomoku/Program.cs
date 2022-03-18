namespace Gomoku
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleIO consoleIO = new ConsoleIO();
            Controller controller = new Controller(consoleIO);
            controller.Run();
        }
    }
}
