namespace BankingApp.Application.Response
{
    public class AuthenticateResponse
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }

        public AuthenticateResponse(string username, string token, string refreshToken)
        {
            Username = username;
            Token = token;
            RefreshToken = refreshToken;
        }
    }

    public class RefreshTokenRequest
    {
        public string Token { get; set; }
    }

    public class RevokeTokenRequest
    {
        public string Token { get; set; }
    }
}
