using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Diagnostics.Eventing.Reader;
using System.ComponentModel;
using System.Runtime.InteropServices;
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
            this.Subject = Subject;
            IsAvailable = true;
         
        }
    }
    class Library
    {
      public  List<Book> books=new List<Book>();
        //search method
        public List<Book> SearchByAuthor(string Author)
        {
            List<Book> temp_Books = (from book in books where book.Author == Author select book).ToList();
            if (temp_Books.Count == 0)
                return null;
            return temp_Books;
        }
        public List<Book> SearchByTitle(string Title)
        {
            List<Book> temp_Books = (from book in books where book.Title == Title select book).ToList();
               if(temp_Books.Count == 0)
                return null;
                return temp_Books;
        }
        public List<Book> Search(string Title,string Author)
        { 
            List<Book> temp_Books = (from book in books  
                                     where book.Title==Title&&book.Author==Author 
                                     select book).ToList();
            if (temp_Books.Count == 0)
                return null;
             return temp_Books;
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
        // this fuction displays randome books for a given topic
        public List<Book> Books_Subject(string subject)
        {
            List<Book> temp_Books= (from book in books where book.Subject == subject select book).ToList();
            return temp_Books;
        }
    }
    class Menu
    {
        string[] Option;
        string Title;
        int index;

        public Menu(string[] Option,string Title )
        {
            this.Option = Option;
            this.Title = Title;
            index = 0; 
        }

        public void view()
        {
            Console.WriteLine(Title);
            for(int i=0;i<Option.Length;i++)
            {
                   if(i!=index)
                    Console.WriteLine(Option[i]);
                else
                {
                    Console.BackgroundColor=ConsoleColor.Blue;
                    Console.WriteLine(Option[i]);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }

        }
    }
    internal class Program
    {






        static void Main(string[] args)
        {
            string[] option = {"Search" ,"Add"};



            Menu mun = new Menu(option, "library");
            ConsoleKeyInfo KeyPressed = new ConsoleKeyInfo();
 
            mun.view();










        }
    }
}
