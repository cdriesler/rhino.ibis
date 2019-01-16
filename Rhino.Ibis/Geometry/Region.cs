using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;

namespace Rhino.Geometry
{
    /// <summary>
    /// [Rhino.Ibis Geometry] A closed and planar curve.
    /// </summary>
    public class Region
    {
        public Curve Curve { get; set; }
        public Plane Plane { get; set; }

        /// <summary>
        /// [Rhino.Ibis Geometry] A closed and planar curve.
        /// </summary>
        /// <param name="curve"></param>
        public Region(Curve curve)
        {
            Curve = curve;
            Curve.TryGetPlane(out var plane);

            if (plane != null) Plane = plane;
        }
    }
}
