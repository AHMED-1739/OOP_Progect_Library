using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using static System.Console;
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
            if (string.IsNullOrEmpty(Author))
                throw new Exception("Author name cannot be black!!");
            List<Book> temp_Books = (from book in books where book.Author == Author select book).ToList();
            if (temp_Books.Count == 0)
                return null;
            return temp_Books;
        }
        public List<Book> SearchByTitle(string Title)
        {
            if (string.IsNullOrEmpty(Title))
                throw new Exception("Book Title cannot be empty!");

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
        //Book info
        public void Information_Of_Book(Book book)
        {
            WriteLine("Title: {0}\nAuthor: {1}\nSubject: {2}",book.Title,book.Author,book.Subject);
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
       public int Selected_Index;
        public Menu(string[] Option,string Title )
        {
            this.Option = Option;
            this.Title = Title;
            Selected_Index = 0; 
        }
        private void view()
        {
            if (Selected_Index >= Option.Length)
                Selected_Index = 0;
            WriteLine(Title + "\n");
            for (int i = 0; i < Option.Length; i++)
            {
                if (i != Selected_Index)
                    WriteLine(Option[i]);
                else
                {
                    BackgroundColor = ConsoleColor.Blue;
                    WriteLine(Option[i]);
                    BackgroundColor = ConsoleColor.Black;
                }
            }
        }
        public int Run()
        {
            ConsoleKeyInfo KeyPressed;
            do
            {
                Clear();
                view();
                KeyPressed = Console.ReadKey(true);
                if(KeyPressed.Key==ConsoleKey.UpArrow)
                {   
                    Selected_Index--;
                      if(Selected_Index ==-1)
                        Selected_Index=Option.Length-1;
                }

              else  if (KeyPressed.Key == ConsoleKey.DownArrow)
                {
                    Selected_Index++;
                    if (Selected_Index >Option.Length)
                        Selected_Index = 0;
                }



            } while (KeyPressed.Key != ConsoleKey.Enter);

            return Selected_Index;

         
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] option = {"1-Search" ,"2-Add", "-Exit" };
            string[] Search_Menu_Option = { "1-Title", "2-Author", "3-Title & Author", "4-Title OR Author", "5-random books?","-Back" };
            Menu Start_Menu = new Menu(option, "-----library-----");
            Menu Search_Menu = new Menu(Search_Menu_Option, "----Search----");
            Library library = new Library();
            bool check = true;
            while (check)
            {
              int selectedIndex=  Start_Menu.Run();
                Clear();
                if (selectedIndex == 0)
                {
                    selectedIndex = Search_Menu.Run();
                    Clear();
                    while (true)
                    {
                        
                        if (selectedIndex == 0)
                        {
                            WriteLine("----Search----");
                            Write("Enter the Title:");
                            try
                            {
                                List<Book> temp_List = library.SearchByTitle(ReadLine());
                                if (temp_List.Count == 0)
                                    Console.WriteLine("the book not found.");
                                else
                                {
                                    WriteLine("Matching results:");
                                    foreach (Book temp in temp_List)
                                    {
                                        library.Information_Of_Book(temp);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Clear();
                                WriteLine(ex.Message);
                                WriteLine("Enter the Title again\n");
                                continue;
                            }




                        }
                        else if (selectedIndex == 1)
                        {

                        }
                        else if (selectedIndex == 2)
                        {

                        }
                        else if (selectedIndex == 3)
                        {

                        }
                        else if (selectedIndex == 4)
                        {

                        }
                        else if (selectedIndex == 5)
                            break;                 
                    }
                }
                else if (selectedIndex == 1)
                {
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
                            library.Add(new Book(title, author));
                        }
                        catch (Exception ex)
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
                            if (choois.Key == ConsoleKey.Y || choois.Key == ConsoleKey.N)
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
                else if (selectedIndex == 2)
                {
                    check = false;
                    Console.WriteLine("Good-Bay!");
                }
                

                else continue;











            }


        }
    }
}
