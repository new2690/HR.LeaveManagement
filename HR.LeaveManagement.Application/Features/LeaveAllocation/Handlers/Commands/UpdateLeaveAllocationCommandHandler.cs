using AutoMapper;
using FluentValidation;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Handlers.Commands
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, bool>
    {
        private readonly ILeaveAllocationRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateLeaveAllocationDto> _validator;

        public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository repository, IMapper mapper,IValidator<UpdateLeaveAllocationDto> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<bool> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var vResult = await _validator.ValidateAsync(request.UpdateLeaveAllocationDto);

            if (!vResult.IsValid) throw new CValidationException(vResult);

            var currentDbEntity = await _repository.GetAsync(request.UpdateLeaveAllocationDto.Id);

            _mapper.Map(request.UpdateLeaveAllocationDto, currentDbEntity);

            return await _repository.UpdateAsync(currentDbEntity);
        }
    }
}