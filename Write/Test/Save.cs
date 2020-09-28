using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Joiner;

namespace Write.Test
{
    class Save : IClone
    {
        public ConcurrentQueue<string> info { get; set; }
        public void StartWork()
        {
            for (int i = 0; i < 50; i++)
            {
                Thread.Sleep(1200);
                Console.WriteLine(i);
                info.Enqueue(i.ToString());
            }
        }
        public Save()
        {
            this.info = new ConcurrentQueue<string>();
        }
    }
}
