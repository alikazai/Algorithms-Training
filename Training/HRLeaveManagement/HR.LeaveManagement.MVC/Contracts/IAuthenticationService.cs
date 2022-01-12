namespace HR.LeaveManagement.MVC.Contracts;

public interface IAuthenticationService
{
    Task<bool> Authenticae(string email, string password);
    Task<bool> Register(string firstName, string lastName, string userName, string email, string password);
    Task Logout();
}