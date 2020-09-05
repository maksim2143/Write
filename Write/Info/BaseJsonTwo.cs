using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Write
{
    class BaseJsonTwo : IBaseJson
    {
        public ConcurrentQueue<string> info { set; get; }
        public BaseJsonTwo()
        {
            this.info = new ConcurrentQueue<string>();
            for (int i = 0; i < 10; i++)
            {
                this.info.Enqueue("BaseJsonTwo Thread:" + Thread.CurrentThread.ManagedThreadId + "|" + i);
            }
            
        }
    }
}
