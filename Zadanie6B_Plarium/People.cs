using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie6B_Plarium
{
    class People
    {
        private string Nazvanie;
        public string Langue;
        public People(string Name, string langue)
        {
            Nazvanie = Name;
            Langue = langue;
        }
        public People(People other)
        {
            Nazvanie = other.Nazvanie;
            Langue = other.Langue;
        }
    }
}
