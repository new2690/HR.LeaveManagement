using AutoMapper;
using FluentValidation;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Requests.Commands;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Handlers.Commands
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
    {
        private readonly ILeaveAllocationRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateLeaveAllocationDto> _validator;

        public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository repository, IMapper mapper,IValidator<CreateLeaveAllocationDto> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var vResult = await _validator.ValidateAsync(request.LeaveAllocationDto);

            if (!vResult.IsValid) throw new CValidationException(vResult);

            var result = _mapper.Map<LeaveAllocationDomain>(request.LeaveAllocationDto);

            return (await _repository.AddAsync(result)).Id;
        }
    }
}
