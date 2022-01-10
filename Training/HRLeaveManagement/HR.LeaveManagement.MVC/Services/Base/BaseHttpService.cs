using System.Net.Http.Headers;
using HR.LeaveManagement.MVC.Contracts;

namespace HR.LeaveManagement.MVC.Services.Base;

public class BaseHttpService
{
    protected readonly ILocalStorageService LocalStorage;
    protected IClient Client;

    public BaseHttpService(IClient client, ILocalStorageService localStorage)
    {
        Client = client;
        LocalStorage = localStorage;
    }

    protected Response<Guid> ConvertApiExceptions<Guid>(ApiException ex)
    {
        if (ex.StatusCode == 400)
        {
            return new Response<Guid>() { Message = "Validation errors have occurred.", ValidationErrors = ex.Response, Success = false };
        }
        else if (ex.StatusCode == 404)
        {
            return new Response<Guid>() { Message = "The requested item could not be found.", Success = false };
        }
        else
        {
            return new Response<Guid>() { Message = "Something went wrong, please try again.", Success = false };
        }
    }

    protected void AddBearerToken()
    {
        if (LocalStorage.Exists("token"))
            Client.HttpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", LocalStorage.GetStorageValue<string>("token"));
    }
}