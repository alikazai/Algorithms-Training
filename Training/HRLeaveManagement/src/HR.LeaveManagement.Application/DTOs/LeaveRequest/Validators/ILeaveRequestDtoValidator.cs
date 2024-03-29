﻿using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators;

// ReSharper disable once InconsistentNaming
public class ILeaveRequestDtoValidator : AbstractValidator<ILeaveRequestDto>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    public ILeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;

        RuleFor(p => p.StartDate)
            .LessThan(p => p.EndDate).WithMessage("{PropertyName} must be before {ComparisonValue}");

        RuleFor(p => p.EndDate)
            .GreaterThan(p => p.StartDate).WithMessage("{PropertyName} must be before {ComparisonValue}");

        //RuleFor(p => p.LeaveTypeId)
        //    .GreaterThan(0)
        //    .MustAsync(async (id, token) =>
        //    {
        //        var leaveTypExists = await _leaveTypeRepository.Exists(id);
        //        return !leaveTypExists;

        //    }).WithMessage("{PropertyName} does not exist.");
    }
}