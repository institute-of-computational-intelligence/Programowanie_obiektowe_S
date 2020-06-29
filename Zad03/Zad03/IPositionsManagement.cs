using System;
using System.Collections.Generic;
using System.Text;

namespace Zad03 {
    interface IPositionsManagement {
        Position FindPositionByTitle(string title);
        Position FindPositionById(int id);
        void PoisitonsDetails();
    }
}
