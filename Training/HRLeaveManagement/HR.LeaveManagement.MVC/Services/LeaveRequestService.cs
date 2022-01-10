using AutoMapper;
using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Models;
using HR.LeaveManagement.MVC.Services.Base;

namespace HR.LeaveManagement.MVC.Services;

public class LeaveRequestService : BaseHttpService, ILeaveRequestService
{
    private readonly ILocalStorageService _localStorageService;
    private readonly IMapper _mapper;
    private readonly IClient _client;

    public LeaveRequestService(IMapper mapper, IClient client, ILocalStorageService localStorageService) : base(client, localStorageService)
    {
        _mapper = mapper;
        _client = client;
        _localStorageService = localStorageService;
    }

    public async Task<Response<int>> CreateLeaveRequest(CreateLeaveRequestVM leaveRequest)
    {
        try
        {
            var response = new Response<int>();
            var createLeaveRequest = _mapper.Map<CreateLeaveRequestDto>(leaveRequest);
            AddBearerToken();
            var apiResponse = await _client.LeaveRequestPOSTAsync(createLeaveRequest);
            if (apiResponse.Success)
            {
                response.Data = apiResponse.Id;
                response.Success = true;
            }
            else
            {
                if (apiResponse.Errors == null) return response;
                foreach (var error in apiResponse.Errors)
                {
                    response.ValidationErrors += error + Environment.NewLine;
                }
            }

            return response;
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<int>(ex);
        }
    }

    public async Task<LeaveRequestVM> GetLeaveRequest(int id)
    {
        AddBearerToken();
        var leaveRequest = await _client.LeaveRequestGETAsync(id);
        return _mapper.Map<LeaveRequestVM>(leaveRequest);
    }

    public Task DeleteLeaveRequest(int id)
    {
        throw new NotImplementedException();
    }

    public async Task ApproveLeaveRequest(int id, bool approved)
    {
        AddBearerToken();
        try
        {
            var request = new ChangeLeaveRequestApprovalDto{ Approved = approved, Id = id };
            await _client.ChangeapprovalAsync(id, request);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}