using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Book b = new Book();
            b.Details();
            Position magazine = new Magazine("GLAMOUR", 1, "Burda International Polska",new DateTime(2020 , 11 ,30) , 21);
            Author author = new Author("Andrzej", "Sapkowski","Polak");
            Position book = new Book("Pani Jeziora", 2, "superNOWA", new DateTime(2010, 11, 20), 596);
            magazine.Details();
            Console.WriteLine("\n");
            book.Details();
            Console.WriteLine("\n");
            ((Book)book).AddAuthor(author);
            book.Details();
            Console.WriteLine("\n");
            Catalog catalog = new Catalog("Koniec zartow");
            catalog.AddPostions(magazine);
            catalog.AddPostions(book);
            

            Console.WriteLine("-------===========-------\nSearch in catalog:\n");
            Console.WriteLine("By Id: \n" + catalog.FindPositionById(1) + "\n");
            Console.WriteLine("By title:\n" + catalog.FindPositionbyTitle("Pani Jeziora") + "\n");

            Console.ReadKey();
            Console.WriteLine("zad2:");

            Library l1 = new Library();
            Library l2 = new Library("ul. Armii Krajowej 51");
            Person librarian = new Liblarian("Maciej", "Bibliotekarz", new DateTime(2020, 3,20  ), 2500);
            Person a1 = new Author("Andrzej", "Sapkowski", "Polska");
            Position b1 = new Book("Pani Jeziora", 2, "superNOWA", new DateTime(1000, 10, 12), 596);
            Position m1 = new Magazine("GLAMOUR", 1, "Burda International Polska", new DateTime(1050, 10, 12), 21);
            Catalog c1 = new Catalog("Fantastyka");
            Catalog c2 = new Catalog("Czasopisma");
            l2.AddLibrarian(((Liblarian)librarian));
            l2.AddCatalog(c1);
            l2.AddCatalog(c2);
            ((Book)b1).AddAuthor((Author)a1);
            l2.AddPosition(b1, "Fantastyka");
            l2.AddPosition(m1, "Czasopisma");

            Console.WriteLine("Libraries Information: \n\t");
            l1.ShowAll();
            Console.WriteLine("Librarian info: \n\t");
            l1.ShowLibrarian();
            l2.ShowAll();
            l2.ShowLibrarian();

            Console.WriteLine("-------===========-------\nSearch in l2:\n");
            Console.WriteLine("By Id: \n" + l2.FindPositionById(1) + "\n");
            Console.WriteLine("By title:\n" + l2.FindPositionbyTitle("Pani Jeziora") + "\n");
            Console.ReadKey();
        }
    }
}
