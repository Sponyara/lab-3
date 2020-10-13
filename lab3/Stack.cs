using System;
using static System.Console;
using System.Threading;
using Microsoft.VisualBasic;
using System.Net.NetworkInformation;

namespace Lab3
{
    public class Car
    {
        string car_id;
        string car_mark;
        string car_model;
        uint car_age;
        string car_color;
        uint car_price;
        string car_numb;
        public static int CountOfCar = 0;
        public readonly string read = " Только что чтения ";


        public string CarID
        {
            get
            {
                return car_id;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(" ID не может быть пустым");
                }
                car_id = value;
            }
        }

        public string CarMark
        {
            get
            {
                return car_mark;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(" Марка машины не может быть пустой");
                }
                car_mark = value;
            }
        }

        public string CarModel
        {
            get
            {
                return car_model;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(" Модель машины не может быть пустой");
                }
                car_model = value;
            }
        }

        public uint CarAge
        {
            get
            {
                return car_age;
            }
            set
            {
                if (value > 2020)
                {
                    while (value > 2020)
                    {

                        Console.WriteLine("Год начала эксплуатации введён некорректно, введите год начала эксплуатации: ");

                        value = Convert.ToUInt32(Console.ReadLine());
                    }
                }
                car_age = value;
            }
        }

        public string CarColor
        {
            get
            {
                return car_color;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(" Цвет машины не может быть пустым");
                }
                car_color = value;
            }
        }

        public uint CarPrice
        {
            get
            {
                return car_price;
            }
            set
            {
                car_price = value;
            }
        }

        public string CarNumb
        {
            get
            {
                return car_numb;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(" Регистрационный номер не может быть пустым");
                }
                car_numb = value;
            }
        }

        public Car(string ci, string cma, string cmo, uint ca, string cc, uint cp, string cn)
        {
            car_id = ci;
            car_mark = cma;
            car_model = cmo;
            car_age = ca;
            car_color = cc;
            car_price = cp;
            car_numb = cn;
        }

        public Car()
        {
            car_id = "AA22O8K13";
            car_mark = "BMW";
            car_model = "X8";
            car_age = 2016;
            car_color = " Индиго";
            car_price = 25000;
            car_numb = "5281OP07";
        }

        static Car()
        {
            WriteLine("Вызов статического конструктора\n\n");

        }

        public static void Info()
        {
            WriteLine($"////////////////////////////////////////////////////");
            WriteLine($"Информация о классе . . .  Он в себе содержит:");
            WriteLine($"ID машины");
            WriteLine($"Марка машины");
            WriteLine($"Модель машины");
            WriteLine($"Год начала эксплуатации");
            WriteLine($"Цвет машины");
            WriteLine($"Цена машины");
            WriteLine($"Регистрационный номер");
            WriteLine($"////////////////////////////////////////////////////");

        }

        public static void CarAges(Car[] mas)
        {
            while (true)
            {
                byte age;
                while (true)
                {
                    WriteLine($"////////////////////////////////////////////////////");
                    WriteLine($"Введите номер машины( 0 - для возвращения обратно): ");
                    WriteLine($"////////////////////////////////////////////////////");
                    string a = ReadLine();

                    if (a == "0")
                    {
                        Program.Main();
                    }
                    try
                    {
                        age = Convert.ToByte(a);
                        break;
                    }
                    catch (SystemException)
                    {
                        WriteLine($"////////////////////////////////////////////////////");
                        WriteLine($"Номер введен некорректно");
                        WriteLine($"////////////////////////////////////////////////////");
                        continue;
                    }
                }
                if (age > Convert.ToByte(mas.Length) || age < 0)
                {
                    WriteLine($"////////////////////////////////////////////////////");
                    WriteLine($"Такого номера машины нет");
                    WriteLine($"////////////////////////////////////////////////////");
                    continue;
                }
                else
                {
                    WriteLine($"////////////////////////////////////////////////////");
                    WriteLine($" Возраст машины номер {age}: {2020 - mas[age - 1].car_age}");
                    break;
                }
            }
        }


        public static Car[] CreateACar(ref bool check)
        {
            string i;
            int count;
            while (true)
            {
                while (true)
                {
                    WriteLine($"////////////////////////////////////////////////////");
                    WriteLine("Введите количество машин (0 для отмены):");
                    WriteLine($"////////////////////////////////////////////////////");
                    i = ReadLine();
                    try
                    {
                        count = Convert.ToInt32(i);
                        break;
                    }
                    catch (SystemException)
                    {
                        WriteLine($"////////////////////////////////////////////////////");
                        WriteLine("Некорректно введено машин");
                        WriteLine($"////////////////////////////////////////////////////");
                        continue;
                    }
                }
                if (count < 0)
                {
                    WriteLine($"////////////////////////////////////////////////////");
                    WriteLine("Некорректно введено кол-во машин");
                    WriteLine($"////////////////////////////////////////////////////");
                    continue;
                }
                if (count == 0)
                {
                    check = false;
                    break;
                }
                else break;
            }

            Car[] mas = new Car[count];
            for (int u = 0; u < count; u++)
            {
                mas[u] = new Car();
                WriteLine($"////////////////////////////////////////////////////");
                WriteLine($"Машина номер {i + 1}");
                WriteLine("Введите ID автомобиля:");
                mas[u].CarID = ReadLine();
                WriteLine("Введите регистрационный номер машины(8 знаков)");
                mas[u].CarNumb = ReadLine();
                if (mas[u].CarNumb.Length != 8)
                {
                    while (mas[u].CarNumb.Length != 8)
                    {
                        WriteLine($"////////////////////////////////////////////////////");
                        WriteLine("Некорректно введён номер машины");
                        WriteLine("Введите регистрационный номер машины(8 знаков):");
                        mas[u].CarNumb = ReadLine();

                    }
                }
                while (true)
                {
                    WriteLine("Введите цену автомобиля в $:");
                    i = ReadLine();
                    try
                    {
                        mas[u].CarPrice = Convert.ToUInt32(i);
                        break;
                    }
                    catch (SystemException)
                    {
                        WriteLine($"////////////////////////////////////////////////////");
                        Console.WriteLine("Цена введена неверно");
                        WriteLine($"////////////////////////////////////////////////////");
                    }
                }
                WriteLine("Введите марку автомобиля:");
                mas[u].CarMark = ReadLine();
                WriteLine("Введите модель автомобиля:");
                mas[u].CarModel = ReadLine();
                WriteLine("Введите цвет автомобиля:");
                mas[u].CarColor = ReadLine();
                while (true)
                {
                    WriteLine("Введите год начала эксплуатации(4 числа):");
                    i = ReadLine();
                    if (i.Length != 4)
                    {
                        WriteLine($"////////////////////////////////////////////////////");
                        WriteLine("Год начала эксплуатации введён неверно");
                        WriteLine($"////////////////////////////////////////////////////");
                        continue;
                    }
                    try
                    {
                        mas[u].CarAge = Convert.ToUInt32(i);
                        break;
                    }
                    catch (SystemException)
                    {
                        WriteLine($"////////////////////////////////////////////////////");
                        WriteLine("Год начала эксплуатации введён неверно");
                        WriteLine($"////////////////////////////////////////////////////");
                    }
                }
            }
            Console.Clear();
            return mas;
        
        }

         public static void Output(ref Car[] mas) //Вывод всех экземпляров из массива
        {
            for (int i = 0; mas.Length > i; i++)
            {
                Console.WriteLine($"////////////////////////////////////////////////////");
                Console.WriteLine($"Машина номер {i + 1}");
                Console.WriteLine($"ID машины: {mas[i].CarID}");
                Console.WriteLine($"Марка машины: {mas[i].CarMark}");
                Console.WriteLine($"Модель машины: {mas[i].CarModel}");
                Console.WriteLine($"Цвет машины: {mas[i].CarColor}");
                Console.WriteLine($"Цена машины: {mas[i].CarPrice}");
                Console.WriteLine($"Год начала эксплуатации: {mas[i].CarAge}");
                Console.WriteLine($"Регистрационный номер машины: {mas[i].CarNumb}");
                Console.WriteLine($"////////////////////////////////////////////////////");
            }
            Car.CountOfCar = mas.Length;
            Console.WriteLine($"Всего Машин:{Car.CountOfCar}");
            Console.WriteLine($"////////////////////////////////////////////////////");
        }

        public static void ListCar(ref Car[] mas)
        {
            string b;
            byte count = 0;
            while (true)
            {
                WriteLine("Введите марку автомобиля(-ей), которые вы хотите посмотреть");
                string a = ReadLine();
                try
                {
                    b = Convert.ToString(a);
                    break;
                }
                catch (SystemException)
                {
                    WriteLine($"////////////////////////////////////////////////////");
                    WriteLine("Значение введено некорректно");
                    WriteLine($"////////////////////////////////////////////////////");
                }
            }
            WriteLine($"////////////////////////////////////////////////////");
            for (int i = 0; mas.Length > i; i++)
            {
                if (mas[i].CarMark == b)
                {
                    WriteLine($"Автомобиль номер {i + 1} марки {b}");
                    count++;
                }
            }
            if (count == 0)
            {
                WriteLine($"Автобусов с такой маркой нет :( ");
            }
            WriteLine($"////////////////////////////////////////////////////");
        }

        public static void ListCarAge(ref Car[] mas)
        {
            uint b;
            byte count = 0;
            while (true)
            {
                WriteLine($"Введите количество лет. Автомобили, которые используются больше заданного срока будут выведены на ваше обозрение  ");
                string a = ReadLine();
                if (Convert.ToInt32(a) > 100 || Convert.ToInt32(a) < 0)
                {
                    WriteLine($"Некорректное количество лет");
                    continue;
                }
                try
                {
                    b = Convert.ToUInt32(a);
                    break;
                }
                catch (SystemException)
                {
                    WriteLine($"Некорректное количество лет");
                    continue;
                }
            }
            WriteLine($"////////////////////////////////////////////////////");
            for ( int i = 0; mas.Length > i; i++)
            {
                int age = 2020;
                if ( b < (age - mas[i].CarAge))
                {
                    WriteLine($"Автомобиль номер {i + 1}");
                    count++;
                }
            }
            if (count == 0)
            {
                WriteLine("Подходящих машин нет");
            }
            WriteLine($"////////////////////////////////////////////////////");
        }

        public static void Prm(out int num)
        {
            num = 111 * 7;
        }

        public static void OutputWitchToString(Car[] mas)
        {
            for ( int i = 0; mas.Length > i; i++)
            {
                WriteLine(mas[i].ToString());
            }
        }

        public override string ToString()
        {
            return $"{car_id} {car_mark} {car_model} {car_age} {car_color} {car_price} {car_numb}";
        }

        public override int GetHashCode()
        {
            return car_id.GetHashCode();
        }
    }

    public class UltraCar : Car
    {

        private UltraCar()
        {
            WriteLine($"////////////////////////////////////////////////////");
            WriteLine("Москвич Ребеша Марка");
            WriteLine($"////////////////////////////////////////////////////");
        }

        public static void OutputPrivate()
        {
            UltraCar uc = new UltraCar();
        }
    }
    public partial class Viewer
    {

    }
}