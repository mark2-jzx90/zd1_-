using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1_cat
{
    class Cat
    {
        private double weight;
        private string name;
        public string Name //св-во для имени
        {
            get
            {
                return name;
            }
            set
            {
                bool OnlyLetters = true;
                foreach (var ch in value)
                {
                    if (!char.IsLetter(ch))
                    {
                        OnlyLetters = false;
                    }
                }
                if (OnlyLetters && !string.IsNullOrEmpty(value))
                {
                    name = value;
                }

                else
                {
                    Console.WriteLine($"{value} - НЕПРАВИЛЬНОЕ ИМЯ!!");
                    name = "Кот без имени";
                }
                    
            }
        }


        public double Weight //св-во для веса
        {
            get
            {
                return weight;
            }
            set
            {
                if(value > 0 && value <= 15)
                {
                    weight = value;
                }
                else if(value > 15)
                {
                    Console.WriteLine($"{value}кг. Слишком ТОЛСТЫЙ кот. Кот не может весить больше 15 кг.");
                    weight = 15.0;
                }
                else
                {
                    Console.WriteLine($"{value} - неправильный вес. Ну не может вес быть отрицательным числом.");
                    weight = 1.0;
                }
            }
        }

        public Cat (string CatName, double CatWeight) //конструтор для калсса Cat
        {
            Name = CatName;
            Weight = CatWeight;
        }

        public void Meow() //Метод который позволяет котиков мяукать
        {
            Console.WriteLine($"{name} (вес: {weight} кг): МЯУУУУУ!");
        }
    }

}
