using System;
using HotelEntities;

namespace ProgramDriver
{
    internal static class ConsoleHelper
    {
        private const string Movement = "Movement";
        private const string NoMovement = "No Movement";
        internal static void PrintHotelAcandLightSate()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            var _hotel = HotelFactory.Hotel;
            int i,j = 0;
            for (i = 0; i < _hotel.Floors.Count; i++)
            {
                Console.WriteLine("Floor {0}",i+1);
                for (j = 0; j < _hotel.Floors[i].MainCorridors.Count; j++)
                {
                    Console.WriteLine("\t Main Corridor {0}", j + 1);

                    var corridor = _hotel.Floors[i].MainCorridors[j];
                    for (int k = 0; k < corridor.Lights.Count; k++)
                    {
                        Console.WriteLine("\t\t  Light {0} : {1}", k + 1, corridor.Lights[k].Switch);
                        Console.WriteLine("\t\t  AC {0} : {1}", k + 1, corridor.Acs[k].Switch);
                    }

                }

                for (j = 0; j < _hotel.Floors[i].SubCorridors.Count; j++)
                {
                    Console.WriteLine("\t Sub Corridor {0}", j + 1);

                    var corridor = _hotel.Floors[i].SubCorridors[j];
                    for (int k = 0; k < corridor.Lights.Count; k++)
                    {
                        Console.WriteLine("\t\t  Light {0} : {1}", j + 1, corridor.Lights[k].Switch);
                        Console.WriteLine("\t\t  AC {0} : {1}", j + 1, corridor.Acs[k].Switch);
                    }
                }
            }
        }

        internal static string SenseInputFromConsole()
        {
            Console.WriteLine("\n\nEnter sensed MovementType");
            Console.WriteLine("1 for {0}", Movement);
            Console.WriteLine("2 for {0}", NoMovement);
            int action;
            int.TryParse(Console.ReadLine(),out action);
            var actionType=  action == 1 || action == 0 ? Movement : NoMovement;
            Console.WriteLine("\nEnter location:");
            Console.WriteLine("Which floor? (e.g. 1 or 2)");
            var floor = Console.ReadLine();
            Console.WriteLine("Which subcorridor? (e.g. 1 or 2)");
            var subcorridor = Console.ReadLine();

            Console.WriteLine("\n\n{0} in Floor {1}, Sub Corridor {2}", actionType,floor,subcorridor);

            return actionType + "," + floor + "," + subcorridor;
        }
    }
}
