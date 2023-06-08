using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Lab2.Methods
{
    public class Hotel : IEquatable<Hotel>, IComparable<Hotel>
    {
        public string HotelName { get; set; }
        public string RoomType { get; set; }
        public decimal Price { get; set; }

        //public LinkedList<object> LinkedList
        //{
        //   get => default;
        //   set
        //   {
        //   }
        //}

        public Hotel (string hotelName, string roomType, decimal price)
        {
            this.HotelName = hotelName;
            this.RoomType = roomType;
            this.Price = price;
        }
        public bool Equals(Hotel other)
        {
            return HotelName == other.HotelName &&
                   RoomType == other.RoomType &&
                   Price == other.Price;
        }

        public int CompareTo(Hotel other)
        {
            return HotelName.CompareTo(other.HotelName);
        }

        /// <summary>
        /// Overrides the ToString method to display the HotelName, RoomType, and Price properties in a formatted string.
        /// </summary>
        public override string ToString()
        {
            return String.Format("| {0, -22} | {1, -15} | {2, -15} |", HotelName, RoomType, Price);
        }
    }
}
