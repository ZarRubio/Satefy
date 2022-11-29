using Microsoft.EntityFrameworkCore;
using Safety.Infraestructure.Context;
using Safety.Infraestructure.Models;


namespace Safety.Infraestructure;

public class GuardianRepository : IGuardianRepository
{
    private readonly SafetyDB _safetyDb;

    public GuardianRepository(SafetyDB safetyDb)
    {
        _safetyDb = safetyDb;
    }
    public async Task<List<Guardian>> getAll()
    {
        return await _safetyDb.Guardians.Where(guardian=>guardian.IsActive == true)
            .ToListAsync();
    }

    public async Task<Guardian> getGuardianforId(int id)
    {
        return await _safetyDb.Guardians
            .SingleOrDefaultAsync(guardian => guardian.id == id);
    }

    public async Task<bool> postGuardian(Guardian guardian)
    {
        using (var transacction = await _safetyDb.Database.BeginTransactionAsync())
        {
            try
            {
                await _safetyDb.Guardians.AddAsync(guardian);
                await _safetyDb.SaveChangesAsync();
                await transacction.CommitAsync();
            }

            catch (Exception ex)
            {
                await transacction.RollbackAsync();
            }
            finally
            {
                await transacction.DisposeAsync();
            }
        }
        return true;
    }

    public async Task<bool> updateGuardian(int id, Guardian guardian)
    {
        using (var transacction = await _safetyDb.Database.BeginTransactionAsync())
        {
            try
            {
                var existingGuardian = await _safetyDb.Guardians.FindAsync(id);
                //Console.WriteLine("ENCONTRE DATO: "+existingRoom.Name);

                existingGuardian.username = guardian.username;
                existingGuardian.email = guardian.email;
                existingGuardian.firstName = guardian.firstName;
                existingGuardian.lastName = guardian.lastName;
                existingGuardian.gender = guardian.gender;
                existingGuardian.address = guardian.address;
                existingGuardian.DateUpdated = DateTime.Now;

                _safetyDb.Guardians.Update(existingGuardian);
                await _safetyDb.SaveChangesAsync();
                _safetyDb.Database.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                await _safetyDb.Database.RollbackTransactionAsync();
            }
        }

        return true;
    }

    public async Task<bool> deleteGuardian(int id)
    {
        using (var transacction = await _safetyDb.Database.BeginTransactionAsync())
        {
            try
            {
                var guardian = await _safetyDb.Guardians.FindAsync(id);
                guardian.IsActive = false;
                guardian.DateUpdated = DateTime.Now;
                _safetyDb.Guardians.Update(guardian);
                await _safetyDb.SaveChangesAsync();
                _safetyDb.Database.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                await _safetyDb.Database.RollbackTransactionAsync();
            }
        }

        return true;
    }
    
}