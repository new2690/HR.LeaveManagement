using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<LeaveAllocationDomain, LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveRequestDomain, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequestDomain, LeaveRequestListDto>().ReverseMap();
            CreateMap<LeaveTypeDomain, LeaveTypeDto>().ReverseMap();
        }
    }
}
