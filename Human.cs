using System;

namespace Lab2
{
    public class Human
    {
        public Name name;
        public int height;
        public Human father;

        public Human(Name name, int height, Human father)
        {
            this.name = name;
            this.height = height;
            this.father = father;

            if (father != null)
            {
                if (name.lastName == null && father.name.lastName != null)
                {
                    name.lastName = father.name.lastName;
                }

                if (name.middleName == null && father.name.firstName != null)
                {
                    name.middleName = father.name.firstName + "ович";
                }
            }
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

        public string GetText()
        {
            return name.GetText() + ", " + height;
        }
    }
}