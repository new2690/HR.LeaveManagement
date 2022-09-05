using AutoMapper;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;
using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.Features.LeaveRequest.Requests.Commands;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler:IRequestHandler<CreateLeaveRequestCommand,int>
    {
        private readonly ILeaveRequestRepository _repository;
        private readonly IMapper _mapper;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<LeaveRequestDomain>(request.LeaveRequestDto);

            return (await _repository.AddAsync(result)).Id;
        }
    }
}
