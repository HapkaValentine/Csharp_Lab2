using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public class Name
    {
        private string lastName;
        private string firstName;
        private string middleName;

        public Name(string firstName)
        {
            this.firstName = firstName;
        }

        public Name(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public Name(string firstName, string lastName, string middleName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.middleName = middleName;
        }

        public string LastName
        {
            get { return lastName; }
        }

        public string FirstName
        {
            get { return firstName; }
        }

        public string MiddleName
        {
            get { return middleName; }
        }

        public void SetLastName(string value)
        {
            lastName = value;
        }

        public void SetMiddleName(string value)
        {
            middleName = value;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (lastName != null)
            {
                sb.Append(lastName);
            }

            if (firstName != null)
            {
                if (sb.Length > 0)
                {
                    sb.Append(' ');
                }

                sb.Append(firstName);
            }

            if (middleName != null)
            {
                if (sb.Length > 0)
                {
                    sb.Append(' ');
                }

                sb.Append(middleName);
            }

            return sb.ToString();
        }
    }

    public class Human
    {
        private Name name;
        private int height;
        private Human father;

        public Human(Name name, int height, Human father)
        {
            this.name = name;
            this.height = height;
            this.father = father;
            InheritFromFather();
        }

        public Human(Name name, int height)
            : this(name, height, null)
        {
        }

        public Human(string name, int height)
            : this(new Name(name), height, null)
        {
        }

        public Human(string name, int height, Human father)
            : this(new Name(name), height, father)
        {
        }

        public Name Name
        {
            get { return name; }
        }

        public int Height
        {
            get { return height; }
        }

        public Human Father
        {
            get { return father; }
        }

        private void InheritFromFather()
        {
            if (father == null)
            {
                return;
            }

            if (name.LastName == null && father.Name.LastName != null)
            {
                name.SetLastName(father.Name.LastName);
            }

            if (name.MiddleName == null && father.Name.FirstName != null)
            {
                name.SetMiddleName(father.Name.FirstName + "ович");
            }
        }

        public override string ToString()
        {
            return name.ToString() + ", " + height;
        }
    }

    public class Path
    {
        private City city;
        private int cost;

        public Path(City city, int cost)
        {
            this.city = city;
            this.cost = cost;
        }

        public City City
        {
            get { return city; }
        }

        public int Cost
        {
            get { return cost; }
        }

        public override string ToString()
        {
            return city.Name + ":" + cost;
        }
    }

    public class City
    {
        private string name;
        private List<Path> paths;

        public City(string name)
        {
            this.name = name;
            this.paths = new List<Path>();
        }

        public string Name
        {
            get { return name; }
        }

        public void AddPath(City city, int cost)
        {
            paths.Add(new Path(city, cost));
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(name);
            sb.Append(": ");

            for (int i = 0; i < paths.Count; i++)
            {
                if (i > 0)
                {
                    sb.Append(", ");
                }

                sb.Append(paths[i].ToString());
            }

            return sb.ToString();
        }
    }

    public class Cat
    {
        private string name;

        public Cat(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }

        public void Meow()
        {
            Console.WriteLine(name + ": мяу!");
        }

        public void Meow(int n)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(name);
            sb.Append(": ");

            for (int i = 0; i < n; i++)
            {
                if (i > 0)
                {
                    sb.Append("-");
                }

                sb.Append("мяу");
            }

            sb.Append("!");
            Console.WriteLine(sb.ToString());
        }

        public override string ToString()
        {
            return "кот: " + name;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("=== Лабораторная работа №2 ===");
                Console.WriteLine("1 - Задание 1. Имена");
                Console.WriteLine("2 - Задание 2. Человек с именем");
                Console.WriteLine("3 - Задание 2. Человек с родителем");
                Console.WriteLine("4 - Задание 3. Города");
                Console.WriteLine("5 - Задание 4.5. Создаем Имена");
                Console.WriteLine("6 - Задание 4.6. Создаем Человека");
                Console.WriteLine("7 - Задание 5. Кот мяукает");
                Console.WriteLine("8 - Кот мяукает (с вводом N)");
                Console.WriteLine("0 - Выход");
                Console.Write("Выберите пункт: ");

                int choice = ReadInt(0, 8);

                if (choice == 0)
                {
                    return;
                }

                switch (choice)
                {
                    case 1:
                        Task1();
                        break;
                    case 2:
                        Task2();
                        break;
                    case 3:
                        Task3();
                        break;
                    case 4:
                        Task4();
                        break;
                    case 5:
                        Task5();
                        break;
                    case 6:
                        Task6();
                        break;
                    case 7:
                        Task7();
                        break;
                    case 8:
                        Task8();
                        break;
                }
            }
        }

        private static void Task1()
        {
            Console.WriteLine();
            Console.WriteLine("--- Задание 1. Имена ---");

            Name cleopatra = new Name("Клеопатра");
            Name pushkin = new Name("Александр", "Пушкин", "Сергеевич");
            Name mayakovsky = new Name("Владимир", "Маяковский");

            Console.WriteLine(cleopatra.ToString());
            Console.WriteLine(pushkin.ToString());
            Console.WriteLine(mayakovsky.ToString());
        }

        private static void Task2()
        {
            Console.WriteLine();
            Console.WriteLine("--- Задание 2. Человек с именем ---");

            Human cleopatra = new Human(new Name("Клеопатра"), 152);
            Human pushkin = new Human(new Name("Александр", "Пушкин", "Сергеевич"), 167);
            Human mayakovsky = new Human(new Name("Владимир", "Маяковский"), 189);

            Console.WriteLine(cleopatra.ToString());
            Console.WriteLine(pushkin.ToString());
            Console.WriteLine(mayakovsky.ToString());
        }

        private static void Task3()
        {
            Console.WriteLine();
            Console.WriteLine("--- Задание 2. Человек с родителем ---");

            Human ivan = new Human(new Name("Иван", "Чудов"), 180);
            Human peter = new Human(new Name("Петр"), 175, ivan);
            Human boris = new Human(new Name("Борис"), 170, peter);

            Console.WriteLine(ivan.ToString());
            Console.WriteLine(peter.ToString());
            Console.WriteLine(boris.ToString());
        }

        private static void Task4()
        {
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
        }

        private static void Task5()
        {
            Console.WriteLine();
            Console.WriteLine("--- Задание 4.5. Создаем Имена ---");

            Name cleopatra = new Name("Клеопатра");
            Name pushkin = new Name("Александр", "Пушкин", "Сергеевич");
            Name mayakovsky = new Name("Владимир", "Маяковский");
            Name hristofor = new Name("Христофор", "Бонифатьевич");

            Console.WriteLine(cleopatra.ToString());
            Console.WriteLine(pushkin.ToString());
            Console.WriteLine(mayakovsky.ToString());
            Console.WriteLine(hristofor.ToString());
        }

        private static void Task6()
        {
            Console.WriteLine();
            Console.WriteLine("--- Задание 4.6. Создаем Человека ---");

            Human lev = new Human("Лев", 170);
            Human sergey = new Human(new Name("Сергей", "Пушкин"), 168, lev);
            Human alexander = new Human("Александр", 167, sergey);

            Console.WriteLine(lev.ToString());
            Console.WriteLine(sergey.ToString());
            Console.WriteLine(alexander.ToString());
        }

        private static void Task7()
        {
            Console.WriteLine();
            Console.WriteLine("--- Задание 5. Кот мяукает ---");

            Cat barsik = new Cat("Барсик");

            Console.WriteLine(barsik.ToString());
            barsik.Meow();
            barsik.Meow(3);
        }

        private static void Task8()
        {
            Console.WriteLine();
            Console.WriteLine("--- Задание 5. Кот мяукает (ввод N) ---");

            Console.Write("Введите имя кота: ");
            string catName = ReadNonEmptyString();

            Cat cat = new Cat(catName);
            Console.WriteLine(cat.ToString());

            cat.Meow();

            Console.Write("Введите N (сколько раз мяукнуть): ");
            int n = ReadInt(1, 100);
            cat.Meow(n);
        }

        private static int ReadInt(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out int value) && value >= min && value <= max)
                {
                    return value;
                }

                Console.Write("Ошибка! Введите число от " + min + " до " + max + ": ");
            }
        }

        private static string ReadNonEmptyString()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input.Trim();
                }

                Console.Write("Ошибка! Введите непустую строку: ");
            }
        }
    }
}