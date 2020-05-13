using System;

namespace Shapes
{
    public class InvalidValueExcepion : Exception
    {
        public InvalidValueExcepion(string message)
            : base(message)
        {

        }
    }
}
