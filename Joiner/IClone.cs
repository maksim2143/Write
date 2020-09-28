using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joiner
{
    public interface IClone
    {
        ConcurrentQueue<string> info { set; get; }
    }
}
