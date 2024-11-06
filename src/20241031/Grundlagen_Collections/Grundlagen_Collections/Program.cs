using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grundlagen_Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Array
            DateTime[] myDateList = new DateTime[4];

            var dateTimes = new List<DateTime>();
            List<string> names = new List<string>();

            var data = GetDataList();

            foreach (var item in data)
            {

            }
        }

        private static IEnumerable<double> GetDataList()
        {
            //return new List<double>();
            return new double[4];
        }
    }
}
