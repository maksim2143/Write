using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Write
{
    interface IBaseJson
    {
        ConcurrentQueue<string> info { set; get; }
    }
}
