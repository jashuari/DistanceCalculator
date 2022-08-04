using DistanceCalculator.WebAPI.Contracts;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DistanceCalculator.Core.IntegrationTests
{
    public class DistanceCalculatorControllerTest : IntegrationTest
    {
        [Fact]
        public async Task Post_ReturnsDistance_UsingPythagoreanCalculator()
        {
            // Arrange
            var distanceRequest = new GetDistanceRequestDTO() { PointA = new PointDTO(), PointB = new PointDTO() };
             
            distanceRequest.PointA.Latitude = 1;
            distanceRequest.PointA.Longitude = 5;

            distanceRequest.PointB.Latitude = 1;
            distanceRequest.PointB.Longitude = 9;

            // Act
            var response = await TestClient.PostAsync("/DistanceCalculator?calculationType=1",
                new StringContent(JsonConvert.SerializeObject(distanceRequest)
                ,Encoding.UTF8, "application/json"));

            // Assert 
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.IsSuccessStatusCode.Should().BeTrue();
            response.Content.Should().NotBeNull();
        }

        [Fact]
        public async Task Post_ReturnsDistance_UsingCosinesLawCalculator()
        {
            // Arrange
            var distanceRequest = new GetDistanceRequestDTO() { PointA = new PointDTO(), PointB = new PointDTO() };

            distanceRequest.PointA.Latitude = 38.8976;
            distanceRequest.PointA.Longitude = -77.0366;

            distanceRequest.PointB.Latitude = 39.9496;
            distanceRequest.PointB.Longitude = -75.1503;

            // Act
            var response = await TestClient.PostAsync("/DistanceCalculator?calculationType=0",
                new StringContent(JsonConvert.SerializeObject(distanceRequest)
                , Encoding.UTF8, "application/json"));

            // Assert 
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.IsSuccessStatusCode.Should().BeTrue();
            response.Content.Should().NotBeNull();
        }
    }
}
