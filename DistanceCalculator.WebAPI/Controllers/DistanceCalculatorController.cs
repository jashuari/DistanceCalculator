using DistanceCalculator.WebAPI.Contracts;
using DistanceCalculator.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;

namespace DistanceCalculator.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DistanceCalculatorController : Controller
    {
        private readonly IDistanceCalculationService distanceCalculationService;
        private readonly ILogger<DistanceCalculatorController> _logger;

        public DistanceCalculatorController(IDistanceCalculationService distanceCalculationService, ILoggerFactory loggerFactory)
        {
            this.distanceCalculationService = distanceCalculationService;
            _logger = loggerFactory.CreateLogger<DistanceCalculatorController>();

        }

        /// <summary>
        /// Returns distance between two points in meters
        /// </summary>
        /// <param name="dto">Request dto</param>
        /// <param name="calculationType">Calculation type</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CalculateDistance(GetDistanceRequestDTO dto, CalculationType calculationType)
        {
            try
            {
                _logger.LogInformation($"Calculating Distance between {dto.PointA.Latitude}, {dto.PointA.Longitude} and {dto.PointB.Latitude}, {dto.PointB.Longitude}");
                
                var distance = distanceCalculationService.CalculateDistance(dto, calculationType);

                if (CalculationType.Pythagorean == calculationType) return Ok(distance);

                var culture = GetCulture();
                var measureUnit = GetMeasuringUnitEnum(culture);

                return Json(new { TheDistanceIs = TransformDistance(distance) + " " + measureUnit });

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong calculating Distance: {ex}");
            }
            return BadRequest();
        }

        private static double TransformDistance(double distance)
        {
            try
            {
                double res;
                switch (CultureInfo.CurrentCulture.Name)
                {
                    case "en-US":
                        res = distance * 0.0006213712;
                        break;
                    case "uk-UA":
                        res = distance * 0.001;
                        break;
                    default:
                        res = distance;
                        break;
                }
                return Math.Round(res, 3);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Something went wrong TransformDistance: {ex}");
            }
        }

        private static MeasureUnits GetMeasuringUnitEnum(string measuringUnit) => (MeasureUnits)Enum.Parse(typeof(MeasureUnits), measuringUnit);
        private static string GetCulture()
        {
            return CultureInfo.CurrentCulture.Name == "en-US" ? "1" : "0";
        }
    }
}
