using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Diagnostics.Eventing.Reader;
using System.ComponentModel;
namespace OOP_Progect_Library
{
    class Book
    {
        public readonly string Title;
        public readonly string Author;
        public readonly string Subject;
        public bool  IsAvailable;
        public Book(string Title, string Author, string Subject)
        {
            this.Title = Title;
            this.Author = Author;
            IsAvailable = true;
          this.Subject = Subject;
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
               if(temp_books.Count == 0)
                return null;
                return temp_books;
        }
        public List<Book> Search(string Title,string Author)
        { 
       

            List<Book> temp_books = (from book in books  
                                     where book.Title==Title&&book.Author==Author 
                                     select book).ToList();
            if (temp_books.Count == 0)
                return null;
             return temp_books;
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
    
        //delet book from the library
        public void DeleteBook(string Auther, string Title)
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
            foreach (Book book in books)
                if (book.Author == Author)
                    books.Remove(book);
        }
        //Show random books to user
        public void DisPlayRandomBook()
        {
            int limit;
            if (books.Count == 0)
            { Console.WriteLine("there is no book in this library!"); return; }
            else if (books.Count <= 5)
                limit = books.Count;
            else 
                limit = 6;
            Random random = new Random();
            int i = 0;
            while (i < limit)
            {
                int index = random.Next(0, books.Count);
                Console.WriteLine("Title: {0}Author: {1}", books[index].Title, books[index].Author);
                i++;
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
