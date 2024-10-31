using ConsoleTableExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.TeilnehmerVerwaltungV4.Core;
using Wifi.TeilnehmerVerwaltungV4.DemoDataProvider;
using Wifi.TeilnehmerVerwaltungV4.DemoDataProvider.Entities;
using Wifi.TeilnehmerVerwaltungV4.Repository.Entities;

namespace Wifi.TeilnehmerVerwaltungV4.Application
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            var demoData = new RandomTeilnehmerProvider();
            var data = demoData.GetRandomData(20);

            var geoPositionProvider = new GeoPositionProvider();
            var geoPositions = geoPositionProvider.GetRandomData(10);
            

            ConsoleTableBuilder
               .From(data.ToList())
               .WithFormat(ConsoleTableBuilderFormat.Default)
               .ExportAndWriteLine(TableAligntment.Left);

            ConsoleTableBuilder
                .From(geoPositions.ToList())
                .WithFormat(ConsoleTableBuilderFormat.Default)
                .ExportAndWriteLine(TableAligntment.Left);
        }

        
    }
}
