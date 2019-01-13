# Rhino.Ibis

The Ibis is a bird that like to rest on top of a Rhino. It just makes things a little better with its existence.

This library (**still very incomplete**) exposes and streamlines a collection of relational geometry methods under a common fluent syntax. I started this project to make my life easier. Take the following "fake" collection of methods I had in a project:

```csharp

bool VerifyCurveIsMostlyContained(Curve crv, Curve region) 

bool CurveIntersectsRegion(Curve crv, Curve region) 

bool CurveIsContainedByRegion(Curve crv, Curve region)

CurveContainmentPackage FindSegmentsByRegionIntersection(Curve crv, Curve region)

```

How am I supposed to know what "mostly contained" means at a glance? Or what it's testing? Will I know what a "CurveContainmentPackage" is in a month? (Answer: no, I didn't.)

Here is the same functionality with Ibis:

```csharp

Relate.This(crv).To(region)
	.Resolve()
	.IfIntersectionExists()
	.SegmentsInsideRegion()
	.Results()

```

Or, a little shorter, if I preconfigure a set of tests that I know will be run a lot:

```csharp

var opts = new CurveToRegionOptions() 
{
	DoIfIntersectionExists = true,
	DoSegmentsInsideRegion = true
}

Relate.This(crv).To(region).Review(opts)
Relate.This(otherCrv).To(otherRegion).Review(opts)

```

Hopefully in a few months I would still understand what's happening here.