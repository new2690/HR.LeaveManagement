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
            #region LeaveAllocationDomain Mapping

            CreateMap<LeaveAllocationDomain, LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocationDomain, CreateLeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocationDomain, UpdateLeaveAllocationDto>().ReverseMap();

            #endregion


            #region LeaveRequestDomain Mapping

            CreateMap<LeaveRequestDomain, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequestDomain, LeaveRequestListDto>().ReverseMap();
            CreateMap<LeaveRequestDomain, CreateLeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequestDomain, UpdateLeaveRequestDto>().ReverseMap();

            #endregion


            #region LeaveTypeDomain Mapping

            CreateMap<LeaveTypeDomain, LeaveTypeDto>().ReverseMap();
            CreateMap<LeaveTypeDomain, CreateLeaveTypeDto>().ReverseMap();

            #endregion

        }
    }
}
