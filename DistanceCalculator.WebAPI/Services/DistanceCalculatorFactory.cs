using DistanceCalculator.Core.Calculators;
using DistanceCalculator.Core.Calculators.Abstract;
using DistanceCalculator.WebAPI.Contracts;
using DistanceCalculator.WebAPI.Services.Interfaces;

namespace DistanceCalculator.WebAPI.Services
{
    public class DistanceCalculatorFactory : IDistanceCalculatorFactory
    {
        public CalculatorBase GetCalculator(CalculationType calculationType)
        {
            switch (calculationType)
            {
                case CalculationType.CosinesLaw:
                    return new CosinesLawCalculator();
                case CalculationType.Pythagorean:
                    return new PythagoreanCalculator();
                default:
                    return new CosinesLawCalculator();
            }
        }
    }
}
