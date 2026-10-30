using System;

namespace Lab2
{
    public class Name
    {
        public string lastName;
        public string firstName;
        public string middleName;

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

        public string GetText()
        {
            string result = "";

            if (lastName != null)
            {
                result = result + lastName;
            }

            if (firstName != null)
            {
                if (result != "")
                {
                    result = result + " ";
                }
                result = result + firstName;
            }

            if (middleName != null)
            {
                if (result != "")
                {
                    result = result + " ";
                }
                result = result + middleName;
            }

            return result;
        }
    }
}