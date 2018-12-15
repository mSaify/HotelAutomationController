using HotelEntities;

namespace Controller.Actions
{
    public class NightTimeAction : ActionBase, IAction
    {
        public NightTimeAction(Hotel hotel) : base(hotel)
        {
            
        }

        public NightTimeAction()
        {
            
        }
        public void PerformAction()
        {
                Hotel.Floors
                           .ForEach(mc =>
                              mc.MainCorridors
                               .ForEach(l =>
                                  l.Lights
                                      .ForEach(x => x.SwitchOn())));
        }
    }

    public class DayTimeAction : ActionBase, IAction
    {
        public DayTimeAction(Hotel hotel) : base(hotel)
        {

        }

        public DayTimeAction()
        {

        }
        public void PerformAction()
        {
            Hotel.Floors
                       .ForEach(mc =>
                          mc.MainCorridors
                           .ForEach(l =>
                              l.Lights
                                  .ForEach(x => x.SwichOff())));
        }
    }
}
