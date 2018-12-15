using System.ComponentModel;

namespace ActionContract
{
    public enum ActionType
    {
        [Description("Movement")]
        Movement = 0,

        [Description("No Movement")]
        IdleForMinute = 1,
        [Description("Night Time")]
        Night = 2,

        [Description("Day Time")]
        Day = 3
    }
}