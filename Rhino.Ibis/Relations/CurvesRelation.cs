
using System;
using System.Collections.Generic;
using Rhino.Geometry;
using Rhino.Ibis.Logic.Curves;

//NOTE: This class is automatically generated. Any manual edits will be overwritten.

namespace Rhino.Ibis.Relations
{
	public class CurvesRelation
	{
		//Related geometry
		private List<Curve> ThisGeometry { get; }
		
		//Constructor
		public CurvesRelation(List<Curve> Curves)
		{
			ThisGeometry = Curves;
		}
				
		//H(and)shake class and method
		public CurvesRelationHandshake And()
		{
			return new CurvesRelationHandshake(ThisGeometry);
		}

		public class CurvesRelationHandshake
		{
			private List<Curve> Staged { get; }

			public CurvesRelationHandshake(List<Curve> staged) 
			{
				Staged = staged;
			}
		}
		
		//Generic get class and method
		public CurvesRelationProperties Get()
		{
			return new CurvesRelationProperties(ThisGeometry );
		}

		public class CurvesRelationProperties
		{
			//Geometry getters
			public List<Curve> ThisGeometry { get; }
			
			//Single property getters
			public Curve LongestCurve => CurvesLogic.LocateLongestCurve(ThisGeometry );
			public Curve SortestCurve => CurvesLogic.LocateSortestCurve(ThisGeometry );
			
			//Constructor
			public CurvesRelationProperties(List<Curve> thisGeo )
			{
				ThisGeometry = thisGeo;
							}
		}
		
		//Public methods
		public CurvesRelation LocateLongestCurve(out Curve longestcurve)
		{
			longestcurve = CurvesLogic.LocateLongestCurve(ThisGeometry );
			return this;
		}
		public CurvesRelation LocateSortestCurve(out Curve sortestcurve)
		{
			sortestcurve = CurvesLogic.LocateSortestCurve(ThisGeometry );
			return this;
		}
			}
}

