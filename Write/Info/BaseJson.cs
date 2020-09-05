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
        }
    }
}
