using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Lab2.Methods
{
    public class TaskUtils
    {
        public form1 form1
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Finds all travelers staying in a hotel.
        /// </summary>
        /// <param name="travelers">The list of all travelers</param>
        /// <param name="hotels">The list of all hotels</param>
        /// <returns>A linked list of travelers staying in a hotel of a certain room type</returns>
        public static LinkedList<Traveler> GetTravelersInHotelList(LinkedList<Traveler> travelers, LinkedList<Hotel> hotels)
        {
            LinkedList<Traveler> selectedTravelers = new LinkedList<Traveler>();
            foreach (Traveler traveler in travelers)
            {
                foreach (Hotel hotel in hotels)
                {
                    if (traveler.HotelName.Equals(hotel.HotelName) && traveler.RoomType.Equals(hotel.RoomType))
                    {
                        selectedTravelers.AddToEnd(traveler);
                        break;
                    }
                }
            }
            return selectedTravelers;
        }

        /// <summary>
        /// Finds all hotels with no travelers staying in them.
        /// </summary>
        /// <param name="travelers">The list of all travelers</param>
        /// <param name="hotels">The list of all hotels</param>
        /// <returns>A linked list of hotels with no visitors staying in them</returns>
        public static LinkedList<Hotel> GetHotelsWithNoVisitors(LinkedList<Traveler> travelers, LinkedList<Hotel> hotels)
        {
            LinkedList<Hotel> hotelsWithNoVisitors = new LinkedList<Hotel>();

            foreach (Hotel hotel in hotels)
            {
                bool hasVisitors = false;

                foreach (Traveler traveler in travelers)
                {
                    if (traveler.HotelName.Equals(hotel.HotelName) && traveler.RoomType.Equals(hotel.RoomType))
                    {
                        hasVisitors = true;
                        break;
                    }
                }
                if (!hasVisitors)
                {
                    hotelsWithNoVisitors.AddToEnd(hotel);
                }
            }

            return hotelsWithNoVisitors;
        }

        /// <summary>
        /// Finds all travelers who will stay the most nights in a hotel.
        /// </summary>
        /// <param name="travelers">The list of all travelers</param>
        /// <returns>A linked list of travelers who will stay the most nights in a hotel</returns>
        public static LinkedList<Traveler> GetTravelersWithMostNights(LinkedList<Traveler> travelers)
        {
            LinkedList<Traveler> travelersWithMostNights = new LinkedList<Traveler>();
            int maxNights = 0;

            foreach (Traveler traveler in travelers)
            {
                if (traveler.NightsCount > maxNights)
                {
                    travelersWithMostNights = new LinkedList<Traveler>();
                    maxNights = traveler.NightsCount;
                    travelersWithMostNights.AddToEnd(traveler);
                }
                else if (traveler.NightsCount == maxNights)
                {
                    travelersWithMostNights.AddToEnd(traveler);
                }
            }
            return travelersWithMostNights;


        }
        /// <summary>
        /// Finds the hotel associated with a traveler.
        /// </summary>
        /// <param name="traveler">Traveler object to find the hotel for.</param>
        /// <param name="hotels">List of hotels to search for the traveler's selected hotel.</param>
        /// <returns>Returns the Hotel object if found</returns>
        public static Hotel FindHotelByTraveler(Traveler traveler, LinkedList<Hotel> hotels)
        {
            foreach (Hotel hotel in hotels)
            {
                if (hotel.HotelName == traveler.HotelName && hotel.RoomType == traveler.RoomType)
                {
                    return hotel;
                }
            }
            return null;
        }

        /// <summary>
        /// Receives a hotel price.
        /// </summary>
        /// <param name="hotel">Hotel object to get the price from.</param>
        /// <returns>Returns the hotel price</returns>
        public static decimal GetHotelPriceOrDefault(Hotel hotel)
        {
            decimal price;
            if (hotel != null)
            {
                price = hotel.Price;
            }
            else
            {
                price = 0;
            }
            return price;
        }


        /// <summary>
        /// Filters a list of travelers by price.
        /// </summary>
        /// <param name="travelers">The list of travelers to filter.</param>
        /// <param name="hotels">The list of hotels to check prices against.</param>
        /// <param name="priceThreshold">The price threshold to filter by.</param>
        /// <returns>A linked list of TravelersByPrice objects containing the filtered travelers.</returns>
        public static LinkedList<TravelersByPrice> FilterTravelersByPrice(LinkedList<Traveler> travelers, LinkedList<Hotel> hotels, decimal priceThreshold)
        {
            LinkedList<TravelersByPrice> filteredTravelers = new LinkedList<TravelersByPrice>();

            foreach (Traveler traveler in travelers)
            {
                Hotel hotel = TaskUtils.FindHotelByTraveler(traveler, hotels);
                if (hotel != null && hotel.Price > priceThreshold)
                {
                    filteredTravelers.AddToEnd(new TravelersByPrice(traveler.Surname, traveler.Name, hotel.Price));
                }
            }
            return filteredTravelers;

        }

    }
}
