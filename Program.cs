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
        //show the numbers of books in this library
        public void NumberOfBook() => Console.WriteLine("This library contains {0} book", books.Count);

        //check if the library empty
        public bool IsEmpty() => books.Count == 0;

        //search method
        public List<Book> SearchByAuther(string Auther) 
        {
            List <Book> temp_books = new List<Book>();
            if(books.Count == 0) return null;

            foreach(Book b in books)
                if (b.Auther_ == Auther)                
                    temp_books.Add(b);

            if (temp_books.Count == 0) return null;
            else return temp_books;
        }
        public List<Book> SearchByTitle(string Title)
        {
              List<Book> temp_books = new List<Book>();
                if (books.Count == 0) return null;
            foreach (Book b in books)
            
                if (b.Title_ == Title)
                {
                    temp_books.Add(b);
                }
               if(temp_books.Count == 0) return null;
               else return temp_books;
        }
        public Book Search(string Title,string Auther)
        {
            if (books.Count == 0) return null;
            foreach (Book b in books)
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
            if (books.Count == 0) 
                Console.WriteLine("the library does not contain anny books.");

            foreach (Book b in books)
                if (b.Auther_ == Auther && b.Title_ == Title)
                {
                    books.Remove(b); 
                    break;
                }
        }
     
  
        
    }
    internal class Program
    {
        static void Main(string[] args)
        {
       


















        }
    }
}
