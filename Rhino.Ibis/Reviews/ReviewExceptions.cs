using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhino.Ibis.Reviews
{
    public class UnresolvedPropertyException : Exception
    {
        public UnresolvedPropertyException() : base("Property was never calculated. Results are null or invalid.")
        {

        }

        public UnresolvedPropertyException(string message) : base(message)
        {

        }
    }
}
