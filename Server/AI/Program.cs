using Apache.Ignite.Core;
using Apache.Ignite.Core.Binary;
using Apache.Ignite.Core.Compute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI
{
    class Program
    {
        static void Main(string[] args)
        {
            var dtgrd = new IgniteConfiguration { BinaryConfiguration = new BinaryConfiguration(typeof(CountFunc)) };

            using(var ignite = Ignition.Start(dtgrd))
            {
                Console.Read();
            }            
        }
    }

    internal class CountFunc : IComputeFunc<int[], int>
    {
        public int Invoke(int[] arg)
        {
            int biggest = Int32.MinValue;
            string arr = "";

            for (int i = 0; i < arg.Length; i++)
            {
                if (arg[i] > biggest) {
                    biggest = arg[i];
                }
                arr += arg[i] + " ";
            }
            Console.WriteLine(arr + " Самый большой элемент строки: " + biggest);

            return biggest;
        }
    }
}
