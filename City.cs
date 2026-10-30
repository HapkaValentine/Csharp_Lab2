using System;
using System.Collections.Generic;

namespace Lab2
{
    public class City
    {
        public string name;
        public List<string> paths;

        public City(string name)
        {
            this.name = name;
            this.paths = new List<string>();
        }

        public void AddPath(City city, int cost)
        {
            paths.Add(city.name + ":" + cost);
        }

        public string GetText()
        {
            string result = name + ": ";

            for (int i = 0; i < paths.Count; i++)
            {
                if (i > 0)
                {
                    result = result + ", ";
                }
                result = result + paths[i];
            }

            return result;
        }
    }
}