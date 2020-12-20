using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.FeatureManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeatureApp.FeatureFilters
{
    [FilterAlias("FeatureApp.FeatureCFilter")]
    public class FeatureCFilter : IFeatureFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public FeatureCFilter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context) {
            FeatureCFilterSettings settings = context.Parameters.Get<FeatureCFilterSettings>();

            if (_httpContextAccessor.HttpContext.User.IsInRole(settings.Group))
                return Task.FromResult(true);

            return Task.FromResult(false);
        }
    }
}
