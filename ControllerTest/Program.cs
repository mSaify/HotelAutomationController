using System;
using System.Linq;
using ActionContract;
using Controller;
using Controller.Actions;
using HotelEntities;
using NUnit.Framework;

namespace ControllerTest
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        [Test]
        public void GivenHotelInNightTime_ThenAllMainCorridorLightsShouldbeOn()
        {
            var hotel = new Hotel()
                            .With(new Floor()
                            .With(new MainCorridor()
                            .With(new Light() {Switch = Switch.OFF})));
            

            IAction actiontobePerformed = new NightTimeAction(hotel);
            actiontobePerformed.PerformAction();
            
            Assert.True(hotel
                          .Floors.First()
                            .MainCorridors.First()
                                .Lights.First()
                                    .Switch == Switch.ON);
        }

        [Test]
        public void GivenHotelInNightTime_WithSubCorridorACandLightsOff_WhenMotionDetected_ThenSubCorridorLightsShouldbeOn()
        {
            var hotel = new Hotel()
                .With(new Floor()
                .With(new MainCorridor()
                       .With(new Light())
                       .With(new AC()))
                .With(new SubCorridor()
                       .With(new Light() { Switch = Switch.OFF})
                       .With(new AC(){ Switch = Switch.OFF })));


            IAction actiontobePerformed = new MovementAction(hotel, new ActionLocation(1, 1));
            actiontobePerformed.PerformAction();

            Assert.True(hotel
                          .Floors.First()
                            .SubCorridors.First()
                                .Lights.First()
                                    .Switch == Switch.ON);
        }
        
        [Test]
        public void GivenHotelInNightTime_WithSubCorridorACOnandLightsOff_WhenIdealForAMin_ThenSubCorridorLightsShouldbeOff()
        {
            var hotel = new Hotel()
                .With(new Floor()
                .With(new MainCorridor()
                       .With(new Light())
                       .With(new AC()))
                .With(new SubCorridor()
                       .With(new Light() { Switch = Switch.ON })
                       .With(new AC() { Switch = Switch.ON })));

            SwitchedOffAcs.Stack.Clear();
            IAction actiontobePerformed = new IdleForTwoMinuteAction(hotel, new ActionLocation(1, 1));
            actiontobePerformed.PerformAction();

            Assert.True(hotel
                          .Floors.First()
                            .SubCorridors.First()
                                .Lights.First()
                                    .Switch == Switch.OFF);
        }

        [Test]
        public void GivenHotelInNightTime_WithManySubCorridorsACandLightsOn_WhenMotionDetectedInOneCorridor_LightShouldbeOnAndPowerConsumptionInRange()
        {
            var hotel = new Hotel()
                .With(new Floor()
                    .MainCorridorsWithSingleAcAndLight(corridorCount:2)
                    .SubCorridorWithSingleAcAndLight(corridorCount:5));

            var actionLocation = new ActionLocation(1, 1);
            IAction actiontobePerformed = new MovementAction(hotel, new ActionLocation(1, 1));
            actiontobePerformed.PerformAction();

            Assert.True(hotel
                          .Floors.First()
                            .SubCorridors[actionLocation.SubCorridor]
                                .Lights.First()
                                    .Switch == Switch.ON);

            var firstfloor = hotel
                .Floors.First();
            Console.WriteLine(firstfloor.MaxPowerConsumption());
            Console.WriteLine(firstfloor.CurrentPowerConsumption());
            Assert.True(firstfloor.MaxPowerConsumption() > firstfloor.CurrentPowerConsumption());
        }
    }
}
