using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.Methods
{
    public class TravelersByPrice : IEquatable<TravelersByPrice>, IComparable<TravelersByPrice>
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        //public LinkedList<object> LinkedList
        //{
        //   get => default;
        //   set
        //   {
        //   }
        //}

        public TravelersByPrice(string surname, string name, decimal price)
        {
            this.Surname = surname;
            this.Name = name;
            this.Price = price;
        }
        public bool Equals(TravelersByPrice other)
        {
            return Surname == other.Surname &&
                   Name == other.Name &&
                   Price == other.Price;
        }

        public int CompareTo(TravelersByPrice other)
        {
            int compareResult = Surname.CompareTo(other.Surname);

            if (compareResult == 0)
            {
                compareResult = Name.CompareTo(other.Name);
            }

            return compareResult;
        }

        /// <summary>
        /// Overrides the ToString method to display the surname, name and price properties in a formatted string.
        /// </summary>
        public override string ToString()
        {
            return String.Format("| {0, -22} | {1, -15} | {2, -15} |", Surname, Name, Price);
        }
    }
}