using FluentValidation;
using HR.LeaveManagement.Application.Persistence.Contracts;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators;

// ReSharper disable once InconsistentNaming
public class ILeaveAllocationDtoValidator : AbstractValidator<ILeaveAllocationDto>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public ILeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;

        RuleFor(p => p.NumberOfDays)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.");

        RuleFor(p => p.Period)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.");

        RuleFor(p => p.LeaveTypeId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.");

        RuleFor(p => p.LeaveTypeId)
            .GreaterThan(0)
            .MustAsync(async (id, token) =>
            {
                var leaveTypExists = await _leaveTypeRepository.Exists(id);
                return !leaveTypExists;

            }).WithMessage("{PropertyName} does not exist.");
    }
}