using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Lab2.Methods
{
    public class Traveler : IEquatable<Traveler>, IComparable<Traveler>
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string HotelName { get; set; }
        public string RoomType { get; set; }
        public int NightsCount { get; set; }

        //public LinkedList<object> LinkedList
        //{
        //    get => default;
        //    set
        //    {
        //    }
        //}

        public Traveler(string surname, string name, string hotelName, string roomType, int nightsCount)
        {
            this.Surname = surname;
            this.Name = name;
            this.HotelName = hotelName;
            this.RoomType = roomType;
            this.NightsCount = nightsCount;
        }

        public override string ToString()
        {
            return String.Format("| {0, -26} | {1, -15} | {2, -26} | {3, -15} | {4, -20} |", Surname, Name, HotelName, RoomType, NightsCount);
        }

        public bool Equals(Traveler other)
        {
            return Surname == other.Surname &&
                   Name == other.Name &&
                   HotelName == other.HotelName &&
                   RoomType == other.RoomType &&
                   NightsCount == other.NightsCount;
        }

        public int CompareTo(Traveler other)
        {
            int compareResult = Surname.CompareTo(other.Surname);

            if (compareResult == 0)
            {
                compareResult = Name.CompareTo(other.Name);
            }

            return compareResult;
        }

        public static bool operator <(Traveler a, Traveler b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator >(Traveler a, Traveler b)
        {
            return a.CompareTo(b) > 0;
        }
    }
}
