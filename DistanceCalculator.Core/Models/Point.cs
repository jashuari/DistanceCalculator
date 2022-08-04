namespace DistanceCalculator.Core.Models
{
    public struct Point
    {
        public double Latitude { get; private set; }

        public double Longitude { get; private set; }

        public Point(double lati­tude, double longi­tude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

    }
}
