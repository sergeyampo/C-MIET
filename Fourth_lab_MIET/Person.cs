using System;
using System.Collections.Generic;
using System.Text;

namespace Fourth_lab_MIET
{
    [Serializable()]
    class Person
    {
        public Person(string name, string surname, System.DateTime date)
        {
            Name = name;
            Surname = surname;
            Date = date;
        }

        public Person()
        {
            Name = "Name";
            Surname = "Surname";
            m_date = new DateTime(2000, 2, 20);
        }

        public string Name { get; set; }

        public string Surname{ get; set; }

        public System.DateTime Date { get; set; }

        public int Year
        {
            get
            {
                return m_date.Year;
            }

            set
            {
                m_date = new System.DateTime(value, m_date.Month, m_date.Day);
            }
        }

        public override string ToString()
        {
            return Name + " " + Surname + " " + m_date;
        }

        public virtual string ToShortString()
        {
            return Name + " " + Surname;
        }

        protected System.DateTime m_date;
    };

}
