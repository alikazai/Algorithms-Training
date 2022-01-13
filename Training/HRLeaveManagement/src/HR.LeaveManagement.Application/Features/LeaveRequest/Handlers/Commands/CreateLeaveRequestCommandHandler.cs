using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Infrastructure;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveRequest.Requests.Commands;
using HR.LeaveManagement.Application.Models;
using HR.LeaveManagement.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IEmailSender _emailSender;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper, ILeaveTypeRepository leaveTypeRepository, IEmailSender emailSender, IHttpContextAccessor httpContextAccessor)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _emailSender = emailSender;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);
            var validatorResult = await validator.ValidateAsync(request.LeaveRequestDto, cancellationToken);
            var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(q => q.Type == "uid")?.Value;

            if (validatorResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validatorResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var leaveRequest = _mapper.Map<Domain.LeaveRequest>(request.LeaveRequestDto);
                leaveRequest.RequestingEmployeeId = userId;
                leaveRequest = await _leaveRequestRepository.Add(leaveRequest);

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = leaveRequest.Id;
            }

            var emailAddress = _httpContextAccessor.HttpContext.User.FindFirst(JwtRegisteredClaimNames.Email)?.Value;

            var email = new Email()
            {
                To = emailAddress,
                Body =
                    $"Your leave request for {request.LeaveRequestDto.StartDate:D} to {request.LeaveRequestDto.EndDate:D} " +
                    $"has been submitted successfully.",
                Subject = "Leave Request Submitted"
            };

            try
            {
                await _emailSender.SendEmail(email);
            }
            catch (Exception ex)
            {
                // log or handle error, but don't throw
            }

            return response;
            
        }
    }
}
