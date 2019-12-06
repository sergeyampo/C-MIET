using System;
using System.Collections.Generic;
using System.Text;

namespace Fourth_lab_MIET
{
    class Journal<TKey>
    {
        public Journal()
        {
            m_st = new List<JournalEntry>();
        }

        //Функция регистрирующая событие изменения полей Student и добавляющая об этом метку в m_st список.
        public void RegisterStudentChanged(object source, StudentsChangedEventArgs<TKey> args)
        {
            JournalEntry note = new JournalEntry(args.NameCollection, args.Info, args.PropertyName, args.Key.ToString());
            m_st.Add(note);
        }

        public void Subscribe(StudentCollection<TKey> a)
        {
            a.StudentsChanged += RegisterStudentChanged;
        }

        public override string ToString()
        {
            string a = "";
            foreach (var i in m_st)
            {
                a += i.ToString() + "\n";
            }

            return a;
        }

        private List<JournalEntry> m_st;
    };

    class JournalEntry
    {
        public string Name { get; set; }
        public Action Info { get; set; }
        public string PropertyName { get; set; }
        public string Key { get; set; }

        public JournalEntry(string name, Action act, string prop, string key)
        {
            Name = name;
            Info = act;
            PropertyName = prop;
            Key = key;
        }

        public override string ToString()
        {
            return Info.ToString() + " " + Name + " " + PropertyName + " " + Key;
        }
    };
}
