using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
    public class CreateLeaveAllocationDtoValidator:AbstractValidator<CreateLeaveAllocationDto>
    {
        private readonly ILeaveAllocationRepository _repository;

        public CreateLeaveAllocationDtoValidator(ILeaveAllocationRepository repository)
        {
            _repository = repository;

            Include(new ILeaveAllocationDtoValidator(_repository));
        }
    }
}
