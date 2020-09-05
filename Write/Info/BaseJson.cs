using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Write
{
    class BaseJson : IBaseJson
    {
        public ConcurrentQueue<string> info { set; get; }
        public BaseJson()
        {
            this.info = new ConcurrentQueue<string>();
            for (int i = 0; i < 10; i++)
            {
                info.Enqueue("Thread:"+Thread.CurrentThread.ManagedThreadId+" "+i);
            }
        }
    }
}
