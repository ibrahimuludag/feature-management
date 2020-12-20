using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.FeatureManagement.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeatureApp.Handlers
{
    public class DisabledFeaturesHandler : IDisabledFeaturesHandler
    {
        public Task HandleDisabledFeatures(IEnumerable<string> features, ActionExecutingContext context)
        {
            context.Result = new ContentResult
            {
                Content = $"This feature is not available at this time",
                ContentType = "text/plain",
                StatusCode = 404
            };

            return Task.CompletedTask;
        }
    }
}
