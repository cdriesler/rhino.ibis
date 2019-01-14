using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhino.Ibis.Geometry
{
    public class InvalidRegionException : Exception
    {
        public InvalidRegionException(string reason) : base($"Region is not valid: {reason}")
        {

        }
    }
}
