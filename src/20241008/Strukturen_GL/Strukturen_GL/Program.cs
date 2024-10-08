using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strukturen_GL
{
    struct Student
    {
        public string Name;
        public string Nachname;
        public int Plz;
        public DateTime Geburtsdatum;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Deklaration
            Student einTeilnehmer;

            //Erzeugung
            einTeilnehmer = new Student();

            //Initialisierung
            einTeilnehmer.Name = "No";
            einTeilnehmer.Nachname = "Name";
            einTeilnehmer.Geburtsdatum = DateTime.MinValue;
            einTeilnehmer.Plz = 0;

            Student[] studentList = new Student[10];
        }
    }


}
