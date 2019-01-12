using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;
using Rhino.Ibis.Relations;

namespace Rhino.Ibis.Test
{
    public static class TestEnvironments
    {
        #region CurveToCurve

        public static CurveToCurveRelation CenteredVertical_CenteredHorizontal()
        {
            var geoA = new LineCurve(new Point3d(0, -1, 0), new Point3d(0, 1, 0)).ToNurbsCurve();
            var geoB = new LineCurve(new Point3d(-1, 0, 0), new Point3d(1, 0, 0)).ToNurbsCurve();

            return Relate.This(geoA).To(geoB);
        }

        #endregion
    }

    public class TestEnvironment
    {
        public List<GeometryBase> GeometryA { get; set; }
        public List<GeometryBase> GeometryB { get; set; }

        public object Options { get; set; }

        public TestEnvironment(GeometryBase geoA, GeometryBase geoB)
        {
            GeometryA = new List<GeometryBase> { geoA };
            GeometryB = new List<GeometryBase> { geoB };
        }
    }
}
