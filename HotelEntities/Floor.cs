using System.Collections.Generic;
using System.Linq;

namespace HotelEntities
{
    public class Floor
    {
        public virtual List<SubCorridor> SubCorridors { get; set; } = new List<SubCorridor>();

        public virtual List<MainCorridor> MainCorridors { get; set; } = new List<MainCorridor>();

        public virtual Floor With(MainCorridor corridor)
        {
            MainCorridors.Add(corridor);
            return this;
        }

        public virtual Floor With(SubCorridor corridor)
        {
            SubCorridors.Add(corridor);
            return this;
        }

        public virtual Floor MainCorridorsWithSingleAcAndLight(int corridorCount=1)
        {
            for (var i = 0; i < corridorCount; i++)
            {
                MainCorridors.Add(new MainCorridor().With(new Light(), new AC()));
            }
            return this;
        }

        public virtual Floor SubCorridorWithSingleAcAndLight(int corridorCount=1)
        {
            for (var i = 0; i < corridorCount; i++)
            {
                SubCorridors.Add(new SubCorridor().With(new Light(), new AC()));
            }
            return this;
        }

        public virtual int MaxPowerConsumption()
        {
            return SubCorridors.Count * 10 +  MainCorridors.Count * 15;
        }

        public virtual int CurrentPowerConsumption()
        {
            return SubCorridors.Sum(s => s.GetCurrentPowerConsumption()) +
                   MainCorridors.Sum(m => m.GetCurrentPowerConsumption());
        }
    }
}
