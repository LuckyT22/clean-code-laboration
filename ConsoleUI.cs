namespace laboration
{
    public class ConsoleUI
    {
        public string ReadInput(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }

        public void WriteOutput(string message)
        {
            Console.WriteLine(message);
        }
    }
}