using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Diagnostics.Eventing.Reader;

namespace OOP_Progect_Library
{
    class Book
    {
        private readonly string Title;
        private readonly string Auther;
        public string Auther_ { get => Auther; }
        public string Title_ { get => Title; }

        public Book(string Title, string Auther)
        {
            this.Title = Title;
            this.Auther = Auther;
        }
    }
    class Library
    {
        List<Book> books=new List<Book>();

        //search method
        public Book SearchByAuther(string Auther) 
        {
            foreach(Book b in books)
            {
                if (b.Auther_ == Auther)
                    return b;
            }
            return null;
        }
        public Book SearchByTitle(string Title)
        {
            foreach (Book b in books)
            {
                if (b.Title_ == Title)
                    return b;
            }
            return null;
        }
        public Book Search(string Title,string Auther)
        {
         foreach(Book b in books)
            {
                if (b.Auther_ == Auther && b.Title_ == Title)
                    return b;
            }
            return null;
        }
          //add book to the library
        public void Add(Book book)
        {
            books.Add(book);
            Console.WriteLine("The book has been added to the library.");
        }
        //delet book from the library
        public void DeleteBook(string Auther,string Title)
        {
            foreach (Book b in books)
                if (b.Auther_ == Auther && b.Title_ == Title)
                {
                    books.Remove(b); 
                    break;
                }
        }
        //show the numbers of books in this library
        public void NumberOfBook() => Console.WriteLine("This library contains {0} book",books.Count);
        
    }
    internal class Program
    {
        static void Main(string[] args)
        {
       


















        }
    }
}
