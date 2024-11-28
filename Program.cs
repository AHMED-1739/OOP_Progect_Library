using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Diagnostics.Eventing.Reader;
using System.ComponentModel;
using System.Runtime.InteropServices;
using static System.Console;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Win32;
namespace OOP_Progect_Library
{
    class Book
    {
        public readonly string Title;
        public readonly string Author;
        public readonly string Subject;
        public bool  IsAvailable;
        public Book(string Title, string Author, string Subject="Uncategorized")
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
        public void Add(Book Added_Book)
        {
            if(string.IsNullOrWhiteSpace(Added_Book.Title)|| string.IsNullOrWhiteSpace(Added_Book.Author))
            {
                throw new Exception("the book must have a title and author name");
            }
            List<Book> temp_Books = (from book in books
                                     where book.Author == Added_Book.Author && book.Title == Added_Book.Title
                                     select book).ToList();

            if (temp_Books.Count == 0)
            {
                WriteLine("The book has been added.\n--------------------");
                books.Add(Added_Book);
            }
            else WriteLine("the book is already in the library.");
        }
        //Show random books to user
        public void DisPlayRandomBook()
        {
            int limit;
            if (books.Count == 0)
            { WriteLine("there is no book in this library!."); return; }
            else if (books.Count <= 5)
                limit = books.Count;
            else 
                limit = 6;
            Random random = new Random();
            int i = 0;
            while (i < limit)
            {
                int index = random.Next(0, books.Count);
                WriteLine("Title: {0}Author: {1}", books[index].Title, books[index].Author);
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
       public int index;
        public Menu(string[] Option,string Title )
        {
            this.Option = Option;
            this.Title = Title;
            index = 0; 
        }
        public void view()
        {
            if (index >= Option.Length)
                index = 0;
            WriteLine(Title + "\n");
            for (int i = 0; i < Option.Length; i++)
            {
                if (i != index)
                    WriteLine(Option[i]);
                else
                {
                    BackgroundColor = ConsoleColor.Blue;
                    WriteLine(Option[i]);
                    BackgroundColor = ConsoleColor.Black;
                }
            }
        }
        public void dd()
        {

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] option = {"1-Search" ,"2-Add", "-Exit" };
            string[] subjectOption = { "", "", "", "", "" };
            Menu mun = new Menu(option, "-----library-----");
            Library library = new Library();
            library.Add(new Book("test1","test1"));
            ConsoleKeyInfo KeyPressed = new ConsoleKeyInfo();
           bool check = true;
            while (check)
            {
                Clear();
                mun.view();
                KeyPressed=ReadKey(true);

                if (KeyPressed.Key == ConsoleKey.DownArrow)
                { 
                    mun.index++;
                    continue; 
                }
                if(KeyPressed.Key== ConsoleKey.UpArrow)
                {    
                        mun.index--;
                        if (mun.index == -1)
                            mun.index = option.Length - 1;   
                    continue;
                }
                if(KeyPressed.Key == ConsoleKey.Enter)
                {
                    //Search
                    if (mun.index == 0)
                    {


                    }
                    //Add
                    if (mun.index == 1)
                    {
                        Clear();
                        while (true)
                        {
                            try
                            {   
                                WriteLine("---Add a book--- \n");
                                Write("Enter the title:");
                                string title = ReadLine();
                                Write("Enter the Author:");
                                string author = ReadLine();
                                Clear();
                                library.Add(new Book(title, author, "history"));
                            } 
                            catch(Exception ex)
                            {
                                Clear();
                                WriteLine(ex.Message);
                                continue;
                            }
                            
                           
                            WriteLine("add another book?\npresee Y/N");

                            ConsoleKeyInfo choois;
                            while (true)
                            {
                                 choois = ReadKey(true);
                                if (choois.Key == ConsoleKey.Y||choois.Key==ConsoleKey.N)
                                {
                                    Clear();
                                    break;
                                }
                                if (choois.Key != ConsoleKey.Y || choois.Key != ConsoleKey.N)
                                    continue;
                            }
                            if (choois.Key == ConsoleKey.N)
                                break;
                        }

                    }
                    // Exit
                        if (mun.index==2)
                    {
                        check = false;
                        Clear();
                        WriteLine("Good_Bay!");
                    }              
                    
                } 

            }
        }

    }
}
