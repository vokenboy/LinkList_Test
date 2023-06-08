using System;
using Xunit;
using FluentAssertions;
using Lab2.Methods;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace LabTests
{
    public class LinkedListTests
    {
        [Fact]
        public void Sort_Traveler_Data_Should_Sort_By_Surname()
        {
            Lab2.Methods.LinkedList<Traveler> travelers = new Lab2.Methods.LinkedList<Traveler>();
            var traveler1 = new Traveler("ZUMMY", "DUMMY", "ZUMMY", "DUMMY", 2);
            var traveler2 = new Traveler("DUMMY", "DUMMY", "ZUMMY", "DUMMY", 2);
            travelers.AddToEnd(traveler1);
            travelers.AddToEnd(traveler2);

            travelers.Sort();

            List<Traveler> expectedOrder = new List<Traveler> { traveler2, traveler1 };
            var actualOrder = travelers.ToList();
            actualOrder.SequenceEqual(expectedOrder).Should().BeTrue();
        }

        [Fact]
        public void Sort_Traveler_Data_Should_Sort_By_Name()
        {
            Lab2.Methods.LinkedList<Traveler> travelers = new Lab2.Methods.LinkedList<Traveler>();
            var traveler1 = new Traveler("ZUMMY", "DUMMY", "ZUMMY", "DUMMY", 2);
            var traveler2 = new Traveler("ZUMMY", "ZUMMY", "ZUMMY", "DUMMY", 2);
            var traveler3 = new Traveler("ZUMMY", "AUMMY", "ZUMMY", "DUMMY", 2);
            travelers.AddToEnd(traveler1);
            travelers.AddToEnd(traveler2);
            travelers.AddToEnd(traveler3);

            travelers.Sort();

            List<Traveler> expectedOrder = new List<Traveler> { traveler3, traveler1, traveler2  };
            var actualOrder = travelers.ToList();
            actualOrder.SequenceEqual(expectedOrder).Should().BeTrue();
        }

        [Fact]
        public void Sort_TravelersByPrice_Data_Should_Sort_By_Surname()
        {
            Lab2.Methods.LinkedList<TravelersByPrice> travelers = new Lab2.Methods.LinkedList<TravelersByPrice>();
            var traveler1 = new TravelersByPrice("DUMMY", "DUMMY", 3);
            var traveler2 = new TravelersByPrice("ZUMMY", "ZUMMY", 2);
            var traveler3 = new TravelersByPrice("AUMMY", "AUMMY", 2);
            travelers.AddToEnd(traveler1);
            travelers.AddToEnd(traveler2);
            travelers.AddToEnd(traveler3);

            travelers.Sort();

            List<TravelersByPrice> expectedOrder = new List<TravelersByPrice> { traveler3, traveler1, traveler2  };
            var actualOrder = travelers.ToList();
            actualOrder.SequenceEqual(expectedOrder).Should().BeTrue();
        }

        [Fact]
        public void Sort_Hotels_SortsByHotelName()
        {

            Lab2.Methods.LinkedList<Hotel> hotels = new Lab2.Methods.LinkedList<Hotel>();

            var hotel1 = new Hotel("Hotel C", "Single", 100);
            var hotel2 = new Hotel("Hotel A", "Double", 200);
            var hotel3 = new Hotel("Hotel B", "Twin", 150);

            hotels.AddToEnd(hotel1);
            hotels.AddToEnd(hotel2);
            hotels.AddToEnd(hotel3);

            hotels.Sort();

            List<Hotel> expectedOrder = new List<Hotel> { hotel2, hotel3, hotel1 };
            var actualOrder = hotels.ToList();
            actualOrder.SequenceEqual(expectedOrder).Should().BeTrue();
        }

        [Fact]
        public void Count_Should_Return_Number_Of_Items_In_LinkedList()
        {
            Lab2.Methods.LinkedList<Traveler> list = new Lab2.Methods.LinkedList<Traveler>();

            Traveler traveler1 = new Traveler("ZUMMY", "DUMMY", "ZUMMY", "DUMMY", 2);
            Traveler traveler2 = new Traveler("DUMMY", "DUMMY", "ZUMMY", "DUMMY", 2);
            Traveler traveler3 = new Traveler("DUMMY", "DUMMY", "ZUMMY", "DUMMY", 2);

            list.AddToEnd(traveler1);
            list.AddToEnd(traveler2);
            list.AddToEnd(traveler3);

            var count = list.Count();

            count.Should().Be(3);
        }

    }
}
