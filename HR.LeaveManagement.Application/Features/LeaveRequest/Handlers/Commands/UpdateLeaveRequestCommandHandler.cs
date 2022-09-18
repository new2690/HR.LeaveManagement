using AutoMapper;
using FluentValidation;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveRequest.Requests.Commands;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Handlers.Commands
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, bool>
    {
        private readonly ILeaveRequestRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateLeaveRequestDto> _validator;

        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository repository, IMapper mapper,IValidator<UpdateLeaveRequestDto> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<bool> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var vResult = await _validator.ValidateAsync(request.UpdateLeaveRequestDto);

            if (!vResult.IsValid) throw new CValidationException(vResult);

            var currentDbEntity = await _repository.GetAsync(request.Id);

            if (request.UpdateLeaveRequestDto != null)
            {
                _mapper.Map(request.UpdateLeaveRequestDto, currentDbEntity);

                return await _repository.UpdateAsync(currentDbEntity);
            }
            else if (request.ChangeLeaveRequestApprovalDto != null)
            {
                return await _repository.ChangeLeaveRequestApproval(currentDbEntity, request.ChangeLeaveRequestApprovalDto.Approved);
            }

            return false;
        }
    }
}
