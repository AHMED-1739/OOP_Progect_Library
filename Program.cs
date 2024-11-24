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
        public bool  IsAvailable;
        public string Author_ { get => Author; }
        public string Title_ { get => Title; }
        public Book(string Title, string Author)
        {
            this.Title = Title;
            this.Author = Author;
            IsAvailable = true;
        }
    }
    class Library
    {
        List<Book> books=new List<Book>();
        //show the numbers of books in this library
        public void NumberOfBook() => Console.WriteLine("This library contains {0} book", books.Count);

        //search method
        public List<Book> SearchByAuthor(string Author)
        {
            List<Book> temp_books = (from book in books where book.Author_ == Author select book).ToList();
            return temp_books;
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
                if (book.Author_ == Author && book.Title_ == Title)
                        temp_books.Add(book);
            if (temp_books.Count == 0)
                return null;
            else return temp_books;
        }
        //We will use this method if the user doesn't know whether what they know is the title or the author's name
        public (List<Book>,List<Book>) SearchByBoth (string TitleOrAuthor)
        {
            if(string.IsNullOrWhiteSpace(TitleOrAuthor))
                throw new Exception("there is no book whose author's name or title are nothing!!!!!");
            
            List<Book> MatchTheAuthorsName=new List<Book> ();
            List<Book>MatchTheTitle=new List<Book> ();

         for(int i=0;i<books.Count;i++)
            {
                if (books[i].Title_ == TitleOrAuthor)
                    MatchTheTitle.Add(books[i]);
                if (books[i].Author_==TitleOrAuthor)
                    MatchTheAuthorsName.Add(books[i]);
            }

         return(MatchTheAuthorsName,MatchTheTitle);
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
            { 
                Console.WriteLine("the library does not contain any books to delete.");
                return;
            }

            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Author_ == Auther && books[i].Title_ == Title)
                {
                    books.Remove(books[i]);
                    break;
                }
            }
        }
        // delete all the books by a specific author
        public void DeleteAllBookForAuther(string Author)
        {
            foreach(Book book in books)
                if(book.Author_ == Author)
                    books.Remove(book);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();


            Console.WriteLine("library catalogue");

            while (true)
            {
                Console.WriteLine("Are you looking for specific book?");



            }

        }

    }
}
