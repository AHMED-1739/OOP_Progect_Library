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
using System.Runtime.CompilerServices;
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
        public List<Book> books=new List<Book>();
        public Library()
        {
            books = new List<Book>
            {
            new Book("Origins", "Lewis Dartnell", "History"),
            new Book("1491", "Charles C. Mann", "History"),
            new Book("Sapiens", "Yuval Noah Harari", "History"),
            new Book("Cosmos", "Carl Sagan", "Physics"),
            new Book("Light", "Albert A. Michelson", "Physics"),
            new Book("Quantum", "Manjit Kumar", "Physics"),
            new Book("Animal Farm", "George Orwell", "Novels"),
            new Book("Dracula", "Bram Stoker", "Novels"),
            new Book("Frankenstein", "Mary Shelley", "Novels"),
            new Book("Ethics", "Baruch Spinoza", "Philosophy"),
            new Book("Being", "Martin Heidegger", "Philosophy"),
            new Book("Existence", "Jean-Paul Sartre", "Philosophy")
            };
        }
        //search method
        public List<Book> Search(string Title,string Author)
        {
            if (string.IsNullOrWhiteSpace(Title) || string.IsNullOrWhiteSpace(Author))
                throw new Exception("Author name or book title cannot be blank.");
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
        public void Information_Of_Book(Book book)
        {
            WriteLine("Title: {0}\nAuthor: {1}\nSubject: {2}", book.Title, book.Author, book.Subject);
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
            else if (books.Count < 4)
                limit = books.Count;
            else 
                limit = 4;
            Random random = new Random();
            int i = 0;
            while (i < limit)
            {
                ForegroundColor = ConsoleColor.Black;
                BackgroundColor = ConsoleColor.White;
                int index = random.Next(0, books.Count);
                WriteLine("Title: {0}\nAuthor: {1}\nSubject: {2}", books[index].Title, books[index].Author, books[index].Subject);
                ResetColor();
                WriteLine("-----------------------------");
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
        //only used in run method.
        private void view()
        {
            if (Selected_Index >= Option.Length)
                Selected_Index = 0;
            WriteLine(Title + "\n");
            for (int i = 0; i < Option.Length; i++)
            {
                if (i != Selected_Index)
                    WriteLine($"-{Option[i]}");
                else
                {
                    BackgroundColor = ConsoleColor.Blue;
                    WriteLine($"-{Option[i]}  <<");
                    BackgroundColor = ConsoleColor.Black;
                }
            }
        }
        // this method will run the Menu.
        public int Run()
        { 
            ConsoleKeyInfo KeyPressed;
            do
            {
                Clear();
                view();
                KeyPressed = ReadKey(true);
                if (KeyPressed.Key == ConsoleKey.UpArrow)
                {
                    Selected_Index--;
                    if (Selected_Index == -1)
                        Selected_Index = Option.Length - 1;
                }

                else if (KeyPressed.Key == ConsoleKey.DownArrow)
                {
                    Selected_Index++;
                    if (Selected_Index > Option.Length)
                        Selected_Index = 0;
                }

            } while (KeyPressed.Key != ConsoleKey.Enter);
              Clear();
            return Selected_Index;
        }
       // just to ask the user if he want to repeate the process or not
      static  public ConsoleKeyInfo Answer_Y_N()
        {
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
             return choois;
        }
        static public (ConsoleKeyInfo, string )CaptureExitKey(string Title,string firstLine)
        {
            ConsoleKeyInfo keypressed;
            string TheString = "";
            Write(Title + "\n" + firstLine);
            do
            {
                keypressed = ReadKey(true);
                if (keypressed.Key == ConsoleKey.Backspace)
                {
                    if (TheString.Length > 0)
                    {
                        Clear();
                        Write(Title+"\n"+firstLine);
                        TheString = TheString.Remove(TheString.Length - 1);
                        Write(TheString);
                    }
                    continue;
                }
                if (keypressed.KeyChar != 13&&keypressed.KeyChar !=27)
                {
                    Write(keypressed.KeyChar);
                    TheString += keypressed.KeyChar;
                }
            } while (keypressed.Key != ConsoleKey.Escape && keypressed.Key != ConsoleKey.Enter);
            WriteLine();
                 return( keypressed,TheString);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] Start_Menu_Option = {"Search" ,"Add", "Exit" };
            string[] Search_Menu_Option = {  "Title & Author", "Title OR Author", "random books?","Subject", "Back" };
            string[] Subject_Menu_Option = { "History", "Physics", "Novels", "Philosophy", "Uncategorized" };
            Menu Start_Menu = new Menu(Start_Menu_Option, "-----library-----");
            Menu Search_Menu = new Menu(Search_Menu_Option, "----Search----");
            Menu Subject_Menu=new Menu(Subject_Menu_Option,"-----Subject-----");
            ConsoleKeyInfo choois;
            Library library = new Library();
            bool check = true;
            while (check)
            {
              
                int SelectedIndex = Start_Menu.Run();
                    //Search
                    if (SelectedIndex == 0)
                    {
                    
                    SelectedIndex = Search_Menu.Run();
                    Clear();
                    while (true)
                    {
                        WriteLine("-----Search-----");
                        if (SelectedIndex == 0)
                        {
                            Write("Enter the Title:");
                            try
                            {
                                WriteLine("Enter the Title :");
                                 string Title=ReadLine();
                                WriteLine("Enter The Author:");
                                string Author=ReadLine();   
                                List<Book> temp_List = library.Search(Title,Author);
                                if (temp_List == null)
                                { Clear(); WriteLine("the book not found."); }
                                else
                                {
                                    Clear(); WriteLine("Matching results:");
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
                            choois = Menu.Answer_Y_N();
                            if (choois.Key == ConsoleKey.N)
                                break;
                            else
                                continue;
                        }
                        else if (SelectedIndex == 1)
                        {
                            List<Book> temp_List_Author;
                            List<Book> temp_List_Title;
                            WriteLine("Enter the Title OR Author:");
                           (temp_List_Author,temp_List_Title)= library.SearchByBoth(ReadLine());
                            if (temp_List_Author.Count != 0)
                            {
                                WriteLine("Book that match the Author:");
                                for (int i = 0; i < temp_List_Author.Count; i++)
                                {
                                    WriteLine("Title: {0}\nAuthor: {1}\nSubject: {2}", temp_List_Author[i].Title, temp_List_Author[i].Author, temp_List_Author[i].Subject);
                                }
                            }
                            else WriteLine("Ther is no Author Match");
                            WriteLine();
                            if (temp_List_Title.Count != 0)
                            {
                                WriteLine("Restult that match the Title:");
                                for (int i = 0; i < temp_List_Title.Count; i++)
                                {
                                    WriteLine("Title: {0}\nAuthor: {1}\nSubject: {2}", temp_List_Title[i].Title, temp_List_Title[i].Author, temp_List_Title[i].Subject);
                                }
                            }
                            else WriteLine("ther is no book match the title");
                            WriteLine("Another search? Y/N");
                            choois = Menu.Answer_Y_N();
                            if (choois.Key == ConsoleKey.N)
                                break;
                            else
                                continue;
                        }
                        else if (SelectedIndex == 2)
                        { 
                             library.DisPlayRandomBook();
                            WriteLine("Another Search? Y/N");
                            choois = Menu.Answer_Y_N();
                            if (choois.Key == ConsoleKey.N)
                                break;
                            else
                                continue;
                        }
                        else if (SelectedIndex == 4)
                            break;
                   
                    }
                    }
                    //Add
                    if (SelectedIndex == 1)
                    {
                        Clear();
                        while (true)
                        {
                            try
                            {
                            string title;
                            string author;

                              (choois,title )=Menu.CaptureExitKey("ESC.\n---Add a book---","Enter the title: ");

                            if (choois.Key == ConsoleKey.Escape)
                            {
                                title = null;
                                Clear();
                                break;
                            }
                            Clear();
                            (choois,author )= Menu.CaptureExitKey($"ESC.\n---Add a book---\nEnter the title: {title} ", "Enter the author: ");
                            if (choois.Key == ConsoleKey.Escape)
                            {
                                author = null;
                                Clear();
                                break;
                            }
                            WriteLine("the Subject of the book");
                          
                            Clear();
                                library.Add(new Book(title, author, Subject_Menu_Option[Subject_Menu.Run()]));
                            } 
                            catch(Exception ex)
                            {
                                Clear();
                                WriteLine(ex.Message);
                                continue;
                            }           
                            WriteLine("add another book?\n Y/N");
                        choois = Menu.Answer_Y_N();
                        if (choois.Key == ConsoleKey.N)
                            break;
                        else
                            continue;
                      }
                    }
                    // Exit
                    if (SelectedIndex == 2)
                    {
                        check = false;
                        Clear();
                        WriteLine("Good_Bay!");
                    }              
            
                    


            } 

}}}
