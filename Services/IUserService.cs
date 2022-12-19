namespace PaymentsAPI.Services
{
    public interface IUserService
    {
        string GetToken(string username, string password, string role);
    }
}
