using System.ComponentModel.DataAnnotations;

namespace DistanceCalculator.WebAPI.Contracts
{
    public class GetDistanceRequestDTO
    {
        [Required]
        public PointDTO PointA { get; set; }

        [Required]
        public PointDTO PointB { get; set; }
    }
}
