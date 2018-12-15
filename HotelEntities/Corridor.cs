using System.Collections.Generic;
using System.Linq;

namespace HotelEntities
{
    public abstract class Corridor
    {
        public virtual List<Light> Lights { get; set; } = new List<Light>();
        public virtual List<AC> Acs { get; set; } = new List<AC>();
        
        public virtual int GetMaxPowerConsumption()
        {
            return Lights.Sum(l => l.PowerConsumption) +
                   Acs.Sum(a => a.PowerConsumption);
        }

        public virtual int GetCurrentPowerConsumption()
        {
            return Lights.Sum(l => l.IsOn() ? l.PowerConsumption : 0) +
                   Acs.Sum(a => a.IsOn() ? a.PowerConsumption : 0);
        }
    }
}

