using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;    

namespace OOP_Progect_Library
{
    class Book
    {
        private readonly string Title;
        private readonly string Auther;
        public string Auther_ { get => Auther; }
        public string Title_ { get => Title; }

        public Book(string Title,string Auther)
        {
            this.Title = Title;
            this.Auther = Auther;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
          List <Book> library=new List<Book> ();
                














        }
    }
}
