using DistanceCalculator.WebAPI.Contracts;

namespace DistanceCalculator.WebAPI.Services.Interfaces
{
    public interface IDistanceCalculationService
    {
        double CalculateDistance(GetDistanceRequestDTO requestDTO, CalculationType calculationType);
    }
}
