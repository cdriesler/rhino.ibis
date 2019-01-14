using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Ibis.Relations;
using Rhino.Geometry;
using Rhino.Geometry.Intersect;

namespace Rhino.Ibis.Reviews.Curves
{
    public static partial class CurvesReviewMethods
    {
        public static void GroupsByColinearity(CurvesRelation source)
        {
            //Initialize collections.
            var groupsByColinearity = new List<List<Curve>>(source.Geometry.Count);
            var groupsByColinearityIndexMap = new List<int>(source.Geometry.Count);

            //Extend each curve (linear only) an arbitrarily large dimension.
            var extendedCurves = source.Geometry.Where(x => x.Degree == 1).Select(x => x.Extend(CurveEnd.Both, 10000, CurveExtensionStyle.Line)).ToList();

            //TODO: The following sorting is split into two phases for clarity of thought but can be collapsed into one.

            //Check each curve for overlap with other curves.
            var overlapMatrix = new List<List<bool>>();

            for (int i = 0; i < extendedCurves.Count; i++)
            {
                var res = new List<bool>();

                //Because the matrix is guaranteed to be symmetrical, only check the bottom half.
                for (int j = 0; j < i; j++)
                {
                    var ccx = Intersection.CurveCurve(extendedCurves[i], extendedCurves[j], 0.1, 0.1);

                    res.Add(ccx.Any(x => x.IsOverlap));
                }

                overlapMatrix.Add(res);
            }

            //Group based on matrix
            for (int i = 0; i < source.Geometry.Count; i++)
            {
                //Search for and remove empty lists, if they exist.
                if (groupsByColinearity.Any(x => x.Count == 0))
                {
                    var listsToRemoveIndices = new List<int>();

                    for (int j = 0; j < groupsByColinearity.Count; j++)
                    {
                        if (groupsByColinearity[j].Count == 0)
                        {
                            listsToRemoveIndices.Add(j);
                        }
                    }

                    for (int j = listsToRemoveIndices.Count - 1; j >= 0; j--)
                    {
                        groupsByColinearity.RemoveAt(listsToRemoveIndices[j]);
                    }
                }

                if (overlapMatrix[i].Contains(true))
                {
                    //Check for one or multiple matches.
                    var trueCount = overlapMatrix[i].Count(x => x);

                    //Put curve into the first matching curve's list (refer to groupsByColinearityIndexMap)
                    var firstTrueIndex = overlapMatrix[i].IndexOf(true);
                    var targetIndex = groupsByColinearityIndexMap[firstTrueIndex];

                    groupsByColinearity[targetIndex].Add(source.Geometry[i]);
                    groupsByColinearityIndexMap.Add(targetIndex);

                    //If there were multiple matches...
                    if (trueCount > 1)
                    {
                        //...pull any other groups containing those matches.
                        for (int j = firstTrueIndex + 1; j < overlapMatrix[i].Count; j++)
                        {
                            if (overlapMatrix[i][j])
                            {
                                //Find position of current group by referring to groupsByColinearityIndexMap[j];
                                var groupToMoveIndex = groupsByColinearityIndexMap[j];

                                //Continue if groupsByColinearityIndexMap[j] == groupsByColinearityIndexMap[i] (Group was moved in an earlier loop.)
                                if (groupToMoveIndex == groupsByColinearityIndexMap[i]) continue;

                                //Move curves in that list to list at groupsByColinearityIndexMap[i] with AddRange;
                                groupsByColinearity[groupsByColinearityIndexMap[i]].AddRange(groupsByColinearity[groupsByColinearityIndexMap[j]]);

                                //Clear list at position groupsByColinearityIndexMap[j];
                                groupsByColinearity[groupsByColinearityIndexMap[j]].Clear();

                                //In groupsByColinearityIndexMap, replace any existing instance of value groupsByColinearityIndexMap[j] with groupsByColinearityIndexMap[i];
                                for (int k = 0; k < groupsByColinearityIndexMap.Count; k++)
                                {
                                    if (groupsByColinearityIndexMap[k] == groupsByColinearityIndexMap[j])
                                    {
                                        groupsByColinearityIndexMap[k] = groupsByColinearityIndexMap[i];
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    //Make new group for this curve.
                    groupsByColinearity.Add(new List<Curve> { source.Geometry[i] });

                    //Note its placement.
                    groupsByColinearityIndexMap.Add(groupsByColinearity.Count - 1);
                }
            }

            source.Properties.GroupsByColinearity = groupsByColinearity;
            source.Properties.GroupsByColinearityIndexMap = groupsByColinearityIndexMap;
        }
    }
}
