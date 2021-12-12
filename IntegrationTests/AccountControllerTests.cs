using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Application.Commands.Account.Login;
using Application.Commands.Account.Register;
using Application.Models;
using Xunit;
using FluentAssertions;


namespace IntegrationTests
{
    public class AccountControllerTests : BaseIntegrationTest
    {
        [Fact]
        public async Task Register_WithCorrectData_ShouldReturnOkStatus()
        {
            //Arrange

            //Act
            var response = await _testClient.PostAsJsonAsync("/api/account/register",
                new RegisterCommand(
                _faker.Internet.Email(),
                "TestUser",
                "Pass123!",
                "Pass123!"));



            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        public static IEnumerable<object[]> IncorrectRegisterData =>
            new List<object[]>
            {
                new object[] { "test@gmail.com", _faker.Person.UserName, "Pass123!", "Pass123!" },
                new object[] { "", _faker.Person.UserName, "Pass123!", "Pass123!" },
                new object[] { "test", _faker.Person.UserName, "Pass123!", "Pass123!" },
                new object[] { _faker.Internet.Email(), "" , "Pass123!", "Pass123!" },
                new object[] { _faker.Internet.Email(), _faker.Person.UserName, "", "Pass123!" },
                new object[] { _faker.Internet.Email(), _faker.Person.UserName, "Pass123", "Pass123" },
                new object[] { _faker.Internet.Email(), _faker.Person.UserName, "Pa1!", "Pa1!" },
                new object[] { _faker.Internet.Email(), _faker.Person.UserName, "pass123!", "pass123!" },
                new object[] { _faker.Internet.Email(), _faker.Person.UserName, "password!", "password!" },
                new object[] { _faker.Internet.Email(), _faker.Person.UserName, "password123", "password123" },
                new object[] { _faker.Internet.Email(), _faker.Person.UserName, "PASSWORD123!", "PASSWORD123!" },
                new object[] { _faker.Internet.Email(), _faker.Person.UserName, "Pass 123!", "Pass 123!" },
                new object[] { _faker.Internet.Email(), _faker.Person.UserName, "Pass#123!", "Pass#123!" },
                new object[] { _faker.Internet.Email(), "username", "Pass#123!", "Pass#123!" },
                new object[] { _faker.Internet.Email(), "a", "Pass123!", "Pass123!" },
                new object[] { _faker.Internet.Email(), "tooooooooooooooooooo long username", "Pass123!", "Pass123!" },
            };

        [Theory]
        [MemberData(nameof(IncorrectRegisterData))]
        public async Task Register_WithIncorrectData_ShouldReturnBadRequest(string email, string name, string password, string confirmPassword)
        {
            //Arrange

            //Act
            var response = await _testClient.PostAsJsonAsync("/api/account/register",
                new RegisterCommand(email, name, password, confirmPassword));

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        }

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
