using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Fourth_lab_MIET
{
    delegate TKey KeySelector<TKey>(Student st);
    delegate void StudentChangedHandler<TKey>(object source, StudentsChangedEventArgs<TKey> args);
    class StudentCollection<TKey>
    {
        //Событие, вызываемое, когда в коллекцию добавляются элементы, из неё удаляется элемент или изменяются данные одного из её элементов.
        public event StudentChangedHandler<TKey> StudentsChanged;

        public string Name { get; set; }

        public bool Remove(TKey k)
        {
            if (m_dict[k] != null)
            {
                m_dict[k].PropertyChanged -= PropertyHandler;
                m_dict.Remove(k);
                StudentsChanged(this, new StudentsChangedEventArgs<TKey>(Name, Action.Remove, "", k));

                return true;
            }
            else return false;
            
        }

        public StudentCollection(KeySelector<TKey> f, string name)
        {
            m_getKey = f;
            m_dict = new Dictionary<TKey, Student>();
            Name = name;
        }

        public void AddStudents(params Student[] st)
        {
            foreach (Student i in st)
            {
                m_dict.Add(m_getKey(i), i);
                StudentsChanged(this, new StudentsChangedEventArgs<TKey>(
                    Name,
                    Action.Add,
                    "",
                    m_getKey(i)
                ));

                i.PropertyChanged += PropertyHandler;
            }
        }

        

        public void PropertyHandler(object sender, PropertyChangedEventArgs e)
        {
            StudentsChanged(this, new StudentsChangedEventArgs<TKey>(
                Name,
                Action.Property,
                e.PropertyName,
                m_getKey((Student)sender)
            ));
        }

        public override string ToString()
        {
            string a = "";
            foreach (var pair in m_dict)
            {
                a += (pair.Value.ToString() + "\n");
            }

            return a;
        }

        private Dictionary<TKey, Student> m_dict;
        private KeySelector<TKey> m_getKey;
    };
}
