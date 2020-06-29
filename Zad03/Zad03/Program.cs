using System;

namespace Zad03 {
    class Program {
        static void Main(string[] args) {
            //ZADANIE 1
            
            Book b = new Book();
            b.Details();
            Position magazine = new Magazine("GLAMOUR", 1, "Burda International Polska", new DateTime(2020, 11, 20), 21);
            Author author = new Author("Andrzej", "Sapkowski", "Polish");
            Position book = new Book("Pani Jeziora", 2, "superNOWA", new DateTime(1999, 10, 13), 596);
            magazine.Details();
            Console.WriteLine("\n");
            book.Details();
            Console.WriteLine("\n");
            ((Book)book).AddAuthor(author);
            book.Details();
            Console.WriteLine("\n");
            Catalog catalog = new Catalog("Koniec zartow");
            catalog.AddPosition(magazine);
            catalog.AddPosition(book);
            Position foundById = catalog.FindPositionById(1);
            Position foundByTitle = catalog.FindPositionByTitle("Pani Jeziora");
            Console.WriteLine("\nSearch:\n");
            Console.WriteLine("By Id: \n" + foundById + "\n");
            Console.WriteLine("By title:\n" + foundByTitle + "\n");

            catalog.PoisitonsDetails();
            
            //ZADANIE 2

            Library l1 = new Library();
            Library l2 = new Library("ul. Armii Krajowej 51");
            Person librarian = new Librarian("Maciej", "Bibliotekarz", new DateTime(2020, 03, 12), 2500);
            Person a1 = new Author("Andrzej", "Sapkowski", "Polska");
            Position b1 = new Book("Pani Jeziora", 2, "superNOWA", new DateTime(1999, 1, 1), 596);
            Position m1 = new Magazine("GLAMOUR", 1, "Burda International Polska", new DateTime(2020, 3, 2), 21);
            Catalog c1 = new Catalog("Fantastyka");
            Catalog c2 = new Catalog("Czasopisma");
            l2.AddLibrarian(((Librarian)librarian));
            l2.AddCatalog(c1);
            l2.AddCatalog(c2);
            ((Book)b1).AddAuthor((Author)a1);
            l2.AddPosition(b1, "Fantastyka");
            l2.AddPosition(m1, "Czasopisma");

            Console.WriteLine("Libraries Information: \n\t");
            l1.PoisitonsDetails();
            Console.WriteLine("Librarian info: \n\t");
            l1.LibrariansDetails();
            l2.PoisitonsDetails();
            l2.LibrariansDetails();

            Console.WriteLine("-------===========-------\nSearch in l2:\n");
            Console.WriteLine("By Id: \n" + l2.FindPositionById(1) + "\n");
            Console.WriteLine("By title:\n" + l2.FindPositionByTitle("Pani Jeziora") + "\n");


            Console.ReadKey();
        }
    }
}
