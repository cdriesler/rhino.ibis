using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;
using Rhino.Ibis.Relations;

namespace Rhino.Ibis.Test.Logic
{
    public static class TestEnvironments
    {
        //TODO: Refactor to only give geometry again.

        #region Curves

        public static CurvesRelation CrossingCurves()
        {
            var env = new List<Curve>
            {
                new LineCurve(new Point3d(-2, 0, 0), new Point3d(0, 2, 0)),
                new LineCurve(new Point3d(0, -2, 0), new Point3d(0, 2, 0))
            };

            return Given.These(env);
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

            return Given.These(env);
        }

        public static CurvesRelation HorizontalDashedLine()
        {
            var env = new List<Curve>
            {
                new LineCurve(new Point3d(0, 0, 0), new Point3d(1, 0, 0)),
                new LineCurve(new Point3d(2, 0, 0), new Point3d(3, 0, 0)),
                new LineCurve(new Point3d(4, 0, 0), new Point3d(5, 0, 0))
            };

            return Given.These(env);
        }

        public static CurvesRelation ParallelOffsetCurves()
        {
            var env = new List<Curve>
            {
                new LineCurve(new Point3d(0, 0, 0), new Point3d(0, 1, 0)),
                new LineCurve(new Point3d(2, 0, 0), new Point3d(2, 1, 0))
            };

            return Given.These(env);
        }

        public static CurvesRelation ParallelOffsetCurvesOneDashed()
        {
            var env = new List<Curve>
            {
                new LineCurve(new Point3d(0, 0, 0), new Point3d(0, 1, 0)),
                new LineCurve(new Point3d(0, 2, 0), new Point3d(0, 3, 0)),
                new LineCurve(new Point3d(2, 0, 0), new Point3d(2, 1, 0))
            };

            return Given.These(env);
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

            return Given.These(env);
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

            return Given.These(env);
        }

        public static CurvesRelation ShuffledPinwheel()
        {
            var env = Pinwheel().Get().ThisGeometry;
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

            return Given.These(env);
        }

        public static CurvesRelation ShuffledPairedPinwheel()
        {
            var env = PairedPinwheel().Get().ThisGeometry;
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

            return Given.These(env);
        }

        #endregion
    }
}
