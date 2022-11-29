using Safety.Infraestructure;
using Safety.Infraestructure.Models;

namespace Safety.Domain;

public class GuardianDomain : IGuardianDomain
{
    private readonly IGuardianRepository _GuardianRepository;
    
    public GuardianDomain(IGuardianRepository GuardianRepository)
    {
        _GuardianRepository = GuardianRepository;
    }
    public async Task<List<Guardian>> getAll()
    {
        return await _GuardianRepository.getAll();
    }

    public async Task<Guardian> getGuardianforId(int id)
    {
        return await _GuardianRepository.getGuardianforId(id);
    }

    public async Task<bool> postGuardian(Guardian guardian)
    {
        return await _GuardianRepository.postGuardian(guardian);
    }

    public async Task<bool> updateGuardian(int id, Guardian guardian)
    {
        return await _GuardianRepository.updateGuardian(id, guardian);
    }

    public async Task<bool> deleteGuardian(int id)
    {
        return await _GuardianRepository.deleteGuardian(id);
    }
}