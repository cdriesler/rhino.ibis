
using System;
using System.Collections.Generic;
using Rhino.Geometry;
using Rhino.Ibis.Logic.Region;

//NOTE: This class is automatically generated. Any manual edits will be overwritten.

namespace Rhino.Ibis.TextTemplateTest
{
	public class RegionRelation
	{
		//Related geometry
		private Region ThisGeometry { get; }
		
		//Constructor
		public RegionRelation(Region Region)
		{
			ThisGeometry = Region;
		}
				
		//H(and)shake class and method
		public RegionRelationHandshake And()
		{
			return new RegionRelationHandshake(ThisGeometry);
		}

		public class RegionRelationHandshake
		{
			private Region Staged { get; }

			public RegionRelationHandshake(Region staged) 
			{
				Staged = staged;
			}
		}
		
		//Generic get class and method
		public RegionRelationProperties Get()
		{
			return new RegionRelationProperties(ThisGeometry );
		}

		public class RegionRelationProperties
		{
			//Geometry getters
			public Region ThisGeometry { get; }
			
			//Single property getters

			//Constructor
			public RegionRelationProperties(Region thisGeo )
			{
				ThisGeometry = thisGeo;
							}
		}

		
					
	}

}

