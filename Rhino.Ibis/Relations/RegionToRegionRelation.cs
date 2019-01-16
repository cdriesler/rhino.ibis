using System;
using System.Collections.Generic;
using System.Text;
using Rhino.Geometry;

namespace Rhino.Ibis.Relations
{
    public class RegionToRegionRelation
    {
        public Region ThisGeometry { get; }
        public Region ThatGeometry { get; }

        public RegionToRegionRelation(Region thisGeometry, Region thatGeometry)
        {
            ThisGeometry = thisGeometry;
            ThatGeometry = thatGeometry;
        }
    }
}
