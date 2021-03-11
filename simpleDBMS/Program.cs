using System;

namespace simpleDBMS
{
    class Program
    {
        public enum MetaCommandResult
        {
            META_COMMAND_SUCCESS,
            META_COMMAND_UNRECOGNIZED_COMMAND
        }


        static void Main(string[] args)
        {
            string inputBuffer = null;
            while (true)
            {
                Console.WriteLine("db > ");
                inputBuffer = Console.ReadLine();
                if (String.Compare(inputBuffer, ".exit") == 0)
                {
                    Environment.Exit(-1);
                }
                else
                {
                    Console.WriteLine("Unrecognized command {0}", inputBuffer);
                }
            }
        }
    }
}
