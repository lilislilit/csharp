﻿using Generators.Input;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Generators.Exercises
{
    public class WordCount : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.UseVariableForExpected = true;
                canonicalDataCase.UseVariableForTested = true;
                canonicalDataCase.Expected = ((JObject)canonicalDataCase.Expected).ToObject<Dictionary<string, int>>();
            }
        }

        protected override HashSet<string> AddAdditionalNamespaces()
        {
            return new HashSet<string>()
            {
                typeof(Dictionary<string, int>).Namespace
            };
        }
    }
}
