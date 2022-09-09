using FluentValidation;
using HR.LeaveManagement.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
    public class UpdateLeaveAllocationDtoValidator:AbstractValidator<UpdateLeaveAllocationDto>
    {
        private readonly ILeaveAllocationRepository _repository;

        public UpdateLeaveAllocationDtoValidator(ILeaveAllocationRepository repository)
        {
            _repository = repository;

            Include(new ILeaveAllocationDtoValidator(_repository));

            RuleFor(p => p.Id)
                .NotNull().WithMessage("{PropertyName} is required.");
        }
    }
}
