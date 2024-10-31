using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wifi.TeilnehmerVerwaltungV4.Core
{
    public class Teilnehmer
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public int Plz { get; set; }
        public string Ort { get; set; }
        public DateTime Geburtsdatum { get; set; }
    }
}
