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
using FluentValidation;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Exceptions;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler:IRequestHandler<CreateLeaveRequestCommand,int>
    {
        private readonly ILeaveRequestRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateLeaveRequestDto> _validator;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository repository, IMapper mapper,IValidator<CreateLeaveRequestDto> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var vResult = await _validator.ValidateAsync(request.LeaveRequestDto);

            if (!vResult.IsValid) throw new CValidationException(vResult);

            var result = _mapper.Map<LeaveRequestDomain>(request.LeaveRequestDto);

            return (await _repository.AddAsync(result)).Id;
        }
    }
}
