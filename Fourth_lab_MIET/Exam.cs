using System;
using System.Collections.Generic;
using System.Text;

namespace Fourth_lab_MIET
{
    [Serializable()]
    class Exam
    {
        public Exam(string name, int mark, System.DateTime date)
        {
            Name = name;
            Mark = mark;
            Date = date;
        }

        public Exam()
        {
            Name = "DefaultExam";
            Mark = 0;
            Date = new System.DateTime(2000, 1, 22);
        }

        public override string ToString()
        {
            return Name + " " + Mark + " " + Date;
        }

        public string Name;
        public int Mark;
        public System.DateTime Date { get; set; }
    };
}
