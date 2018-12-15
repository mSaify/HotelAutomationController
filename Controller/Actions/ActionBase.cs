using System;
using ActionContract;
using HotelEntities;

namespace Controller.Actions
{
    public abstract class ActionBase
    {
        protected readonly ActionLocation ActionLocation;
        //as this program uses only one Hotel this will get existing static object from Factory
        //this can be easily overridden by constructor by passing hotel object e.g. is controllerTest
        protected Hotel Hotel = HotelFactory.Hotel;

        protected Time DayNightTime;
        protected Predicate<Hotel> ShouldAcBeOn;
        protected ActionBase(ActionLocation actionLocation)
        {
            ActionLocation = actionLocation;
            ShouldAcBeOn = h => (!IsPowerConsumptionExceeded()) && (MaxToCurrentPoweConsumptionDiff() >= 10);
        }

        protected ActionBase(ActionLocation actionLocation, Time dayTime)
        {
            ActionLocation = actionLocation;
            ShouldAcBeOn = h => (!IsPowerConsumptionExceeded()) && (MaxToCurrentPoweConsumptionDiff() >= 10);
            DayNightTime = dayTime;
        }

        protected ActionBase(Hotel hotel)
        {
            Hotel = hotel;
        }

        protected ActionBase(Hotel hotel, ActionLocation actionLocation)
        {
            Hotel = hotel;
            ActionLocation = actionLocation;
            ShouldAcBeOn = h => (!IsPowerConsumptionExceeded()) && (MaxToCurrentPoweConsumptionDiff() >= 10);
        }
        
        protected ActionBase()
        {
            
        }

        protected void SwitchOffSubCorridorsAcWhenPowerConsumptionExceeds()
        {
            var subcorridorIndex = 0;
            foreach (var subCorridor in Hotel.Floors[ActionLocation.Floor].SubCorridors)
            {
                foreach (var ac in subCorridor.Acs)
                {
                    if (ac.IsOn() && IsPowerConsumptionExceeded())
                    {
                        ac.SwichOff();
                        SwitchedOffAcs.Stack
                            .Push(new ActionLocation(ActionLocation.Floor + 1, subcorridorIndex + 1));
                    }
                    else break;
                }
                subcorridorIndex++;
            }
        }

        protected bool IsPowerConsumptionExceeded()
        {
            return
                 Hotel.Floors[ActionLocation.Floor].CurrentPowerConsumption() >=
                 Hotel.Floors[ActionLocation.Floor].MaxPowerConsumption();
        }

        protected int MaxToCurrentPoweConsumptionDiff()
        {
            return
                Hotel.Floors[ActionLocation.Floor].MaxPowerConsumption() -
                 Hotel.Floors[ActionLocation.Floor].CurrentPowerConsumption();
        }
    }
}
