using Application.Commands.Account;
using Application.Commands.Account.Login;
using Application.Models;
using FluentAssertions;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;


namespace IntegrationTests
{
    public class AccountControllerTests : BaseIntegrationTest
    {
        [Fact]
        public async Task Login_WithCorrectCredentials_ShouldReturnOkStatus()
        {
            //Arrange

            //Act
            var response = await _testClient.PostAsJsonAsync("/api/account/login",
                new LoginCommand("test@gmail.com", "Pass123!"));


            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var result = await response.Content.ReadFromJsonAsync<Result<AuthDto>>();
            result!.Content.Id.Should().BeGreaterOrEqualTo(1);
            result.Content.Token.Should().NotBeEmpty();
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("test@gmail.com", "")]
        [InlineData("test@gmail.com", "invalidPassword")]
        [InlineData("thisEmailDoesntExist@gmail.com", "password")]
        public async Task Login_WithIncorrectCredentials_ShouldReturnBadRequest(string email, string password)
        {
            //Arrange

            //Act
            var response = await _testClient.PostAsJsonAsync("/api/account/login",
                new LoginCommand(email, password));


            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
