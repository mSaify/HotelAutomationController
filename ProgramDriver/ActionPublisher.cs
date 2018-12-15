using System;
using ActionContract;

namespace ProgramDriver
{
    public sealed class ActionPublisher : IActionPublisher
    {
        public event EventHandler<ActionEventArgs> NewMotion;

        public void Publish(string message)
        {
            var args = ArgumentCreator.GetEventArgs(message);
            args.DayNightTime = Time.Day;
            args.ActionType = ActionType.Day;
            if (NewMotion != null)
            {
                NewMotion(this, args);
            }
        }
    }
}
