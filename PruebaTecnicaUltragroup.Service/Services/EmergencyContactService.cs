using PruebaTecnicaUltragroup.Core.Entities;
using PruebaTecnicaUltragroup.Core.Interfaces;
using PruebaTecnicaUltragroup.Service.Interfaces;

namespace PruebaTecnicaUltragroup.Service.Services
{
    public class EmergencyContactService : IEmergencyContactService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmergencyContactService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EmergencyContact> GetEmergencyContact(int id)
        {
            return await _unitOfWork.EmergencyContactRepository.GetEmergencyContact(id);
        }

        public async Task<List<EmergencyContact>> GetEmergencyContacts()
        {
            return await _unitOfWork.EmergencyContactRepository.GetEmergencyContacts();
        }

        public async Task<bool> InsertEmergencyContact(EmergencyContact emergencyContact)
        {
            await _unitOfWork.EmergencyContactRepository.InsertEmergencyContact(emergencyContact);
            var rows = await _unitOfWork.SaveChangesAsync();
            return rows > 0;
        }
    }
}
