using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhino.Ibis.Reviews
{
    public class TestNotRunException : Exception
    {
        public TestNotRunException() : base("Property was never calculated. Results are null or invalid.")
        {

        }

        public TestNotRunException(string message) : base(message)
        {

        }
    }
}
