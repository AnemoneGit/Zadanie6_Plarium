using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie6A_Plarium
{
    class CountWord
    {
        public static int Count = 0;
        //Обработчик события считает количество нажатий
        public static void Counting(object source, KeyEventArgs arg) => Count++;
    }
}
