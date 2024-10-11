using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klassen_GL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Instanziierung
            Book book = new Book();

            //book ==> Instanz

            book.Title = "Maskeraden";
            book.Author = "Michael Ende";
        }
    }
}
