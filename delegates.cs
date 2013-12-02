using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Delegates
{
    public struct Book
    {
        public string Title;
        public string Author;
        public decimal Price;
        public bool Paperback;

        public Book(string title, string author, decimal price, bool paperBack)
        {
            Title = title;
            Author = author;
            Price = price;
            Paperback = paperBack;
        }
    }

    // Declare a delegate type for processing a book
    public delegate void ProcessBookDelegate(Book book);

    public class BookDB
    {
        ArrayList list = new ArrayList();

        public void AddBook(string title, string author, decimal price, bool paperBack)
        {
            list.Add(new Book(title, author, price, paperBack));
        }

        public void ProcessPaperbackBooks(ProcessBookDelegate processBook)
        {
            foreach (Book b in list)
            {
                if (b.Paperback)
                {
                    // Calling the delegate
                    processBook(b);
                }
            }
        }
    }

    class PriceTotaller
    {
        int countBooks = 0;
        decimal priceBooks = 0.0m;

        internal void AddBookToTotal(Book book)
        {
            countBooks =+ 1;
            priceBooks =+ book.Price;
        }

        internal decimal AveragePrice()
        {
            return priceBooks / countBooks;
        }
    }

    class Program
    {
        static void PrintTitle(Book b)
        {
            Console.WriteLine("   {0}", b.Title);
        }

        static void AddBooks(BookDB bookDB)
        {
            bookDB.AddBook("The C Programming Language", "Brian W. Kernighan and Dennis M. Ritchie", 19.95m, true);
            bookDB.AddBook("The Unicode Standard 2.0", "The Unicode Consortium", 39.95m, true);
            bookDB.AddBook("The MS-DOS Encyclopedia", "Ray Duncan", 129.95m, false);
            bookDB.AddBook("Dogbert's Clues for the Clueless", "Scott Adams", 12.00m, true);
        }

        static void Main(string[] args)
        {
            BookDB bookDB = new BookDB();
            AddBooks(bookDB);
            PriceTotaller totaller = new PriceTotaller();

            bookDB.ProcessPaperbackBooks(new ProcessBookDelegate(PrintTitle));

            bookDB.ProcessPaperbackBooks(new ProcessBookDelegate(totaller.AddBookToTotal));
            Console.WriteLine("Average Paperback Book Price: ${0:#.##}", totaller.AveragePrice());

            Console.ReadLine();

            //Output
            //Paperback Book Titles:
            //The C Programming Language
            //The Unicode Standard 2.0
            //Dogbert's Clues for the Clueless
            //Average Paperback Book Price: $23.97

        }
    }
}
