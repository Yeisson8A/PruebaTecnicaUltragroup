using PruebaTecnicaUltragroup.Core.Entities;

namespace PruebaTecnicaUltragroup.Service.Interfaces
{
    public interface IEmergencyContactService
    {
        Task<List<EmergencyContact>> GetEmergencyContacts();

        Task<EmergencyContact> GetEmergencyContact(int id);

        Task<bool> InsertEmergencyContact(EmergencyContact emergencyContact);
    }
}
