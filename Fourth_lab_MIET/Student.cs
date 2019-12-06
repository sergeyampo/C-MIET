using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Fourth_lab_MIET
{
    //
    class StudentsChangedEventArgs<TKey> : EventArgs
    {
        public string NameCollection { get; set; }
        public Action Info { get; set; }
        public string PropertyName { get; set; }
        public TKey Key { get; set; }

        public StudentsChangedEventArgs(string name, Action act, string prop, TKey key)
        {
            NameCollection = name;
            Info = act;
            PropertyName = prop;
            Key = key;
        }

        public override string ToString()
        {
            return NameCollection + " " + PropertyName;
        }
    };
    enum Education
    {
        Specialist,
        Bachelor,
        SecondEducation
    };

    class Student : INotifyPropertyChanged
    {
        delegate TKey KeySelector<TKey>(Student st);
        public event PropertyChangedEventHandler PropertyChanged;

        public Student(Education educ, int group)
        {
            m_educ = educ;
            m_group = group;
            Id = Student._id++;
        }

        public Student()
        {
            m_educ = Education.Specialist;
            m_group = 1;
            Id = Student._id++;
        }

        public Education Educ
        {
            get
            {
                return m_educ;
            }

            set
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Education"));
                }
                m_educ = value;
            }
        }

        public int Group
        {
            get
            {
                return m_group;
            }

            set
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Group"));
                }
                m_group = value;
            }
        }

        public override string ToString()
        {
            return "" + Group;
        }

        private static int _id = 0;

        public int Id;
        private Education m_educ;
        private int m_group;
    };
}

