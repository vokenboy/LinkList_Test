using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Xml.Linq;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;
using System.Runtime.InteropServices;

namespace Lab2.Methods
{
    public class InOutUtils
    {
        public form1 form1
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Clears the contents of a file with the set name.
        /// </summary>
        /// <param name="fileName">The name of the file to clear</param>
        public static void CreateOutFile(string fileName)
        {
            File.WriteAllText(fileName, string.Empty);
        }

        /// <summary>
        /// Reads a list of hotels from a file with the specified name.
        /// </summary>
        /// <param name="stream">The file to read hotels from</param>
        /// <returns>A linked list of hotels</returns>
        public static LinkedList<Hotel> ReadHotels(Stream stream)
        {
            using (StreamReader sr = new StreamReader(stream))
            {
                LinkedList<Hotel> hotels = new LinkedList<Hotel>();
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    string hotelName = parts[0];
                    string roomType = parts[1];
                    decimal price = decimal.Parse(parts[2]);
                    hotels.AddToEnd(new Hotel(hotelName, roomType, price));
                }
                return hotels;
            }
            
        }
        /// <summary>
        /// Reads a list of travelers from a file with the specified name.
        /// </summary>
        /// <param name="stream">The file to read travelers from</param>
        /// <returns>A linked list of travelers</returns>
        public static LinkedList<Traveler> ReadTravelers(Stream stream)
        {
            using (StreamReader sr = new StreamReader(stream))
            {
                LinkedList<Traveler> travelers = new LinkedList<Traveler>();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    string surname = parts[0];
                    string name = parts[1];
                    string hotelName = parts[2];
                    string roomType = parts[3];
                    int nightsCount = int.Parse(parts[4]);
                    travelers.AddToEnd(new Traveler(surname, name, hotelName, roomType, nightsCount));
                }
                return travelers;
            }
        }

        /// <summary>
        /// Prints data to a file.
        /// </summary>
        /// <typeparam name="Type">The type of data to print.</typeparam>
        /// <param name="fileName">The name of the file to print to.</param>
        /// <param name="header">The header to print at the top of the file.</param>
        /// <param name="tableHeader">The header to print above the table of data.</param>
        /// <param name="list">The list of data to print.</param>
        public static void PrintData<Type>(string fileName, string header, string tableHeader, IEnumerable<Type> list)
            where Type : IComparable<Type>, IEquatable<Type>
        {
            using (var writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(header);
                writer.WriteLine(new string('-', tableHeader.Length));
                writer.WriteLine(tableHeader);
                writer.WriteLine(new string('-', tableHeader.Length));
                if (list.Count() == 0)
                {
                    writer.WriteLine(string.Format("| Nėra duomenų " + new string(' ', tableHeader.Length - 16) + "|"));
                }
                foreach (Type temp in list)
                {
                    writer.WriteLine(temp.ToString());
                }
                writer.WriteLine(new string('-', tableHeader.Length));
                writer.WriteLine();
            }
        }
    }
}
