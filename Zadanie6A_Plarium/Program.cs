using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie6A_Plarium
{
    
    class Program
    {
        //Метод для вызова события
        static void EventCall(out char ch, KeyEvent keyEvent)
        {
            //Установка курсора для ввода символа
            Console.SetCursorPosition(CountWord.Count, 1);
            //Получает символ, соответствующий заданной клавише
            ch = Console.ReadKey().KeyChar;
            //Вызов события в методе, передача введённого символа
            keyEvent.NewKey(ch);
        }

        static void Main(string[] args)
        {
            KeyEvent keyEvent = new KeyEvent();
            OutMassage messageClass = new OutMassage();

            //Добавление обработчиков событий
            keyEvent.KeyPress += CountWord.Counting;
            keyEvent.KeyPress += messageClass.Message;
            Console.WriteLine("Введите несколько символов. Для останова введите точку.");

            char ch;
            //Работа цикла до ввода точки
            do
            {
                EventCall(out ch, keyEvent);
            } while (ch != '.');

            Console.WriteLine($"Было нажато {CountWord.Count} клавиш.");
            System.Console.ReadKey(true);

        }
    }
}
