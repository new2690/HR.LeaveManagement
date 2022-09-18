using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.Features.LeaveRequest.Requests.Commands;
using FluentValidation;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Contracts.Infrastructure;
using HR.LeaveManagement.Application.Models;
using HR.LeaveManagement.Application.Responses;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler:IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository _repository;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateLeaveRequestDto> _validator;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository repository,IEmailSender emailSender, IMapper mapper,IValidator<CreateLeaveRequestDto> validator)
        {
            _repository = repository;
            _emailSender = emailSender;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var vResult = await _validator.ValidateAsync(request.LeaveRequestDto);

            BaseCommandResponse baseCommandResponse = new BaseCommandResponse();

            if (!vResult.IsValid)
            {
                baseCommandResponse.Message = "Creation was failed";

                baseCommandResponse.Success = false;

                baseCommandResponse.Errors = vResult.Errors.Select(e => e.ErrorMessage).ToList();

                return baseCommandResponse;
            }

            var result = _mapper.Map<LeaveRequestDomain>(request.LeaveRequestDto);

            await _repository.AddAsync(result);

            try
            {
                await SendEmail(request);
            }
            catch (Exception ex)
            {
                
            }

            baseCommandResponse.Id = result.Id;

            baseCommandResponse.Message = "Creation was successful";

            baseCommandResponse.Success = true;

            return baseCommandResponse;
        }

        private async Task SendEmail(CreateLeaveRequestCommand request)
        {
            var email = new Email
            {
                To = "Soroush.saidy@gmail.com",
                Body = $"Your Leave Request submited. " +
                            $"This email was sent by the {nameof(HR.LeaveManagement)} program. your leave request from " +
                            $"{request.LeaveRequestDto.StartDate:F} date" +
                            $"has been approved.",
                Subject = "Leave Request Submited"
            };

            await _emailSender.SendEmailAsync(email);
        }
    }
}
