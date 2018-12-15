using System.Linq;
using ActionContract;
using HotelEntities;

namespace Controller.Actions
{
    public class MovementAction : ActionBase, IAction
    {
        public MovementAction(ActionLocation actionLocation) : base(actionLocation)
        {
        }

        public MovementAction(ActionLocation actionLocation, Time dayNightTime) : base(actionLocation, dayNightTime)
        {
        }

        public MovementAction(Hotel hotel, ActionLocation actionLocation) : base(hotel,actionLocation)
        {
        }

        public void PerformAction()
        {
            if (DayNightTime == Time.Night)
            {
                var lockObj = new object();
                lock (lockObj)
                {
                    Hotel
                        .Floors[ActionLocation.Floor]
                        .SubCorridors[ActionLocation.SubCorridor]
                        .Lights.ForEach(x => x.SwitchOn());

                    SwitchOffSubCorridorsAcWhenPowerConsumptionExceeds();
                }
            }
        }
    }
}
