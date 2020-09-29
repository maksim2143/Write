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

namespace Joiner
{
    /// <summary>
    /// Клас,для створення класів маріонеток.
    /// </summary>
    /// <typeparam name="T">Клас який підписується</typeparam>
    public class Join<T>:IDisposable where T : IClone
    {
        ~Join()
        {
            if (writer != null) writer.Dispose();
        }
        public Join()
        {
            t = new BlockingCollection<T>();
        }
        private  BlockingCollection<T> t;
        /// <summary>
        /// Метод який записує дані з потоків
        /// </summary>
        protected  void Write()
        {
            foreach (var item in t)//Получаємо всі екзепляри класів
            {
                if (item.info == null) continue;
                while(item.info.Count > 0)//Перебор елементів
                {
                    if (item.info.TryDequeue(out var result))//Пробуємо, витягнути елемент
                    {
                        writer.WriteLine(result ?? "");//Записуємо дані в файл.
                    }
                }
            }
        }
        /// <summary>
        /// Створюємо стрім
        /// </summary>
        /// <param name="file"></param>
        protected  void CreateStream(string file)
        {
            if (writer != null) return;
            Stream stream = File.OpenWrite(file);//Відкриваємо файл
            stream = Stream.Synchronized(stream);//Робимо стрім , потокобезопасним
            writer = new StreamWriter(stream);
        }
        private  StreamWriter writer;
        private  void SetNameFile(string file)//Задаємо назву файла
        {
            name_file = file;
        }
         string name_file;
        public  void Add(T value)//Підписуємо новий елемент
        {
            t.Add(value);
        }
        Timer timer;//Таймер який буде виконувати метод, Write
        private bool disposedValue;
        /// <summary>
        /// Створємо новий екзепляр, таймера
        /// </summary>
        private void Create()
        {
            if (timer != null) return;
            timer = new Timer(x=> Write(),null,10000,10000);
        }
        public Join(string file)
        {
            this.SetNameFile(file);//Задаємо , ім'я файла
            Start();//Стартуємо всьо
            
        }
        /// <summary>
        /// Метод для остановки роботи, всього класу
        /// </summary>
        private  void Stop()//Стопаємо всьо
        {
            Write();//Дозаписуємо дані які лишилися
            if (timer != null) timer.Dispose();
            if (writer != null) writer.Dispose();
            t = null;
        }
        /// <summary>
        /// Метод для запуска, роботи всього класу
        /// </summary>
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
