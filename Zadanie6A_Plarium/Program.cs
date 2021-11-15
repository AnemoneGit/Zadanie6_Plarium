using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie6A_Plarium
{/*Разработать программу, в которой создается обработчик событий нажатия клавиш. Событие называется KeyPress, и при каждом нажатии клавиши оно генерируется посредством вызова метода c.
Разработать собственный класс EventArgs, который будет хранить код клавиши:
class KeyEventArgs : EventArgs
{
public char ch;
}
Объявите делегат для события:
delegate void KeyHandler(object source, KeyEventArgs arg);
Разработать два класса, которые принимает уведомления о нажатии клавиши. При этом обработчик события в первом классе выводит на экран следующую строку: "Получено сообщение о нажатии клавиши: ", за которой следует символ, изображенный на клавише. Обработчик события второго класса считает количество нажатий.
Напишите программу, которая продемонстрирует работоспособность разработанных классов, делегатов и событий.
*/

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
