using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Exceptions
{
    public class CBadRequestException: ApplicationException
    {
        public CBadRequestException(string message):base(message)
        {

        }
    }
}
