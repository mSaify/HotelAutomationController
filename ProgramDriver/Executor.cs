using System;
using Controller;
using HotelEntities;

namespace ProgramDriver
{
    public class Executor
    {
        private static ActionPublisher _actionPublisher;
        static void Main()
        {
            CreateHotel();
            InstallMotionSensorAndController();
            SenseMotion();
        }

        private static void InstallMotionSensorAndController()
        {
            _actionPublisher = new ActionPublisher(); //motion sensor is the publisher
            new ActionSubscriber(_actionPublisher); //subscriber is the Controller

            Console.WriteLine("\n Motion Sensor and Controller Installed!!!");
        }

        private static void SenseMotion()
        {
            var isExitTrue = false;
            Console.WriteLine("\n Sensing Changes!!");

            Console.WriteLine("\n Night Time Default State!!");
            ConsoleHelper.PrintHotelAcandLightSate();

            while (!isExitTrue)
            {
                var input = ConsoleHelper.SenseInputFromConsole();
                _actionPublisher.Publish(input);
                ConsoleHelper.PrintHotelAcandLightSate();


                Console.WriteLine("\n\n Do you want to sense more action?(Y(y)/N(n))");
                isExitTrue = Console.ReadLine().ToLower() == "y" ? false : true;
            }

            Console.WriteLine(" Press key to exit.");
            Console.ReadLine();
        }


        /// <summary>
        /// Create hotel on basis of user input
        /// </summary>
        static void CreateHotel()
        {
            Console.WriteLine("Creating Hotel..");
            Console.WriteLine("Enter Number of Floors");
            var floors = Console.ReadLine();
            Console.WriteLine("Main Corridors per floor");
            var mainCorridors = Console.ReadLine();
            Console.WriteLine("Sub Corridors per floor");
            var subCorridors = Console.ReadLine();

            HotelFactory.CreateHotel(Convert.ToInt32(floors), Convert.ToInt32(mainCorridors), Convert.ToInt32(subCorridors));
        }
    }
}
