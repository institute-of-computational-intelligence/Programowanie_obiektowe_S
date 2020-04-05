using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    class Unit : IInfo
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public IList<Lecturer> Lecturers { get; }

        public Unit(string name, string address)
        {
            Name = name;
            Address = address;
            Lecturers = new List<Lecturer>();
        }

        public void AddLecturer(Lecturer lecturer)
        {
            if (!Lecturers.Contains(lecturer))
                Lecturers.Add(lecturer);
        }

        public bool RemoveLecturer(Lecturer lecturer)
        {
            return Lecturers.Remove(lecturer);
        }

        public bool RemoveLecturer(string name, string surname)
        {
            int lecturerID = -1;

            for (int i = 0; i < Lecturers.Count; i++)
                if (Lecturers[i].Name.Equals(name) && Lecturers[i].Surname.Equals(surname))
                {
                    lecturerID = i;
                    break;
                }

            if (lecturerID == -1) return false;

            Lecturers.RemoveAt(lecturerID);

            return true;
        }

        public override string ToString()
        {
            return $"Name {Name}, address {Address}";
        }

        public void PrintInfo()
        {
            Console.WriteLine(this);
        }

        public void PrintLecturers()
        {
            string str = this + ", lectureres: \r\n";

            foreach (Lecturer lecturer in Lecturers)
                str += lecturer + "\r\n";

            Console.WriteLine(str);
        }
    }
}
