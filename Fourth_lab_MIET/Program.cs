using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace Fourth_lab_MIET
{
    enum Action
    {
        Add,
        Remove,
        Property
    };

    class Programm
    {
        static void Main(string[] args)
        {
            //int потому что нам нужно зарегистрировать изменения значения группы
            //тип которого int => KeySelector должен быть int.
            var first = new StudentCollection<int>((e) => e.Id, "first");
            var second = new StudentCollection<int>((e) => e.Id, "second");


            var j = new Journal<int>();
            j.Subscribe(first);
            j.Subscribe(second);


            var s1 = new Student(Education.Bachelor, 5);
            var s2 = new Student(Education.Bachelor, 5);
            first.AddStudents(s1);
            second.AddStudents(s2);
            s1.Educ = Education.SecondEducation;
            s2.Educ = Education.Specialist;

            s1.Group = 4;
            s2.Group = 1;

            first.Remove(s1.Id);
            second.Remove(s2.Id);

            s1.Educ = Education.Specialist;
            s2.Educ = Education.Bachelor;

            s1.Group = 4;
            s2.Group = 1;

            // After deleting from Collections changing not write in journal
            Console.WriteLine(j.ToString());
        }
    }
}
