using System;

namespace Lab2
{
    public class Cat
    {
        public string name;

        public Cat(string name)
        {
            this.name = name;
        }

        public void Meow()
        {
            Console.WriteLine(name + ": мяу!");
        }

        public void Meow(int n)
        {
            string result = name + ": ";

            for (int i = 0; i < n; i++)
            {
                if (i > 0)
                {
                    result = result + "-";
                }
                result = result + "мяу";
            }

            result = result + "!";
            Console.WriteLine(result);
        }

        public string GetText()
        {
            return "кот: " + name;
        }
    }
}