using System;

namespace HotelEntities
{
    public class EntityGenerator
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Number of Floors");
            var floors = Console.ReadLine();
            Console.WriteLine("Enter Number of Main Corridors");
            var mainCorridors = Console.ReadLine();
            Console.WriteLine("Enter Number of Corridors");
            var subCorridors = Console.ReadLine();

            HotelFactory.CreateHotel(Convert.ToInt32(floors), Convert.ToInt32(mainCorridors), Convert.ToInt32(subCorridors));
        }
    }
}
    