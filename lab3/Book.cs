using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Book : Position
    {
        public int pageCount { get; set; }
        private List<Author> authors = new List<Author>();


        public Book() : base()
        {
            pageCount = 0;
        }

        public Book(string title_, int id_, string publishingHouse_, DateTime publicationDate_,int pageCount_) : base(title_, id_, publishingHouse_, publicationDate_)
        {
            pageCount = pageCount_;
        } 

        public void AddAuthor(Author a1)
        {
            authors.Add(a1);
        }

        public override string ToString()
        {
            return base.ToString() + $" Page amount: {pageCount},";
        }
        public override void Details()
        {
            Console.WriteLine(this);
            Console.WriteLine("Authors: ");
            if (!(authors.Count == 0))
            {
                foreach(Author a  in authors)
                {
                    Console.WriteLine(a);
                }
            }
            else Console.WriteLine("there are no authors");
        }
    }
}
