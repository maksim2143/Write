using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Write
{
    class BaseJsonSave<T>:IDisposable where T : IBaseJson
    {
        ~BaseJsonSave()
        {
            if (writer != null) writer.Dispose();
        }
        private  BlockingCollection<T> t;
        protected  void Write()
        {
            foreach (var item in t)
            {
                if (item.info == null) continue;
                while(item.info.Count > 0)
                {
                    if (item.info.TryDequeue(out var result))
                    {
                        Console.WriteLine(result ?? "");
                        writer.WriteLine(result ?? "");
                    }
                }
            }
        }
        protected  void CreateStream(string file)
        {
            if (writer != null) return;
            Stream stream = File.OpenWrite(file);
            stream = Stream.Synchronized(stream);
            writer = new StreamWriter(stream);
        }
        private  StreamWriter writer;
        private  void SetNameFile(string file)
        {
            name_file = file;
        }
         string name_file;
        public  void Add(T value)
        {
            t.Add(value);
        }
         Timer timer;
        private bool disposedValue;
        private  void Create()
        {
            if (timer != null) return;
            timer = new Timer(x=> Write(),null,10000,10000);
        }
        public BaseJsonSave(string file)
        {
            this.SetNameFile(file);
            Start();
            
        }
        private  void Stop()
        {
            Write();
            if (timer != null) timer.Dispose();
            if (writer != null) writer.Dispose();
            t = null;
        }
        private  void Start()
        {
            if (t == null) t = new BlockingCollection<T>();
            CreateStream(name_file);
            Create();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: освободить управляемое состояние (управляемые объекты)
                }
                this.Stop();
                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить метод завершения
                // TODO: установить значение NULL для больших полей
                disposedValue = true;
            }
        }

        // // TODO: переопределить метод завершения, только если "Dispose(bool disposing)" содержит код для освобождения неуправляемых ресурсов
        // ~BaseJsonSave()
        // {
        //     // Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
