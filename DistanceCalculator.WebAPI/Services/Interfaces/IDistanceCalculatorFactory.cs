using DistanceCalculator.Core.Calculators.Abstract;
using DistanceCalculator.WebAPI.Contracts;

namespace DistanceCalculator.WebAPI.Services.Interfaces
{
    public interface IDistanceCalculatorFactory
    {
        CalculatorBase GetCalculator(CalculationType calculationType);
    }
}
