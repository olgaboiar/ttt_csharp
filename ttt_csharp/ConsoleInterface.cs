using System;

namespace ttt_csharp
{
    public class ConsoleInterface : IUserInterface
    {
        public void Output(string message)
        {
            Console.WriteLine(message);
        }

        public string ReadInput()
        {
            return Console.ReadLine();
        }
    }
}