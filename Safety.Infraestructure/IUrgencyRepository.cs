using Safety.Infraestructure.Models;

namespace Safety.Infraestructure;

public interface IUrgencyRepository
{
    Task<List<Urgency>> getUrgencyforGuardianId(int GuardianId);
    Task<Urgency> getUrgencyforId(int id);
    Task<bool> postUrgency(Urgency urgency);
    Task<bool> updateUrgency(int id,Urgency urgency);
    Task<bool> deleteUrgency(int id);
}