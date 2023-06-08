using System;
using Xunit;
using FluentAssertions;
using Lab2.Methods;
using System.Collections;
using System.Linq;

namespace LabTests
{
    public class LinkedListTests
    {
        [Fact]
        public void IsEmpty_List_True()
        {
            LinkedList<Hotel> list = new LinkedList<Hotel>();
            list.IsEmpty().Should().BeTrue();
        }

        [Fact]
        public void IsEmpty_List_False()
        {
            LinkedList<Hotel> list = new LinkedList<Hotel>();
            list.AddToEnd(new Hotel("ZUMMY", "ZUMMY", 10));
            list.IsEmpty().Should().BeFalse();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(5)]
        public void Count_How_Many_Added_To_List(int count)
        {
            LinkedList<Hotel> list = new LinkedList<Hotel>();
            for (int i = 0; i < count; i++)
            {
                list.AddToEnd(new Hotel("ZUMMY", "ZUMMY", 10));
            }

            list.Count().Should().Be(count);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(5)]
        public void Get_Specific_Index(int index)
        {
            LinkedList<Hotel> list = new LinkedList<Hotel>();

            Hotel dummy = new Hotel("ZUMMY", "ZUMMY", 10);
            Hotel bore = new Hotel("BORE", "BORE", 20);

            if (index == 0)
            {
                list.AddToEnd(dummy);
                for (int i = 1; i < 5; i++) { list.AddToEnd(bore); }
            }
            if (index == 1)
            {
                list.AddToEnd(bore);
                list.AddToEnd(dummy);
                for (int i = 2; i < 5; i++) { list.AddToEnd(bore); }
            }
            if (index == 5)
            {
                for (int i = 0; i < 5; i++) { list.AddToEnd(bore); }
                list.AddToEnd(dummy);
            }

            list.Get(index).HotelName.Should().Be(dummy.HotelName);
        }

        [Fact]
        public void Sort_List_Is_Empty()
        {
            LinkedList<Hotel> list = new LinkedList<Hotel>();
            LinkedList<Hotel> listCopy = list;
            list.Sort();

            list.Equals(listCopy).Should().BeTrue();
        }

        [Fact]
        public void Sort_Works()
        {
            LinkedList<Hotel> list = new LinkedList<Hotel>();
            list.AddToEnd(new Hotel("ZUMMY", "ZUMMY", 10));
            list.AddToEnd(new Hotel("ZUMMY", "ZUMMY", 10));

            list.Sort();
            list.Get(0).Should().BeLessThan(list.Get(1));
        }
        [Fact]
        public void Sort_Customer_Data_Works_AgentCode()
        {
            LinkedList<Traveler> list = new LinkedList<Traveler>();
            list.AddToEnd(new Traveler("ZUMMY", "DUMMY", "DUMMY", "DUMMY", 1));
            list.AddToEnd(new Traveler("ZUMMY", "DUMMY", "DUMMY", "DUMMY", 1));

            list.Sort();
            list.Get(0).Should().BeLessThan(list.Get(1));

        }
        [Fact]
        public void Sort_Customer_Data_Works_Adress()
        {
            LinkedList<Traveler> list = new LinkedList<Traveler>();
            list.AddToEnd(new Traveler("ZUMMY", "DUMMY", "DUMMY", "DUMMY", 1));
            list.AddToEnd(new Traveler("ZUMMY", "DUMMY", "DUMMY", "DUMMY", 1));

            list.Sort();
            list.Get(0).Should().BeLessThan(list.Get(1));

        }
        [Fact]
        public void Sort_Customer_Data_Works_LastName()
        {
            LinkedList<Traveler> list = new LinkedList<Traveler>();
            list.AddToEnd(new Traveler("DUMMY", "ZUMMY", "DUMMY", "DUMMY", 1));
            list.AddToEnd(new Traveler("DUMMY", "DUMMY", "DUMMY", "DUMMY", 1));

            list.Sort();
            list.Get(0).Should().BeLessThan(list.Get(1));

        }
    }
}
