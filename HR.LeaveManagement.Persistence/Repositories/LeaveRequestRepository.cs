using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequestDomain>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(LeaveManagementDbContext context) : base(context)
        {
        }

        public async Task<bool> ChangeLeaveRequestApproval(LeaveRequestDomain currentDbEntity, bool? approvedStatus)
        {
            currentDbEntity.Approved=approvedStatus;

            return await base.UpdateAsync(currentDbEntity);
        }
    }
}
