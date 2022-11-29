using Safety.Infraestructure.Models;

namespace Safety.Domain;

public interface IUrgencyDomain
{
    Task<List<Urgency>> getUrgencyforGuardianId(int GuardianId);
    Task<Urgency> getUrgencyforId(int id);
    Task<bool> postUrgency(Urgency urgency);
    Task<bool> updateUrgency(int id,Urgency urgency);
    Task<bool> deleteUrgency(int id);
}