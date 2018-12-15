using System;

namespace HotelEntities
{
    public static class HotelFactory
    {
        private static Hotel _hotel;
        public static Hotel Hotel
        {
            get
            {
                if (_hotel == null)
                {
                   //create default hotel
                   //for sake for testing
                   CreateHotel(2, 1, 2);
                }

                return _hotel;
            }
        }
        
        public static void CreateHotel(int floors, int mainCorridors, int subCorridors)
        {
            _hotel = new Hotel();
            for (int i = 0; i < Convert.ToInt32(floors); i++)
            {
                var floor = new Floor();
                for (int j = 0; j < Convert.ToInt32(mainCorridors); j++)
                {
                    floor.MainCorridors
                            .Add(new MainCorridor()
                            .With(new Light())
                            .With(new AC()));
                }

                for (int j = 0; j < Convert.ToInt32(subCorridors); j++)
                {
                    floor.SubCorridors
                            .Add(new SubCorridor()
                                .With(new Light() {Switch = Switch.OFF})
                                .With(new AC()));
                }

                _hotel.Floors.Add(floor);
            }
        }
    }
}
