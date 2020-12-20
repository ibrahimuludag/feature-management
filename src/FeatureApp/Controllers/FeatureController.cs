using FeatureApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FeatureApp.Controllers
{
    public class FeatureController : Controller
    {
        private readonly ILogger<FeatureController> _logger;
        private readonly IFeatureManager _featureManager;
        private readonly IFeatureManagerSnapshot _featureManagerSnapshot;

        public FeatureController(ILogger<FeatureController> logger, IFeatureManager featureManager, IFeatureManagerSnapshot featureManagerSnapshot)
        {
            _logger = logger;
            _featureManager = featureManager;
            _featureManagerSnapshot = featureManagerSnapshot;
        }

        public async Task<IActionResult> IndexAsync()
        {
            ViewBag.FeatureA = await _featureManager.IsEnabledAsync(nameof(FeatureFlags.FeatureA)) ? "Yes" : "No";
            return View();
        }

        public async Task<IActionResult> Inconsistency()
        {
            var currentFeatureValue = await _featureManager.IsEnabledAsync(nameof(FeatureFlags.FeatureA));
            ViewBag.FeatureA = currentFeatureValue ? "Yes" : "No";

            System.Threading.Thread.Sleep(10000);
            
            currentFeatureValue = await _featureManager.IsEnabledAsync(nameof(FeatureFlags.FeatureA));
            ViewBag.FeatureA += ", " + (currentFeatureValue ? "Yes" : "No");

            return View();
        }

        public async Task<IActionResult> Consistency()
        {
            var currentFeatureValue = await _featureManagerSnapshot.IsEnabledAsync(nameof(FeatureFlags.FeatureA));
            ViewBag.FeatureA = currentFeatureValue ? "Yes" : "No";

            System.Threading.Thread.Sleep(10000);

            currentFeatureValue = await _featureManagerSnapshot.IsEnabledAsync(nameof(FeatureFlags.FeatureA));
            ViewBag.FeatureA += ", " + (currentFeatureValue ? "Yes" : "No");

            return View();
        }

        [FeatureGate(FeatureFlags.FeatureA)]
        public IActionResult FeatureAPage()
        {
            ViewBag.Message = "Hello from FeatureA";
            return View();
        }

        public async Task<IActionResult> FeatureBAsync()
        {
            ViewBag.FeatureB = await _featureManager.IsEnabledAsync(nameof(FeatureFlags.FeatureB)) ? "Yes" : "No";
            return View();
        }
        public async Task<IActionResult> FeatureCAsync()
        {
            ViewBag.FeatureC = await _featureManager.IsEnabledAsync(nameof(FeatureFlags.FeatureC)) ? "Yes" : "No";
            return View();
        }

        public async Task<IActionResult> FeatureDAsync()
        {
            ViewBag.FeatureD = await _featureManager.IsEnabledAsync(nameof(FeatureFlags.FeatureD)) ? "Yes" : "No";
            return View();
        }

        public async Task<IActionResult> FeatureEAsync()
        {
            ViewBag.FeatureE = await _featureManager.IsEnabledAsync(nameof(FeatureFlags.FeatureE)) ? "Yes" : "No";
            return View();
        }
        public IActionResult FeatureF()
        {
            return View();
        }

        public IActionResult AzureAppConfiguration()
        {
            return View();
        }
    }
}