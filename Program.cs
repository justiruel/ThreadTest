using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            //Thread.Sleep(5000);


            //Thread thr = new Thread(new ThreadStart(Loop1));
            //thr.Start();

            //Thread thr2 = new Thread(new ThreadStart(Loop2));
            //thr2.Start();

            var allObjectAttributes = Task.WhenAll(
                Task.Run(() => Loop1()),
                Task.Run(() => Loop2())
            );

            await allObjectAttributes.ContinueWith(x =>
            {
                stopwatch.Stop();
                Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            });

            //for (var x = 0; x < 10000; x++)
            //{
            //    var q = x;
            //    Console.WriteLine("Loop1" + q);
            //}

            //for (var x = 0; x < 10000; x++)
            //{
            //    var q = x;
            //    Console.WriteLine("Loop2" + q);
            //}



            //stopwatch.Stop();

            //Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
        }


        static void Loop1() {
            long n1 = 0, n2 = 1, n3;
            string result = n1.ToString() + "," + n2.ToString()+",";
            for (var x = 2; x < 1000; x++)
            {
                n3 = n1 + n2;
                result += n3 + ",";
                n1 = n2;
                n2 = n3;
            }
            Console.WriteLine("result1=>"+result);
        }

        static void Loop2()
        {
            long n1 = 0, n2 = 1, n3;
            string result = n1.ToString() + "," + n2.ToString() + ",";
            for (var x = 2; x < 10; x++)
            {
                n3 = n1 + n2;
                result += n3 + ",";
                n1 = n2;
                n2 = n3;
            }
            Console.WriteLine("result2=>" + result);
        }
    }
}
