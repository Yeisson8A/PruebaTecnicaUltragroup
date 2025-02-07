using PruebaTecnicaUltragroup.Core.DTOs;
using PruebaTecnicaUltragroup.Application.Responses;

namespace PruebaTecnicaUltragroup.Application.Interfaces
{
    public interface IEmergencyContactApplication
    {
        Task<Response<List<EmergencyContactDto>>> GetEmergencyContacts();

        Task<Response<EmergencyContactDto>> GetEmergencyContact(int id);

        Task<Response<bool>> InsertEmergencyContact(EmergencyContactDto emergencyContactDto);
    }
}
