using Safety.Infraestructure.Models;

namespace Safety.Domain;

public interface IGuardianDomain
{
    Task<List<Guardian>> getAll();
    Task<Guardian> getGuardianforId(int id);
    Task<bool> postGuardian(Guardian guardian);
    Task<bool> updateGuardian(int id,Guardian guardian);
    Task<bool> deleteGuardian(int id);
}