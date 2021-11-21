using FluentAssertions;
using Microsoft.AspNetCore.Http;
using PreludeRest;
using Xunit;

namespace Outcomes
{
    public class ErrorResultSpecs
    {
        static readonly ErrorResult _sut = new ErrorResult {
                Title = "Internal server error",
                Status = StatusCodes.Status500InternalServerError,
                Instance = "/specs/xGheb4EyhD",
            };
        static readonly string _expcted =
            "{\"type\":\"about:blank\",\"title\":\"Internal server error\",\"status\":500,\"detail\":null,\"instance\":\"/specs/xGheb4EyhD\"}";

        [Fact]
        public void Should_be_serialized_correctly_with_Newtonsoft_Json()
        {
            var outcome = Newtonsoft.Json.JsonConvert.SerializeObject(_sut);
            
            outcome.Should().Be(_expcted);
        }

        [Fact]
        public void Should_be_serialized_correctly_with_System_Text_Json()
        {
            var ooutcome = System.Text.Json.JsonSerializer.Serialize(_sut);

            ooutcome.Should().Be(_expcted);
        }
    }
}
