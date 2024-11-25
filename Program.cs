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
        public readonly string Title;
        public readonly string Author;
        public bool  IsAvailable;
        public Book(string Title, string Author)
        {
            this.Title = Title;
            this.Author = Author;
            IsAvailable = true;
        }
    }
    class Library
    {
      public  List<Book> books=new List<Book>();
        //search method
        public List<Book> SearchByAuthor(string Author)
        {
            

            List<Book> temp_books = (from book in books where book.Author == Author select book).ToList();
            if (temp_books.Count == 0)
                return null;
            return temp_books;
        }
        public List<Book> SearchByTitle(string Title)
        {
            List<Book> temp_books = (from book in books where book.Title == Title select book).ToList();
               if(temp_books.Count == 0) return null;
               else return temp_books;
        }
        public List<Book> Search(string Title,string Author)
        { 
       

            List<Book> temp_books = (from book in books  
                                     where book.Title==Title&&book.Author==Author 
                                     select book).ToList();
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
                if (books[i].Title == TitleOrAuthor)
                    MatchTheTitle.Add(books[i]);
                if (books[i].Author==TitleOrAuthor)
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
                if (books[i].Author == Auther && books[i].Title == Title)
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
                if(book.Author == Author)
                    books.Remove(book);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

        }

    }
}
