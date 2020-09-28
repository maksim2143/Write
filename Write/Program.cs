using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Write.Test;
using Joiner;

namespace Write
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Join<Save> join = new Join<Save>("log.txt")) //Створюємо екзепляр класа
            {
                Save save = new Save();//Створюємо клас маріонетку, яка реалізує інтерфейс IClone
                join.Add(save);//Підписуємо , екземпляп save на збереження даних
                save.StartWork();//Запускаємо, тестову нагрузку
                Console.WriteLine("GOOD");
                Console.ReadKey();
            }
        }
    }
}
