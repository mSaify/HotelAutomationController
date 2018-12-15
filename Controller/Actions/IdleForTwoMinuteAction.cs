using ActionContract;
using HotelEntities;

namespace Controller.Actions
{
    public class IdleForTwoMinuteAction : ActionBase, IAction
    {
        public IdleForTwoMinuteAction(ActionLocation actionLocation) : base(actionLocation)
        {
        }

        public IdleForTwoMinuteAction(Hotel hotel, ActionLocation actionLocation) : base(hotel,actionLocation)
        {
        }

        public void PerformAction()
        {
            var lockObj = new object();
            lock (lockObj)
            {
                Hotel
                    .Floors[ActionLocation.Floor]
                    .SubCorridors[ActionLocation.SubCorridor]
                        .Lights.ForEach(x => x.SwichOff());

                SwitchOnAcWhenPowerConsumptionIsDown();
            }
        }

        private void SwitchOnAcWhenPowerConsumptionIsDown()
        {
           
            while (SwitchedOffAcs.Stack.Count > 0)
            {
                var switchoffAcLocation = SwitchedOffAcs.Stack.Pop();
                if(switchoffAcLocation.Floor>-1)
                Hotel
                    .Floors[switchoffAcLocation.Floor]
                    .SubCorridors[switchoffAcLocation.SubCorridor]
                    .Acs.ForEach(x =>
                    {
                        if (ShouldAcBeOn(Hotel))
                            x.SwitchOn();
                    });
            }
        }
    }
}
