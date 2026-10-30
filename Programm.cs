using System;

namespace Lab2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            Console.WriteLine("=== Задание 1. Имена ===");

            Name n1 = new Name("Клеопатра");
            Name n2 = new Name("Александр", "Пушкин", "Сергеевич");
            Name n3 = new Name("Владимир", "Маяковский");

            Console.WriteLine(n1.GetText());
            Console.WriteLine(n2.GetText());
            Console.WriteLine(n3.GetText());
            
            Console.WriteLine();
            Console.WriteLine("=== Задание 2.2. Человек с именем ===");

            Human h1 = new Human(new Name("Клеопатра"), 152);
            Human h2 = new Human(new Name("Александр", "Пушкин", "Сергеевич"), 167);
            Human h3 = new Human(new Name("Владимир", "Маяковский"), 189);

            Console.WriteLine(h1.GetText());
            Console.WriteLine(h2.GetText());
            Console.WriteLine(h3.GetText());
            
            Console.WriteLine();
            Console.WriteLine("=== Задание 2.3. Человек с родителем ===");

            Human ivan = new Human(new Name("Иван", "Чудов"), 180);
            Human peter = new Human(new Name("Петр"), 175, ivan);
            Human boris = new Human(new Name("Борис"), 170, peter);

            Console.WriteLine(ivan.GetText());
            Console.WriteLine(peter.GetText());
            Console.WriteLine(boris.GetText());
            
            Console.WriteLine();
            Console.WriteLine("=== Задание 3. Города ===");

            City a = new City("A");
            City b = new City("B");
            City c = new City("C");
            City d = new City("D");
            City e = new City("E");
            City f = new City("F");

            a.AddPath(b, 5);
            a.AddPath(f, 1);
            a.AddPath(d, 6);
            f.AddPath(b, 1);
            f.AddPath(e, 2);
            b.AddPath(c, 3);
            e.AddPath(d, 2);
            d.AddPath(c, 4);

            Console.WriteLine(a.GetText());
            Console.WriteLine(b.GetText());
            Console.WriteLine(c.GetText());
            Console.WriteLine(d.GetText());
            Console.WriteLine(e.GetText());
            Console.WriteLine(f.GetText());
            
            Console.WriteLine();
            Console.WriteLine("=== Задание 4.5. Создаем Имена ===");

            Name i1 = new Name("Клеопатра");
            Name i2 = new Name("Александр", "Пушкин", "Сергеевич");
            Name i3 = new Name("Владимир", "Маяковский");
            Name i4 = new Name("Христофор", "Бонифатьевич");

            Console.WriteLine(i1.GetText());
            Console.WriteLine(i2.GetText());
            Console.WriteLine(i3.GetText());
            Console.WriteLine(i4.GetText());
            
            Console.WriteLine();
            Console.WriteLine("=== Задание 4.6. Создаем Человека ===");

            Human lev = new Human("Лев", 170);
            Human sergey = new Human(new Name("Сергей", "Пушкин"), 168, lev);
            Human alexander = new Human("Александр", 167, sergey);

            Console.WriteLine(lev.GetText());
            Console.WriteLine(sergey.GetText());
            Console.WriteLine(alexander.GetText());
            
            Console.WriteLine();
            Console.WriteLine("=== Задание 5. Кот мяукает ===");

            Cat barsik = new Cat("Барсик");
            Console.WriteLine(barsik.GetText());
            barsik.Meow();
            barsik.Meow(3);

            Console.WriteLine();
            Console.WriteLine("=== Ввод кота с клавиатуры ===");

            Console.Write("Введите имя кота: ");
            string catName = ReadString();

            Cat userCat = new Cat(catName);
            Console.WriteLine(userCat.GetText());
            userCat.Meow();

            Console.Write("Введите N (от 1 до 100): ");
            int n = ReadInt(1, 100);
            userCat.Meow(n);
        }

        private static string ReadString()
        {
            while (true)
            {
                string s = Console.ReadLine();
                if (s != null && s.Trim() != "")
                {
                    return s.Trim();
                }
                Console.Write("Ошибка! Введите непустую строку: ");
            }
        }

        private static int ReadInt(int min, int max)
        {
            while (true)
            {
                string s = Console.ReadLine();
                if (int.TryParse(s, out int value))
                {
                    if (value >= min && value <= max)
                    {
                        return value;
                    }
                }
                Console.Write("Ошибка! Введите число от " + min + " до " + max + ": ");
            }
        }
    }
}