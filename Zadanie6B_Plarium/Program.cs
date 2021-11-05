using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie6B_Plarium
{
    class Program
    {
        static void Main(string[] args)
        {

            List<People> peoples = new List<People>();
            Dictionary<int, Region> regions = new Dictionary<int, Region>();
            Pogoda wether = new Pogoda();

            AddStartValue addStartValue;
            addStartValue = AddPeoples;
            addStartValue += AddRegion;
            addStartValue += AddWether;
            #region Обработка нажатия клавиши
            KeyEvent evnt = new KeyEvent();
            evnt.KeyDown += (sender, e) =>
            {
                switch (e.ch)
                {
                    case '1':
                        {
                            addStartValue();
                            break;
                        }
                    case '2':
                        {
                            wether.Notify += DisplayMessage; 
                            try
                            {
                                wether.GetPogoda(wether, regions[0]);//Вывести сведения о погоде в заданном регионе.
                            }
                            catch
                            {
                                Console.WriteLine($" Еще не установлены значения");
                            }
                           
                            wether.Notify -= DisplayMessage;
                            break;
                        }
                    case '3':
                        {
                            wether.Notify += DisplayMessage;
                            try
                            {
                                wether.GetData(wether, regions[1], "Снег", 0);// Вывести даты, когда в заданном регионе шел снег и температура была ниже заданной отрицательной.
                            }
                            catch
                            {
                                Console.WriteLine($" Еще не установлены значения");
                            }
                           
                            wether.Notify -= DisplayMessage;
                            break;
                        }
                    case '4':
                        {
                            wether.Notify += DisplayMessage;
                            try
                            {
                                wether.GetPogoda(wether, "английский");//Вывести информацию о погоде за прошедшую неделю в регионах, жители которых общаются на заданном языке.
                            }
                            catch
                            {
                                Console.WriteLine($" Еще не установлены значения");
                            }
                            
                            wether.Notify -= DisplayMessage;
                            break;
                        }
                    case '5':
                        {
                            wether.Notify += DisplayMessage;
                            try
                            {
                                wether.GetTemp(wether, 6000, regions);//Вывести среднюю температуру за прошедшую неделю в регионах с площадью больше заданной.
                            }
                            catch
                            {
                                Console.WriteLine($" Еще не установлены значения");
                            }
                            
                            wether.Notify -= DisplayMessage;
                            break;
                        }
                    case '0':
                        {
                            Console.WriteLine($"Программа завершена");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine($"такого значения не предусмотрено");
                            break;
                        }
                }
            };

            Console.WriteLine($"Управляющие команды: \n" +
                $"1-Заполнить все исхордными данными\n" +
                $"2-Вывести сведения о погоде в заданном регионе\n" +
                $"3-Вывести даты, когда в заданном регионе шел снег и температура была ниже заданной отрицательной\n" +
                $"4-Вывести информацию о погоде за прошедшую неделю в регионах, жители которых общаются на заданном языке\n" +
                $"5-Вывести среднюю температуру за прошедшую неделю в регионах с площадью больше заданной\n" +
                $"0-Выход\n");
            char ch;
            do
            {
                Console.Write("Введите комманду: ");
                ConsoleKeyInfo key;
                key = Console.ReadKey();
                ch = key.KeyChar; 
                Console.WriteLine("");
                evnt.OnKeyDown(key.KeyChar);
               
            }
            while (ch != '0');
            System.Console.ReadKey(true);
            #endregion
            #region Методы для добавления начальных значений
            void AddPeoples()
            {
                peoples.Add(new People("Евреи", "иврит"));
                peoples.Add(new People("Англичане", "английский"));
            }
            void AddRegion()
            {
                regions.Add(0, new Country("Британия", 7000, peoples[1]));
                regions.Add(1, new City("Израиль", 10000, peoples[0]));
                regions.Add(2, new Oblast("Шотландия", 4000, peoples[1]));
            }
            void AddWether()
            {
                wether.Add(new Pogoda(regions[0], new DateTime(2021, 10, 21, 00, 00, 00), 3, "Дождь"));
                wether.Add(new Pogoda(regions[0], new DateTime(2021, 10, 26, 00, 00, 00), -3, "Снег"));
                wether.Add(new Pogoda(regions[0], new DateTime(2021, 10, 23, 00, 00, 00), 13, "Солнце"));

                wether.Add(new Pogoda(regions[1], new DateTime(2021, 10, 2, 00, 00, 00), -6, "Снег"));
                wether.Add(new Pogoda(regions[1], new DateTime(2021, 10, 25, 00, 00, 00), -3, "Снег"));
                wether.Add(new Pogoda(regions[1], new DateTime(2021, 10, 30, 00, 00, 00), 13, "Дождь"));

                wether.Add(new Pogoda(regions[2], new DateTime(2021, 10, 19, 00, 00, 00), 3, "Дождь"));
                wether.Add(new Pogoda(regions[2], new DateTime(2021, 10, 25, 00, 00, 00), 13, "Снег"));
                wether.Add(new Pogoda(regions[2], new DateTime(2021, 10, 30, 00, 00, 00), 13, "Солнце"));
            }
            #endregion
        }

        private static void DisplayMessage(string message) => Console.WriteLine(message);

        delegate void AddStartValue();
    }
}
