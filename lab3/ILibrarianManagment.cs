using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    interface ILibrarianManagment
    {
        void AddLibrarian(Liblarian lib);

        void DeleteLibrarian();
        void ShowLibrarian();
    }
}
