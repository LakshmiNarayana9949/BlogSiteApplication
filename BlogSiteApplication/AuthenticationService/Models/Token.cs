namespace AuthenticationService.Models
{
    public class Token
    {
        public string RefreshToken { get; set; }
        public int UserId { get; set; }
        public int UserType { get; set; }
    }
}
