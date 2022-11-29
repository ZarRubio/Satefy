using Safety.Infraestructure;
using Safety.Infraestructure.Models;

namespace Safety.Domain;

public class UrgencyDomain : IUrgencyDomain
{
    private readonly IUrgencyRepository _UrgencyRepository;
    
    public UrgencyDomain(IUrgencyRepository UrgencyRepository)
    {
        _UrgencyRepository = UrgencyRepository;
    }
    public async Task<List<Urgency>> getUrgencyforGuardianId(int GuardianId)
    {
        return await _UrgencyRepository.getUrgencyforGuardianId(GuardianId);
    }

    public async Task<Urgency> getUrgencyforId(int id)
    {
        return await _UrgencyRepository.getUrgencyforId(id);
    }

    public async Task<bool> postUrgency(Urgency urgency)
    {
        return await _UrgencyRepository.postUrgency(urgency);
    }

    public async Task<bool> updateUrgency(int id, Urgency urgency)
    {
        return await _UrgencyRepository.updateUrgency(id, urgency);
    }

    public async Task<bool> deleteUrgency(int id)
    {
        return await _UrgencyRepository.deleteUrgency(id);
    }
}