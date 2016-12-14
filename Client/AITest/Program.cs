using Apache.Ignite.Core;
using Apache.Ignite.Core.Binary;
using Apache.Ignite.Core.Compute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITest
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int biggest = Int32.MinValue;
            var dtgrd = new IgniteConfiguration { BinaryConfiguration = new BinaryConfiguration(typeof(CountFunc)), ClientMode = true };

            using (var ignite = Ignition.Start(dtgrd))
            {

                int n = 5; int m = 5;
                int[][] mas = new int[n][];

                for (int i = 0; i < n; i++)
                {
                    mas[i] = new int[m];
                    for (int j = 0; j < m; j++)
                    {
                        mas[i][j] = r.Next(0, 10); Console.Write(mas[i][j] + " ");
                    }
                    Console.WriteLine();
                }
               

                var res = ignite.GetCompute().Apply(new CountFunc(), mas);

                foreach (var ul in res)
                {
                    if (ul > biggest) {
                        biggest = ul;
                    }                    
                }

                Console.WriteLine("Самый большой элемент строки: " + biggest);
                Console.Read();
            }            
        }
    }

    internal class CountFunc : IComputeFunc<int[], int>
    {
        public int Invoke(int[] arg)
        {            
            return 0;
        }
    }
}
