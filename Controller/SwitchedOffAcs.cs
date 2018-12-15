using System.Collections.Generic;
using ActionContract;

namespace Controller
{
    public class SwitchedOffAcs
    {
        private static Stack<ActionLocation> _stack;
        public static Stack<ActionLocation> Stack => _stack ?? (_stack = new Stack<ActionLocation>());

    }
}
