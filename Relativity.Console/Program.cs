using Relativity.Agents;
using System;

namespace RelativityAgentConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var helper = new FakeHelper();
            var agent = new DocumentLoggerAgentLocal(helper);

            agent.Execute();

            Console.WriteLine("Execution complete.");
            Console.ReadLine();
        }
    }
}
