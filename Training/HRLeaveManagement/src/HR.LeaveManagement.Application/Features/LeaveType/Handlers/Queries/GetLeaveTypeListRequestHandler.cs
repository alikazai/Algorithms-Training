using AutoMapper;
using HR.LeaveManagement.Application.DTOs;
using HR.LeaveManagement.Application.Features.LeaveType.Requests.Queries;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Handlers.Queries
{
    public class GetLeaveTypeListRequestHandler : IRequestHandler<GetLeaveTypeListRequest, List<LeaveTypeDto>>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeListRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeListRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.GetAll();
            return _mapper.Map<List<LeaveTypeDto>>(leaveType);
        }
    }
}
