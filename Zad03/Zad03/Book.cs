using System;
using System.Collections.Generic;
using System.Text;

namespace Zad03 {
    class Book : Position{
        private int pageAmount;
        private List<Author> authors = new List<Author>();

        public int PageAmount { get => pageAmount; set => pageAmount = value; }
        public Book() {
            
        }
        public Book(string title, int id, string publisher, DateTime releaseDate, int pageAmount): base(title, id, publisher, releaseDate) {
            this.pageAmount = pageAmount;
        }
        public override string ToString() {
            return base.ToString() + $", Number of pages: {pageAmount}";
        }
        public override void Details() {
            Console.WriteLine(this);
            Console.WriteLine("Authors: ");
            if (!(authors.Count == 0)) {
                foreach (Author a in authors) {
                    Console.WriteLine(a);
                }
                Console.WriteLine("--------------------");
            }
            else { Console.WriteLine ("Not specified"); Console.WriteLine("--------------------"); }
        }
        public void AddAuthor(Author a) {
            authors.Add(a);
        }
    }
}
