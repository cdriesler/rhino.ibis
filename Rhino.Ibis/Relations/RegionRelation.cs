using System;
using System.Collections.Generic;
using System.Text;
using Rhino.Geometry;
using Rhino.Ibis.Logic.Region;

namespace Rhino.Ibis.Relations
{
    public class RegionRelation
    {
        public Region ThisGeometry { get; }

        private bool HasFourEqualSides { get; set; }

        public RegionRelation(Region thisGeometry)
        {
            ThisGeometry = thisGeometry;
        }

        public RegionRelationHandshake And()
        {
            return new RegionRelationHandshake(ThisGeometry);
        }

        public class RegionRelationHandshake
        {
            private Region StagedRegion { get; }

            public RegionRelationHandshake(Region staged)
            {
                StagedRegion = staged;
            }

            public RegionToRegionRelation That(Region thatGeometry)
            {
                return new RegionToRegionRelation(StagedRegion, thatGeometry);
            }
        }

        public void VerifyThisHasFourEqualSides(out bool hasFourEqualSides)
        {
            HasFourEqualSides = RegionLogic.VerifyThisHasFourEqualSides(this);
            hasFourEqualSides = HasFourEqualSides;
        }      
    }
}
