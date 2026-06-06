using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1_cat
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введи кол-во котов: ");
            int catCount;
            while(!int.TryParse(Console.ReadLine(), out catCount) || catCount <= 0)
            {
                Console.WriteLine("Неккорктный ввод, нужно вести положительное число");
            }
            Cat[] cats = new Cat[catCount];
            
            for(int i = 0; i < catCount; i++)
            {
                Console.WriteLine($"Введи имя кота {i + 1}: ");
                string name = Console.ReadLine();
                Console.WriteLine($"Введи вес кота {i + 1} (до 15кг)");
                double weight;
                while (!double.TryParse(Console.ReadLine(), out weight))
                {
                    Console.Write("Ошибка! Введи корректное число!");
                }
                cats[i] = new Cat(name, weight);
            }
            Console.WriteLine("\nКоты: ");
            foreach(Cat cat in cats)
            {
                cat.Meow();
            }
            Console.ReadKey();
        }
    }
}
