using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators
{
    public class UpdateLeaveRequestDtoValidator:AbstractValidator<UpdateLeaveRequestDto>
    {
        private readonly ILeaveRequestRepository _repository;

        public UpdateLeaveRequestDtoValidator(ILeaveRequestRepository repository)
        {
            _repository = repository;

            Include(new ILeaveRequestDtoValidator(_repository));

            RuleFor(p => p.Id)
                .NotNull().WithMessage("{PropertName} is required");
        }
    }
}
