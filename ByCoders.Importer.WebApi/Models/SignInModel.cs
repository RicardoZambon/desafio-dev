namespace ByCoders.Importer.WebApi.Models
{
    /// <summary>
    /// Model of values used to authenticate and generate a new user JWT token and Refresh Token.
    /// </summary>
    public class SignInModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}