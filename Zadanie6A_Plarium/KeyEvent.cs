using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie6A_Plarium
{
    //Делегат для события
    public delegate void KeyHandler(object source, KeyEventArgs arg);
    //Класс, который хранит код клавиши
    public class KeyEventArgs : EventArgs
    {
        public char ch;
    }
    class KeyEvent
    {
        //Определение события
        public event KeyHandler KeyPress;
        protected virtual void OnKeyPress(KeyEventArgs arg)
        {
            var temp = KeyPress;
            //Вызов события, проверка на null перед вызовом
            temp?.Invoke(this, arg);
        }
        public void NewKey(char ch)
        {
            var arg = new KeyEventArgs();
            arg.ch = ch;
            OnKeyPress(arg);
        }
    }
}
