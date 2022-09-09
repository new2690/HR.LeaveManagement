using AutoMapper;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Handlers.Commands
{
    public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand, bool>
    {
        private readonly ILeaveAllocationRepository _repository;
        private readonly IMapper _mapper;

        public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var currentEntity = await _repository.GetAsync(request.Id);

            if (currentEntity == null) throw new CNotFoundException(nameof(request.Id), request.Id);

            return await _repository.DeleteAsync(currentEntity);
        }
    }

}
