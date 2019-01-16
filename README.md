# Rhino.Ibis

[![Build status](https://dev.azure.com/ourchitecture/rhino.ibis/_apis/build/status/rhino.ibis_syntax)](https://dev.azure.com/ourchitecture/rhino.ibis/_build/latest?definitionId=2) [![NuGet Version](https://img.shields.io/myget/rhino-ibis/v/rhino.ibis.svg?label=NuGet)](https://myget.org/feed/rhino-ibis/package/nuget/Rhino.Ibis)

The Ibis rests on top of the Rhino and just makes things a little better with its existence. 

The Ibis library packages relational geometric logic and exposes it using a common "fluent" syntax. Take the following example:

**Note:** The following syntax is still in flux and subject to change any time before v1.X comes out.

```csharp

//Normal syntax
var segments = GetSegmentsInsideRegion(region, curve);  

//Ibis fluent syntax
Given.This(region).And().That(curve).Get().SegmentsInsideRegion;

```

Ibis prioritizes code legibility and precision of intent. Still, that's only preference. And in this example, the Ibis implementation is longer! The second strength of Ibis, though, is the ability to chain methods. Complexity can be increased without sacrificing legibility.

```csharp

Given.These(curves)
	.LocateLongestCurve(out var crv)
	.AssessAverageCurveLength(out var length)
	.And().Those(points)
	.VerifyThoseOutnumberThis(out var isMorePoints)
	.CreateCirclesCenteredOnPoints(length, out var circles)
	.LocatePointsOnCurves(out var pts)

```

Some methods, like `LocatePointsOnCurves()`, perform an operation using the related geometry. Others, like `CreateCircles()`, have arguments that can come from earlier relations.

This library came together because of a problem in my own workflow. "Why am I rewriting similar geometric methods all the time?" constantly followed up later by "What does this method even do? I need to write one that works for this case." Thoughts about a standard naming convention (that some future person probably wouldn't think makes sense) evolved into thoughts about merging it with the logic.

The project is structured with collaboration in mind. Notes on where to put logic will be ready soon, hopefully.




