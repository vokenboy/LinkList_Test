using Lab2.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class form1 : System.Web.UI.Page
    {

        /// <summary>
        /// Generates table with travelers data and inserts it into provided Table object
        /// </summary>
        /// <param name="table">Table object to insert data into</param>
        /// <param name="travelers">List of travelers to display</param>
        public void TravelersTable(Table table, Methods.LinkedList<Traveler> travelers)
        {
            table.Rows.Clear();

            TableRow header = new TableRow();
            header.Cells.Add(new TableCell { Text = "Pavardė" });
            header.Cells.Add(new TableCell { Text = "Vardas" });
            header.Cells.Add(new TableCell { Text = "Viesbučio pavadinimas" });
            header.Cells.Add(new TableCell { Text = "Kambario tipas" });
            header.Cells.Add(new TableCell { Text = "Naktų skaičius" });
            table.Rows.Add(header);

            if (travelers.Count() == 0)
            {
                TableRow noData = new TableRow();
                noData.Cells.Add(new TableCell { Text = "Nera duomenų", ColumnSpan = 5, HorizontalAlign = HorizontalAlign.Center });
                table.Rows.Add(noData);
            }
            else
            {
                foreach (Traveler traveler in travelers)
                {
                    TableRow row = new TableRow();
                    row.Cells.Add(new TableCell { Text = traveler.Surname });
                    row.Cells.Add(new TableCell { Text = traveler.Name });
                    row.Cells.Add(new TableCell { Text = traveler.HotelName });
                    row.Cells.Add(new TableCell { Text = traveler.RoomType });
                    row.Cells.Add(new TableCell { Text = traveler.NightsCount.ToString() });

                    table.Rows.Add(row);
                }
            }
            
        }
        /// <summary>
        /// Generates table with hotels data and inserts it into provided Table object
        /// </summary>
        /// <param name="table">Table object to insert data into</param>
        /// <param name="hotels">List of hotels to display</param>
        public void HotelsTable(Table table, Methods.LinkedList<Hotel> hotels)
        {
            table.Rows.Clear();

            TableRow header = new TableRow();
            header.Cells.Add(new TableCell { Text = "Viesbučio pavadinimas" });
            header.Cells.Add(new TableCell { Text = "Kambario tipas" });
            header.Cells.Add(new TableCell { Text = "Kaina" });
            table.Rows.Add(header);

            if (hotels.Count() == 0)
            {
                TableRow noData = new TableRow();
                noData.Cells.Add(new TableCell { Text = "Nera duomenų", ColumnSpan = 3, HorizontalAlign = HorizontalAlign.Center });
                table.Rows.Add(noData);
            }
            else
            {
                foreach (Hotel hotel in hotels)
                {
                    TableRow row = new TableRow();
                    row.Cells.Add(new TableCell { Text = hotel.HotelName });
                    row.Cells.Add(new TableCell { Text = hotel.RoomType });
                    row.Cells.Add(new TableCell { Text = hotel.Price.ToString() });
                    table.Rows.Add(row);
                }
            }
            
        }


        public void DisplayFilteredTravelers(Table table, Methods.LinkedList<TravelersByPrice> travelers)
        {
            table.Rows.Clear();

            TableRow header = new TableRow();
            header.Cells.Add(new TableCell { Text = "Pavardė" });
            header.Cells.Add(new TableCell { Text = "Vardas" });
            header.Cells.Add(new TableCell { Text = "Kaina" });
            table.Rows.Add(header);

            if (travelers.Count() == 0)
            {
                TableRow noData = new TableRow();
                noData.Cells.Add(new TableCell { Text = "Nera duomenu", ColumnSpan = 3, HorizontalAlign = HorizontalAlign.Center });
                table.Rows.Add(noData);
            }
            else
            {
                foreach (TravelersByPrice traveler in travelers)
                {
                    TableRow row = new TableRow();
                    row.Cells.Add(new TableCell { Text = traveler.Surname });
                    row.Cells.Add(new TableCell { Text = traveler.Name });
                    row.Cells.Add(new TableCell { Text = traveler.Price.ToString() });
                    table.Rows.Add(row);
                }
            }
        }


    }
}
