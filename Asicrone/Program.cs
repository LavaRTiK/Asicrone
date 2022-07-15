using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asicrone
{
     class Program
    {
        static void Main(string[] args)
        {
            #region thread
            //Thread thread = new Thread(new ThreadStart(DoWork));
            //thread.Start();

            //Thread thread2 = new Thread(new ParameterizedThreadStart(DoWork2));
            //thread2.Start(int.MaxValue);
            //int j = 0;
            //for (int i = 0; i < int.MaxValue; i++)
            //{
            //    j++;
            //    if (j % 10000 == 0)
            //    {
            //        Console.WriteLine("Main");
            //    }
            //}
            //Console.ReadLine();
            #endregion
            #region async/await
            //Console.WriteLine("Begin mein");
            //DoWorkAsync(1000);
            //Console.WriteLine("Continuan Mein");
            //int j = 0;
            //for (int i = 0; i < 10; i++)
            //{
            //    j++;
            //    Console.WriteLine("Main");
            //}
            //Console.WriteLine("end mein");
            //Console.ReadLine();
            #endregion 
            var result = SaveFileAsync("d:\\test.txt");
            var input = Console.ReadLine(); 
            Console.WriteLine(result.Result);
            Console.ReadLine();

        }
        static async Task<bool> SaveFileAsync(string path)
        {
            var result = await Task.Run(() => SaveFile(path));
            return result;
        }
        static bool  SaveFile(string path)
        {
            var rnd = new Random();
            var text = "";
            for (int i = 0; i < 50000; i++)
            {
                text += rnd.Next();
            }
            using (var sw = new StreamWriter(path, false, Encoding.UTF8))
            {
                sw.WriteLine(text);
            }
            return true;
        }
        static async Task DoWorkAsync(int max)
        {
            Console.WriteLine("Begin asyns");
            await Task.Run(() => DoWork(max)); 
            Console.WriteLine("Do Work Async");
        }

        static void DoWork(int max)
        {
            int j = 0;
            for(int i = 0; i < max; i++)
            {
                Console.WriteLine("do work");
            }
        }
        static void DoWork2(object max)
        {

            int j = 0;
            for (int i = 0; i < (int)max ; i++)
            {
                j++;
                if (j % 10000 == 0)
                {
                    Console.WriteLine("DoWork 2");
                }
            }
        }
    }
}
