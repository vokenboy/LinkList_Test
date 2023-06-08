using Lab2.Methods;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;


namespace Lab2
{
    public partial class form1 : System.Web.UI.Page
    {

        private const string inputFileA = @"App_Data/U17a.txt";
        private const string inputFileB = @"App_Data/U17b.txt";
        private const string outputFile = @"App_Data/Rezultatai.txt";

        private Methods.LinkedList<Hotel> Hotels;
        private Methods.LinkedList<Traveler> Travelers;
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Travelers = InOutUtils.ReadTravelers(FileUpload1.FileContent);
            Hotels = InOutUtils.ReadHotels(FileUpload2.FileContent);

            TravelersTable(Table1, Travelers);
            HotelsTable(Table2, Hotels);

            InOutUtils.CreateOutFile(Server.MapPath(outputFile));
            InOutUtils.PrintData(Server.MapPath(outputFile), "Keliautojai", String.Format("| {0, -26} | {1, -15} | {2, -26} | {3, -15} | {4, -20} |", "Pavardė", "Vardas", "Viesbucio pavadinimas", "Kambario tipas", "Nakvynių skaičius"), Travelers);
            InOutUtils.PrintData(Server.MapPath(outputFile), "Viesbučiai", String.Format("| {0, -22} | {1, -15} | {2, -15} |", "Viesbucio pavadinimas", "Kambario tipas", "Kaina"), Hotels);

            Methods.LinkedList<Traveler> TravelersByHotel = TaskUtils.GetTravelersInHotelList(Travelers, Hotels);
            TravelersByHotel.Sort();
            TravelersTable(Table3, TravelersByHotel);

            Methods.LinkedList<Hotel> NotSelectedHotels = TaskUtils.GetHotelsWithNoVisitors(Travelers, Hotels);
            NotSelectedHotels.Sort();
            HotelsTable(Table4, NotSelectedHotels);

            Methods.LinkedList<Traveler> TravelerMostNights = TaskUtils.GetTravelersWithMostNights(Travelers);
            TravelerMostNights.Sort();
            TravelersTable(Table5, TravelerMostNights);


            InOutUtils.PrintData(Server.MapPath(outputFile), "Keliautojų pasirinktų viešbučių sarašas:", String.Format("| {0, -26} | {1, -15} | {2, -26} | {3, -15} | {4, -20} |", "Pavardė", "Vardas", "Viesbucio pavadinimas", "Kambario tipas", "Nakvynių skaičius"), TravelersByHotel);
            InOutUtils.PrintData(Server.MapPath(outputFile), "Nepasirinktų viešbučių sarašas:", String.Format("| {0, -22} | {1, -15} | {2, -15} |", "Viesbucio pavadinimas", "Kambario tipas", "Kaina"), NotSelectedHotels);
            InOutUtils.PrintData(Server.MapPath(outputFile), "Keliautojai su daugiausia naktų:", String.Format("| {0, -26} | {1, -15} | {2, -26} | {3, -15} | {4, -20} |", "Pavardė", "Vardas", "Viesbucio pavadinimas", "Kambario tipas", "Nakvynių skaičius"), TravelerMostNights);

            decimal priceTreshhold = decimal.Parse(TextBox1.Text);

            Methods.LinkedList<TravelersByPrice> travelersByPrice = TaskUtils.FilterTravelersByPrice(TravelersByHotel, Hotels, priceTreshhold);

            InOutUtils.PrintData(Server.MapPath(outputFile), "Keliautojai su kurie sumokejo daugiau:", String.Format("| {0, -22} | {1, -15} | {2, -15} |", "Pavardė", "Vardas", "Kaina"), travelersByPrice);
            DisplayFilteredTravelers(Table6, travelersByPrice);
        }
    }
}
