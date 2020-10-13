using System;
using static System.Console;
using System.Threading;

namespace Lab3
{

    public partial class Viewer
    {

    }

    public class Program
    {
        static bool check = false;
        static Car[] mas2 = null;

        public static void Main()
        {
            string a;
            while(true)
            {
                while(true)
                {
                    WriteLine("Выберите нужный пункт меню:");
                    WriteLine("1 - создать машины:");
                    WriteLine("2 - вывести машины(WriteLine):");
                    WriteLine("3 - вывести список машин по марке:");
                    WriteLine("4 - вывести список машин, которые используются больше заданного срока:");
                    WriteLine("5 - очистить консоль:");
                    WriteLine("6 - конструкторы:");
                    WriteLine("7 - вывод возраста выбранной машины:");
                    WriteLine("8 - вывод информации о классе:");
                    WriteLine("9 - :пример работы с out");
                    WriteLine("10 - вывод машин(ToString):");
                    WriteLine("11 - анонимный тип:");
                    WriteLine("12 - вызов закрытого конструктора:");
                    WriteLine("0 - для выхода:");
                    a = ReadLine();
                    if (a == "1")
                    {
                        check = true;
                        break;
                    }
                    if (a == "2" && check == false || a == "3" && check == false || a == "4" && check == false || a == "7" && check == false || a == "10" && check == false)
                    {
                        Console.Clear();
                        Console.WriteLine($"////////////////////////////////////////////////////");
                        Console.WriteLine("Автобусов в базе данных нет!");
                        Console.WriteLine($"////////////////////////////////////////////////////");
                    }
                    else { break; }
                }
                switch (a)
                {
                    case "1":
                        mas2 = Car.CreateACar(ref check);
                        continue;
                    case "2":
                        Car.Output(ref mas2);
                        continue;
                    case "3":
                        Car.ListCar(ref mas2);
                        continue;
                    case "4":
                        Car.ListCarAge(ref mas2);
                        continue;
                    case "5":
                        Clear();
                        continue;
                    case "6":
                        Construct();
                        continue;
                    case "7":
                        Car.CarAges(mas2);
                        continue;
                    case "8":
                        Car.Info();
                        continue;
                    case "9":
                        int numb = 0;
                        Car.Prm(out numb);
                        WriteLine(numb);
                        continue;
                    case "10":
                        Car.OutputWitchToString(mas2);
                        continue;
                    case "11":
                        Anonimous();
                        continue;
                    case "12":
                        UltraCar.OutputPrivate();
                        continue;
                    case "0": break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Ошибка ввода, такого пункта в меню нет");
                        continue;
                }
                break;
            }
        }
        static void Construct() //пример конструкторов
        {
            Car car1 = new Car("PA2948J79", "Mazda", "6", 23000, "красный", 2015, "9153UN03");
            Car car2 = new Car();
            WriteLine($"Машина car1");
            WriteLine($"ID машины: {car1.CarID}");
            WriteLine($"Марка машины: {car1.CarMark}");
            WriteLine($"Модель машины: {car1.CarModel}");
            WriteLine($"Цена машины в $: {car1.CarPrice}");
            WriteLine($"Цвет машины: {car1.CarColor}");
            WriteLine($"Год начала эксплуатации: {car1.CarAge}");
            WriteLine($"Регистрационный номер машины: {car1.CarNumb}");
            WriteLine($"////////////////////////////////////////////////////");
            WriteLine($"Машина car2");
            WriteLine($"ID машины: {car2.CarID}");
            WriteLine($"Марка машины: {car2.CarMark}");
            WriteLine($"Модель машины: {car2.CarModel}");
            WriteLine($"Цена машины: {car2.CarPrice}");
            WriteLine($"Цвет машины: {car2.CarColor}");
            WriteLine($"Год начала эксплуатации: {car2.CarAge}");
            WriteLine($"Регистрационный номер машины: {car2.CarNumb}");
            WriteLine($"////////////////////////////////////////////////////");
        }
        static void Anonimous()
        {
            var anonimous = new { firstname = "V", age = 777, secondname = " - Vendetta" };
            WriteLine($"////////////////////////////////////////////////////");
            WriteLine($"Данный тип: {anonimous.GetType()}");
            WriteLine($"////////////////////////////////////////////////////");
        }

    }
}