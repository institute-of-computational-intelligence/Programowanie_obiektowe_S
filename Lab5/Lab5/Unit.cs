using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    class Unit :IInfo
    {
        private string unitName;
        private string adress;
        private List<Lecturer> lecturers = new List<Lecturer>();

        public string UnitName { get => unitName; set => unitName = value; }

        public Unit()
        {
            unitName = "--";
            adress = "--";
        }

        public Unit(string unitName_, string adress_)
        {
            unitName = unitName_;
            adress = adress_;
        }

        public void AddLecturer(Lecturer lecturer)
        {
            lecturers.Add(lecturer);
        }

        public bool RemoveLecturer(Lecturer lecturer)
        {
            return lecturers.Remove(lecturer);
        }

        public bool RemoveLecturer(string name_, string surname_)
        {
            int ID = -1;
            for (int i = 0; i < lecturers.Count; i++)
            {
                if(lecturers[i].Name == name_ && lecturers[i].Surname == surname_)
                {
                    ID = i;
                    break;
                }
            }

            if (ID == -1)
                return false;
            else
            {
                lecturers.RemoveAt(ID);
                return true;
            }
            
        }

        public override string ToString()
        {
            return $"Unit Data| Name: {unitName}, Adress: {adress}";
        }

        public void Details()
        {
            Console.WriteLine(this);
            foreach (Lecturer l in lecturers)
            {
                l.Details();
            }
                
        }

    }
}
