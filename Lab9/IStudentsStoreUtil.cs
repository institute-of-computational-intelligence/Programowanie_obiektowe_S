using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    interface IStudentsStoreUtil
    {
        void Save(List<Student> students);
        List<Student> Load();
    }
}
