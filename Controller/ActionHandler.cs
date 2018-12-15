using ActionContract;
using Controller.Actions;
using HotelEntities;

namespace Controller
{
    public class ActionHandler
    {
        private readonly ActionType _movementType;
        private readonly ActionLocation _actionLocation;
        private readonly Time _dayNightTime;

        public ActionHandler(ActionLocation actionLocation, ActionType actionType)
        {
            _movementType = actionType;
            _actionLocation = actionLocation;
        }

        public ActionHandler(ActionLocation actionLocation, ActionType actionType, Time dayNightTime)
        {
            _movementType = actionType;
            _actionLocation = actionLocation;
            _dayNightTime = dayNightTime;
        }

        public IAction ProvideAction()
        {
            IAction action;
            if (_movementType == ActionType.Night)
            {
                action = new NightTimeAction();
            }
            else if (_movementType == ActionType.Day)
            {
                action = new DayTimeAction();
            }
            else if (_movementType == ActionType.Movement)
            {
               action = new MovementAction(_actionLocation,_dayNightTime);
            }
            else
            {
                action = new IdleForTwoMinuteAction(_actionLocation);
            }

            return action;
        }
    }
}
