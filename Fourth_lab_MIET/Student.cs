using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Fourth_lab_MIET
{
    enum Education
    {
        Specialist,
        Bachelor,
        SecondEducation
    };


    [Serializable()]
    class Student : Person
    {
        public Student(Person person, Education educ, int group) : base(person.Name, person.Surname, person.Date)
        {
            Educ = educ;
            Group = group;
        }

        public Student() : base()
        {
            Educ = Education.Bachelor;
            Group = 1;
        }

        public Person InfoPerson
        {
            get
            {
                return new Person(Name, Surname, Date);
            }

            set
            {
                Name = value.Name;
                Surname = value.Surname;
                Date = value.Date;
            }
        }

        public Education Educ { get; set; }

        public int Group { get; set; }


        public List<Exam> Exams
        {
            get
            {
                return m_exams;
            }

            set
            {
                m_exams = value;
            }
        }

        public double MiddleMark
        {
            get
            {
                double avg = m_exams.Count > 0 ? m_exams.Average((Exam e) => e.Mark) : 0.0;

                return avg;
            }
        }

        public void AddExams(params Exam[] exams)
        {
            if (m_exams == null)
            {
                m_exams = new List<Exam>();
            }
            m_exams.AddRange(exams);
        }

        public override string ToString()
        {
            string a = base.ToString() + " " + Group;

            if (m_exams != null)
            {
                foreach (Exam i in m_exams)
                {
                    a += ("\n" + i);
                }
            }

            return a;
        }

        public override string ToShortString()
        {
            return base.ToString() + " " + Group + " " + MiddleMark;
        }

        public Student Deepcopy()
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, this);
                ms.Position = 0;

                return (Student)formatter.Deserialize(ms);
            }
        }

        public bool Save(string fn)
        {
            return Student.Save(fn, this);
        }

        public bool Load(string fn)
        {
            return Student.Load(fn, this);
        }

        public bool AddFromConsole()
        {
            Console.WriteLine("Title(string)|mark(int)|date(year(int)|month(int)|day(int))");
            Console.WriteLine("Separators: $, |");
            Console.WriteLine("Enter: ");
            string input = Console.ReadLine();
            char[] sep = { '$', '|' };
            var par = input.Split(sep);
            try
            {
                this.AddExams(new Exam(par[0], int.Parse(par[1]), new DateTime(int.Parse(par[2]), int.Parse(par[3]), int.Parse(par[4]))));
                return true;
            }
            catch
            {
                Console.WriteLine("Incorrect input!");
                return false;
            }
        }

        public static bool Save(string fn, Student obj)
        {
            try
            {
                using (var fs = new FileStream(fn, FileMode.Create))
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(fs, obj);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool Load(string fn, Student obj)
        {
            try
            {
                if (File.Exists(fn))
                {
                    using (var fs = new FileStream(fn, FileMode.Open))
                    {
                        var deserializer = new BinaryFormatter();
                        var a = (Student)deserializer.Deserialize(fs);
                        obj.Assign(a);
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                Console.WriteLine("Error while reading the file!");
                return false;
            }
        }

        public void Assign(Student a)
        {
            this.m_exams = a.m_exams;
        }

        private List<Exam> m_exams;
    };
}

