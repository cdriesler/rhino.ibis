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
        #region Curves

        public static CurvesRelation CrossingCurves()
        {
            var env = new List<Curve>
            {
                new LineCurve(new Point3d(-2, 0, 0), new Point3d(0, 2, 0)),
                new LineCurve(new Point3d(0, -2, 0), new Point3d(0, 2, 0))
            };

            return Relate.This(env);
        }

        public static CurvesRelation CrossingDashedCurves()
        {
            var env = new List<Curve>
            {
                new LineCurve(new Point3d(-2, 0, 0), new Point3d(-1, 0, 0)),
                new LineCurve(new Point3d(1, 0, 0), new Point3d(2, 0, 0)),
                new LineCurve(new Point3d(0, -2, 0), new Point3d(0, -1, 0)),
                new LineCurve(new Point3d(0, 1, 0), new Point3d(0, 2, 0))
            };

            return Relate.This(env);
        }

        public static CurvesRelation HorizontalDashedLine()
        {
            var env = new List<Curve>
            {
                new LineCurve(new Point3d(0, 0, 0), new Point3d(1, 0, 0)),
                new LineCurve(new Point3d(2, 0, 0), new Point3d(3, 0, 0)),
                new LineCurve(new Point3d(4, 0, 0), new Point3d(5, 0, 0))
            };

            return Relate.This(env);
        }

        public static CurvesRelation ParallelOffsetCurves()
        {
            var env = new List<Curve>
            {
                new LineCurve(new Point3d(0, 0, 0), new Point3d(0, 1, 0)),
                new LineCurve(new Point3d(2, 0, 0), new Point3d(2, 1, 0))
            };

            return Relate.This(env);
        }

        public static CurvesRelation ParallelOffsetCurvesOneDashed()
        {
            var env = new List<Curve>
            {
                new LineCurve(new Point3d(0, 0, 0), new Point3d(0, 1, 0)),
                new LineCurve(new Point3d(0, 2, 0), new Point3d(0, 3, 0)),
                new LineCurve(new Point3d(2, 0, 0), new Point3d(2, 1, 0))
            };

            return Relate.This(env);
        }

        public static CurvesRelation Pinwheel()
        {
            var env = new List<Curve>
            {
                new LineCurve(Point3d.Origin, new Point3d(0, 1, 0)),
                new LineCurve(Point3d.Origin, new Point3d(1, 1, 0)),
                new LineCurve(Point3d.Origin, new Point3d(1, 0, 0)),
                new LineCurve(Point3d.Origin, new Point3d(1, -1, 0)),
                new LineCurve(Point3d.Origin, new Point3d(0, -1, 0)),
                new LineCurve(Point3d.Origin, new Point3d(-1, -1, 0)),
                new LineCurve(Point3d.Origin, new Point3d(-1, 0, 0)),
                new LineCurve(Point3d.Origin, new Point3d(-1, 1, 0))
            };

            return Relate.This(env);
        }

        public static CurvesRelation PairedPinwheel()
        {
            var env = new List<Curve>
            {
                new LineCurve(Point3d.Origin, new Point3d(0, 1, 0)),
                new LineCurve(Point3d.Origin, new Point3d(1, 1, 0)),
                new LineCurve(Point3d.Origin, new Point3d(1, 0, 0)),
                new LineCurve(Point3d.Origin, new Point3d(1, -1, 0)),
                new LineCurve(Point3d.Origin, new Point3d(0, -1, 0)),
                new LineCurve(Point3d.Origin, new Point3d(-1, -1, 0)),
                new LineCurve(Point3d.Origin, new Point3d(-1, 0, 0)),
                new LineCurve(Point3d.Origin, new Point3d(-1, 1, 0))
            };

            var envB = new List<Curve>
            {
                new LineCurve(Point3d.Origin, new Point3d(0, 1, 0)),
                new LineCurve(Point3d.Origin, new Point3d(1, 1, 0)),
                new LineCurve(Point3d.Origin, new Point3d(1, 0, 0)),
                new LineCurve(Point3d.Origin, new Point3d(1, -1, 0)),
                new LineCurve(Point3d.Origin, new Point3d(0, -1, 0)),
                new LineCurve(Point3d.Origin, new Point3d(-1, -1, 0)),
                new LineCurve(Point3d.Origin, new Point3d(-1, 0, 0)),
                new LineCurve(Point3d.Origin, new Point3d(-1, 1, 0))
            };

            env.AddRange(envB);

            return Relate.This(env);
        }

        public static CurvesRelation ShuffledPinwheel()
        {
            var env = Pinwheel().GeometryA;
            var rng = new Random();

            int n = env.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var val = env[k];
                env[k] = env[n];
                env[n] = val;
            }

            return Relate.This(env);
        }

        public static CurvesRelation ShuffledPairedPinwheel()
        {
            var env = PairedPinwheel().GeometryA;
            var rng = new Random();

            int n = env.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var val = env[k];
                env[k] = env[n];
                env[n] = val;
            }

            return Relate.This(env);
        }

        #endregion

        #region CurveToCurve

        public static CurveToCurveRelation CenteredVertical_CenteredHorizontal()
        {
            var geoA = new LineCurve(new Point3d(0, -1, 0), new Point3d(0, 1, 0)).ToNurbsCurve();
            var geoB = new LineCurve(new Point3d(-1, 0, 0), new Point3d(1, 0, 0)).ToNurbsCurve();

            return Relate.This(geoA).To(geoB);
        }

        #endregion
    }
}
