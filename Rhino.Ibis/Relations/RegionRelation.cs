using System;
using System.Collections.Generic;
using System.Text;
using Rhino.Geometry;
using Rhino.Ibis.Logic.Region;

namespace Rhino.Ibis.Relations
{
    public class RegionRelation
    {
        //Related geometry
        private Region ThisGeometry { get; }

        //Constructor
        public RegionRelation(Region thisRegion)
        {
            ThisGeometry = thisRegion;
        }

        //H(and)shake class and method
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

        //Generic get class and method
        public RegionRelationProperties Get()
        {
            return new RegionRelationProperties(ThisGeometry);
        }

        public class RegionRelationProperties
        {
            //Geometry getters
            public Region ThisRegion { get; }

            //Single property getters
            public bool ThisHasFourEqualSides => RegionLogic.VerifyThisHasFourEqualSides(ThisRegion);

            //Constructor
            public RegionRelationProperties(Region region)
            {
                ThisRegion = region;
            }
        }

        //Public methods
        public RegionRelation VerifyThisHasFourEqualSides(out bool thisHasFourEqualSides)
        {
            thisHasFourEqualSides = RegionLogic.VerifyThisHasFourEqualSides(ThisGeometry);
            return this;
        }      
    }
}
