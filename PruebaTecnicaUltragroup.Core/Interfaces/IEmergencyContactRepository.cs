using PruebaTecnicaUltragroup.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnicaUltragroup.Core.Interfaces
{
    public interface IEmergencyContactRepository
    {
        Task<List<EmergencyContact>> GetEmergencyContacts();

        Task<EmergencyContact> GetEmergencyContact(int id);

        Task InsertEmergencyContact(EmergencyContact emergencyContact);
    }
}
