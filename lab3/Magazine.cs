using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Magazine : Position
    {
        public int number { get; set; }

        public Magazine(): base()
        {
            number = 0;
        }

        public Magazine(string title_, int id_, string publishingHouse_, DateTime publicationDate_, int number_):base(title_, id_, publishingHouse_, publicationDate_)
        {
            number = number_;
        }

        public override string ToString()
        {
            return base.ToString()+ $"number: {number}";
        }
        public override void Details()
        {
            Console.WriteLine(this);
        }
    }
}
