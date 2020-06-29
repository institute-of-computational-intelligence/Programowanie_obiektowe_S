using System;
using System.Collections.Generic;
using System.Text;

namespace Zad03 {
    interface ILibrariansManagement {
        void AddLibrarian(Librarian l);
        void RemoveLibrarian(Librarian l);
        void LibrariansDetails();
    }
}
