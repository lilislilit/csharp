using System;
using Generators.Input;
using Generators.Output;
using Humanizer;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class PerfectNumbers : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.ExceptionThrown = canonicalDataCase.Expected is JObject ? typeof(ArgumentOutOfRangeException) : null;

                if (canonicalDataCase.Expected is string classificationType)
                    canonicalDataCase.Expected = new UnescapedValue($"Classification.{classificationType.Transform(To.SentenceCase)}");
            }
        }
    }
}