using System;

namespace ActionContract
{
    public interface IActionPublisher
    {
        event EventHandler<ActionEventArgs> NewMotion;

        void Publish(string message);
    }
}
