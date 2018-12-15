using System.Collections.Generic;

namespace HotelEntities
{
    public class Hotel
    {
        public virtual List<Floor> Floors { get; set; } = new List<Floor>();

        public virtual Hotel With(Floor floor)
        {
            Floors.Add(floor);
            return this;
        }
    }
}
