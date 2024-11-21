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
        private readonly string Author;
        public bool  IsAvailavle;
        public string Auther_ { get => Author; }
        public string Title_ { get => Title; }
        public Book(string Title, string Author)
        {
            this.Title = Title;
            this.Author = Author;
            IsAvailavle = true;
        }
    }
    class Library
    {
        List<Book> books=new List<Book>();
        //show the numbers of books in this library
        public void NumberOfBook() => Console.WriteLine("This library contains {0} book", books.Count);


        //search method
        public List<Book> SearchByAuther(string Author) 
        {
            List <Book> temp_books = new List<Book>();


            foreach(Book book in books)
                if (book.Auther_ == Author)                
                    temp_books.Add(book);

            if (temp_books.Count == 0) return null;
            else return temp_books;
        }
        public List<Book> SearchByTitle(string Title)
        {
              List<Book> temp_books = new List<Book>();

            foreach (Book book in books)
            
                if (book.Title_ == Title)
                {
                    temp_books.Add(book);
                }
               if(temp_books.Count == 0) return null;
               else return temp_books;
        }
        public List<Book> Search(string Title,string Author)
        { 
            List<Book> temp_books = new List<Book>();
            
            foreach (Book book in books)
                if (book.Auther_ == Author && book.Title_ == Title)
                        temp_books.Add(book);
            if (temp_books.Count == 0)
                return null;
            else return temp_books;
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
                Console.WriteLine("the library does not contain any books to delete.");

            foreach (Book book in books)
                if (book.Auther_ == Auther && book.Title_ == Title)
                {
                    books.Remove(book); 
                    break;
                }
        }
        // delete all the books by a specific author
        public void DeleteAllBookForAuther(string Author)
        {
            foreach(Book book in books)
                if(book.Auther_ == Author)
                    books.Remove(book);
        }



   
    }
    internal class Program
    {
        static void Main(string[] args)
        {
       


















        }
    }
}
