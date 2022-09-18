using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators
{
    public class CreateLeaveRequestDtoValidator : AbstractValidator<CreateLeaveRequestDto>
    {
        private readonly ILeaveRequestRepository _repository;

        public CreateLeaveRequestDtoValidator(ILeaveRequestRepository repository)
        {
            _repository = repository;

            Include(new ILeaveRequestDtoValidator(_repository));
        }
    }
}
