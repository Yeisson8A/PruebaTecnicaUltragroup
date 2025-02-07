using AutoMapper;
using PruebaTecnicaUltragroup.Core.DTOs;
using PruebaTecnicaUltragroup.Application.Interfaces;
using PruebaTecnicaUltragroup.Application.Responses;
using PruebaTecnicaUltragroup.Application.Validators;
using PruebaTecnicaUltragroup.Core.Entities;
using PruebaTecnicaUltragroup.Service.Interfaces;

namespace PruebaTecnicaUltragroup.Application.Main
{
    public class EmergencyContactApplication : IEmergencyContactApplication
    {
        private readonly IEmergencyContactService _emergencyContactService;
        private readonly IMapper _mapper;
        private readonly EmergencyContactDtoValidator _emergencyContactDtoValidator;

        public EmergencyContactApplication(IEmergencyContactService emergencyContactService, IMapper mapper, EmergencyContactDtoValidator emergencyContactDtoValidator)
        {
            _emergencyContactService = emergencyContactService;
            _mapper = mapper;
            _emergencyContactDtoValidator = emergencyContactDtoValidator;
        }

        public async Task<Response<EmergencyContactDto>> GetEmergencyContact(int id)
        {
            var response = new Response<EmergencyContactDto>();

            try
            {
                var contact = await _emergencyContactService.GetEmergencyContact(id);
                response.Data = _mapper.Map<EmergencyContactDto>(contact);
                response.IsSuccess = true;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<List<EmergencyContactDto>>> GetEmergencyContacts()
        {
            var response = new Response<List<EmergencyContactDto>>();

            try
            {
                var contacts = await _emergencyContactService.GetEmergencyContacts();
                response.Data = _mapper.Map<List<EmergencyContactDto>>(contacts);
                response.IsSuccess = true;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> InsertEmergencyContact(EmergencyContactDto emergencyContactDto)
        {
            var response = new Response<bool>();
            var validation = _emergencyContactDtoValidator.Validate(emergencyContactDto);

            if (!validation.IsValid)
            {
                response.Message = "Validation Errors";
                response.Errors = validation.Errors;
                return response;
            }

            try
            {
                var contact = _mapper.Map<EmergencyContact>(emergencyContactDto);
                response.Data = await _emergencyContactService.InsertEmergencyContact(contact);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Successfull";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
    }
}
