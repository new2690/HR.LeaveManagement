using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class LeaveTypeDtoValidator:AbstractValidator<LeaveTypeDto>
    {
        public LeaveTypeDtoValidator()
        {
            Include(new ILeaveTypeDtoValidator());

            RuleFor(r => r.Id)
                .NotNull().WithMessage("{PropertyName} is required");
        }
    }
}
