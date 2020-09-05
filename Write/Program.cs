using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Write
{
    class Program
    {
        static void Main(string[] args)
        {
            using (BaseJsonSave<BaseJson> baseJson = new BaseJsonSave<BaseJson>("save.txt")) 
            {
                BaseJson baseJson1 = new BaseJson();
                baseJson.Add(baseJson1);
                List<Task> tasks = new List<Task>();
                for (int b = 0; b < 5; b++)
                {
                   var task =  Task.Run(() =>
                    {
                        for (int i = 0; i < 5; i++)
                        {
                           /// Console.WriteLine("Thread.Sleep(7000)");
                            Thread.Sleep(7000);
                            baseJson1.info.Enqueue($"for = {i} Thread = {Thread.CurrentThread.ManagedThreadId}");
                        }
                    });
                    tasks.Add(task);
                }
                Task.WaitAll(tasks.ToArray());
            }
            Console.WriteLine("OK");
            Console.ReadKey();
        }
    }
}
