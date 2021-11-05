using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie6A_Plarium
{
    class OutMassage
    { //Обработчик события выводит сообщение и поступивший символ
        public void Message(object source, KeyEventArgs arg)
        {
            //Установка позиции курсора
            Console.SetCursorPosition(0, CountWord.Count + 1);
            Console.WriteLine($"Получено сообщение о нажатии клавиши: {arg.ch}");
        }
    }
}
