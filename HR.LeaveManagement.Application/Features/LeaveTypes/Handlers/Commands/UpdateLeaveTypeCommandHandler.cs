using AutoMapper;
using FluentValidation;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, bool>
    {
        private readonly ILeaveTypeRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<LeaveTypeDto> _validator;

        public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository repository,IMapper mapper, IValidator<LeaveTypeDto> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<bool> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var result = await _validator.ValidateAsync(request.LeaveTypeDto);

            if (!result.IsValid) throw new CValidationException(result);

            var currentDbEntity = await _repository.GetAsync(request.LeaveTypeDto.Id);

            _mapper.Map(request.LeaveTypeDto, currentDbEntity);

            return await _repository.UpdateAsync(currentDbEntity);
        }
    }
}
