using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Exceptions
{
    public class CValidationException:ApplicationException
    {
        public List<string> Errors { get; set; } = new List<string>();

        public CValidationException(ValidationResult validationResult)
        {
            Errors.AddRange(validationResult.Errors.Select(s => s.ErrorMessage).ToList());
        }
    }
}
