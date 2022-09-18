using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocationDomain>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(LeaveManagementDbContext context) : base(context)
        {
        }

    }
}
