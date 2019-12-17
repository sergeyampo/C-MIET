using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.IO;

namespace Fourth_lab_MIET
{
    class Programm
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n#############1#############");
            var c1 = new Student();
            c1.AddExams(
                new Exam("Electricity", 3, new DateTime(2020, 1, 20)),
                new Exam("Math", 5, new DateTime(2020, 1, 25)),
                new Exam("Object oriented programming", 5, new DateTime(2020, 1, 22))
            );

            //Сделаем глубокое копирование, проверив сериализацию
            var c2 = c1.Deepcopy();
            //Выведем
            Console.WriteLine(c1 + "\n");
            Console.WriteLine(c2);


            Console.WriteLine("\n#############2, 3#############");
            Console.WriteLine("Enter name of file: ");
            string name = Console.ReadLine();
            var a = new Student();
            if (File.Exists(name))
            {
                a.Load(name);
                Console.WriteLine("Object from file:");
                Console.WriteLine(a);
            }
            else
            {
                Console.WriteLine("File does not exist, let me create it.");
                var f = File.Create(name);
                f.Close();
            }

            Console.WriteLine("\n#############4#############");
            a.AddFromConsole();
            Console.WriteLine(a);
            a.Save(name);

            Console.WriteLine("\n#############5#############");
            a.Load(name);
            a.AddFromConsole();
            a.Save(name);

            Console.WriteLine("\n#############6#############");
            Console.WriteLine(a);
        }
    };
}
