using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Domain
{
    public class LeaveAllocationDomain: BaseDomainEntity
    {
        public int NumberOfDays { get; set; }
        public LeaveTypeDomain LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}