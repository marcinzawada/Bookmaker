namespace Application.Commands.Account
{
    public class AuthDto
    {
        public int Id { get; init; }

        public string Token { get; init; }

        public string UserName { get; init; }

        public decimal GameTokens { get; init; }
    }
}
