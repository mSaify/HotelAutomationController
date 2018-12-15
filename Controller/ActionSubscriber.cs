using ActionContract;

namespace Controller
{
    public sealed class ActionSubscriber
    {
        public ActionSubscriber(IActionPublisher publisher)
        {
            publisher.NewMotion += MotionHandler;
        }

        private void MotionHandler(object sender, ActionEventArgs eArgs)
        {
            var actionHandler = new ActionHandler(eArgs.ActionLocation, eArgs.ActionType, eArgs.DayNightTime);
            var actionTobePerfomred = actionHandler.ProvideAction();
            actionTobePerfomred.PerformAction();
        }
    }
}