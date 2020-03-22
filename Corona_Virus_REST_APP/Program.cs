using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corona_Virus_REST_APP
{
    class Program
    {
        static void Main(string[] args)
        {
            CoronaAffectedCountriesList list = new CoronaAffectedCountriesList();
            list.getDetailsOfInfectedCountries();
            Console.ReadKey();
        }
    }
}
