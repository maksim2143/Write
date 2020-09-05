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
            BaseJsonSave<BaseJson> baseJson = new BaseJsonSave<BaseJson>("save.txt");
            BaseJson baseJson1 = new BaseJson();
            baseJson.Add(baseJson1); //Добавляем в очеридь на обработку
             BaseJson baseJson2 = new BaseJson();
            baseJson.Add(baseJson2);
            BaseJson baseJson3 = new BaseJson();
            baseJson.Add(baseJson3);
            baseJson1.info.Enqueue("1");
            baseJson2.info.Enqueue("2");
            baseJson3.info.Enqueue("3");
            Console.WriteLine("OK");
            Console.ReadKey();
            baseJson.Dispose();
            Console.WriteLine("OK_TWO");
            Console.ReadKey();

        }
    }
}
