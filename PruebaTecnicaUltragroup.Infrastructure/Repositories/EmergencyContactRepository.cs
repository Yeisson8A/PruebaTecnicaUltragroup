using Microsoft.EntityFrameworkCore;
using PruebaTecnicaUltragroup.Core.Entities;
using PruebaTecnicaUltragroup.Core.Interfaces;
using PruebaTecnicaUltragroup.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnicaUltragroup.Infrastructure.Repositories
{
    public class EmergencyContactRepository : IEmergencyContactRepository
    {
        private readonly DbpruebaUltragroupContext _context;

        public EmergencyContactRepository(DbpruebaUltragroupContext context)
        {
            _context = context;
        }

        public async Task<EmergencyContact> GetEmergencyContact(int id)
        {
            var emergencyContact = await _context.EmergencyContacts.FindAsync(id);
            return emergencyContact;
        }

        public async Task<List<EmergencyContact>> GetEmergencyContacts()
        {
            var emergencyContacts = await _context.EmergencyContacts.ToListAsync();
            return emergencyContacts;
        }

        public async Task InsertEmergencyContact(EmergencyContact emergencyContact)
        {
            await _context.EmergencyContacts.AddAsync(emergencyContact);
        }
    }
}
