using Microsoft.FeatureManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeatureApp.FeatureFilters
{
    [FilterAlias("FeatureApp.RandomFilter")]
    public class RandomFilter : IFeatureFilter
    {
        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context) => Task.FromResult(DateTime.UtcNow.Second % 2 == 0);
    }
}
