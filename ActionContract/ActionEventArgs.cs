using System;
using HotelEntities;

namespace ActionContract
{
    public class ActionEventArgs : EventArgs
    {
        public ActionLocation ActionLocation { get; set; }

        public Time DayNightTime { get; set; }

        public ActionType ActionType { get; set; }

        public Hotel Hotel { get; set; }
    }

    public enum Time
    {
        Day,
        Night
    }
}