﻿using AutoMapper;
using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Models;
using HR.LeaveManagement.MVC.Services.Base;

namespace HR.LeaveManagement.MVC.Services;

public class LeaveTypeService : BaseHttpService, ILeaveTypeService
{
    private readonly ILocalStorageService _localStorageService;
    private readonly IMapper _mapper;
    private readonly IClient _client;

    public LeaveTypeService(IMapper mapper, IClient client, ILocalStorageService localStorageService) : base(client, localStorageService)
    {
        _mapper = mapper;
        _client = client;
        _localStorageService = localStorageService;
    }

    public async Task<List<LeaveTypeVM>> GetLeaveTypes()
    {
        AddBearerToken();
        var leaveTypes = await _client.LeaveTypesAllAsync();
        return _mapper.Map<List<LeaveTypeVM>>(leaveTypes);
    }

    public async Task<LeaveTypeVM> GetLeaveTypeDetails(int id)
    {
        AddBearerToken();
        var leaveTypes = await _client.LeaveTypesGETAsync(id);
        return _mapper.Map<LeaveTypeVM>(leaveTypes);
    }

    public async Task<Response<int>> CreateLeaveType(CreateLeaveTypeVM leaveType)
    {
        try
        {
            var response = new Response<int>();
            var createLeaveType = _mapper.Map<CreateLeaveTypeDto>(leaveType);
            AddBearerToken();
            var apiResponse = await _client.LeaveTypesPOSTAsync(createLeaveType);
            if (apiResponse.Success)
            {
                response.Data = apiResponse.Id;
                response.Success = true;
            }
            else
            {
                if (apiResponse.Errors != null)
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

    public async Task<Response<int>> UpdateLeaveType(int id, LeaveTypeVM leaveType)
    {
        try
        {
            var updateLeaveType = _mapper.Map<LeaveTypeDto>(leaveType);
            AddBearerToken();
            await _client.LeaveTypesPUTAsync(id, updateLeaveType);
            return new Response<int>() {Success = true};
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<int>(ex);
        }
    }

    public async Task<Response<int>> DeleteLeaveType(int id)
    {
        try
        {
            AddBearerToken();
            await _client.LeaveTypesDELETEAsync(id);
            return new Response<int>() { Success = true, Data = id, Message = "", ValidationErrors = ""}; ;
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<int>(ex);
        }
    }
}