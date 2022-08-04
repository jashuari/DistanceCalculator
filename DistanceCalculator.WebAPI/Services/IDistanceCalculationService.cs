using DistanceCalculator.Core.Models;
using DistanceCalculator.WebAPI.Contracts;
using DistanceCalculator.WebAPI.Services.Interfaces;

namespace DistanceCalculator.WebAPI.Services
{
    public class DistanceCalculationService : IDistanceCalculationService
    {
        private readonly IDistanceCalculatorFactory distanceCalculatorFactory;

        public DistanceCalculationService(IDistanceCalculatorFactory distanceCalculatorFactory)
        {
            this.distanceCalculatorFactory = distanceCalculatorFactory;
        }
        public double CalculateDistance(GetDistanceRequestDTO requestDTO, CalculationType calculationType)
        {
            var distanceCalculator = distanceCalculatorFactory.GetCalculator(calculationType);

            var distance = distanceCalculator.GetDistance(
                new Point(requestDTO.PointA.Latitude, requestDTO.PointA.Longitude),
                new Point(requestDTO.PointB.Latitude, requestDTO.PointB.Longitude));

            return distance;
        }
    }
}
