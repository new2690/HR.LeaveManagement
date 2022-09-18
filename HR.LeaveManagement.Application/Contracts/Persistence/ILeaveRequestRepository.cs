using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Contracts.Persistence
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequestDomain>
    {
        Task<bool> ChangeLeaveRequestApproval(LeaveRequestDomain currentDbEntity, bool? approvedStatus);
        
    }
}
