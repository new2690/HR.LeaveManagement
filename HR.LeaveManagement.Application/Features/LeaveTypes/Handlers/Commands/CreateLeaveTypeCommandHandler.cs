using AutoMapper;
using FluentValidation;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.DTOs.LeaveType.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, BaseCommandResponse>
    {
        private readonly ILeaveTypeRepository _typeRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateLeaveTypeDto> _validator;

        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository typeRepository,IMapper mapper,IValidator<CreateLeaveTypeDto> validator)
        {
            _typeRepository = typeRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var baseCommandResponse = new BaseCommandResponse();

            var result = await _validator.ValidateAsync(request.CreateLeaveTypeDto);

            if (!result.IsValid) throw new CValidationException(result);

            var leaveType = _mapper.Map<LeaveTypeDomain>(request.CreateLeaveTypeDto);

            await _typeRepository.AddAsync(leaveType);

            baseCommandResponse.Success = true;

            baseCommandResponse.Message = "Creation was successful";

            baseCommandResponse.Id = leaveType.Id;

            return baseCommandResponse;
        }
    }
}
