using System;
using System.Diagnostics;
using n.random.generator.Service;

namespace n.random.generator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var sw = new Stopwatch();
                sw.Start();

                // Perform logic
                var service = new Generator();
                var rnl = service.GenerateUniqueRandomNumberList(Convert.ToInt32(args[0]), Convert.ToInt32(args[1]));
                Console.WriteLine(string.Join(", ", rnl));

                sw.Stop();
                Console.WriteLine(sw.Elapsed);
            }
            catch (Exception ex) { Console.WriteLine(string.Format("Failed to generate random number list. Error: {0}", ex.Message)); }
        }
    }
}
