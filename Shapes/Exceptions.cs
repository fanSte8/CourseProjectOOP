using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
