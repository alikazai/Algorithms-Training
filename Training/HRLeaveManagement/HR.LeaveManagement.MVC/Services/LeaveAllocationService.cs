using AutoMapper;
using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Models;
using HR.LeaveManagement.MVC.Services.Base;

namespace HR.LeaveManagement.MVC.Services;

public class LeaveAllocationService : BaseHttpService, ILeaveAllocationService
{
    private readonly ILocalStorageService _localStorageService;
    private readonly IMapper _mapper;
    private readonly IClient _client;

    public LeaveAllocationService(IMapper mapper, IClient client, ILocalStorageService localStorageService) : base(client, localStorageService)
    {
        _mapper = mapper;
        _client = client;
        _localStorageService = localStorageService;
    }

    public async Task<Response<int>> CreateLeaveAllocations(int leaveTypeId)
    {
        try
        {
            var response = new Response<int>();
            CreateLeaveAllocationDto createLeaveAllocation = new() {LeaveTypeId = leaveTypeId};
            AddBearerToken();
            var apiResponse = await _client.LeaveAllocationPOSTAsync(createLeaveAllocation);
            if (apiResponse.Success)
            {
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
}