Библиотека для записи данных, в удобном(потокобезопасному) виде

Пример:

            using (Join<Save> join = new Join<Save>("log.txt"))
            {
	    
                Save save = new Save();
                join.Add(save);
                save.StartWork();
                Console.WriteLine("GOOD");
                Console.ReadKey();
            }
  В классе Save появляется  коллекция, в которую можно записывать данные, и они будут сохраняться в файл

Нет гарантии, последовательности записи данных
