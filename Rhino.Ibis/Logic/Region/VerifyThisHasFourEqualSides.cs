using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rhino.Geometry;
using Rhino.Ibis.Relations;

namespace Rhino.Ibis.Logic.Region
{
    public static partial class RegionLogic
    {
        public static bool VerifyThisHasFourEqualSides(RegionRelation rel)
        {
            var spans = new List<Curve>();
            var tList = new List<double>();

            var crv = rel.ThisGeometry.Curve.DuplicateCurve();

            for (int i = 0; i < crv.SpanCount; i++)
            {
                tList.Add(crv.SpanDomain(i).Max);
            }

            spans = crv.Split(tList).ToList();

            if (spans.Count != 4) return false;

            for (int i = 1; i < spans.Count; i++)
            {
                if (spans[i].GetLength() != spans[i - 1].GetLength()) return false;
            }

            return true;
        }
    }
}
