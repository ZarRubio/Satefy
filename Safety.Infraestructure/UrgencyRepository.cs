using Microsoft.EntityFrameworkCore;
using Safety.Infraestructure.Context;
using Safety.Infraestructure.Models;

namespace Safety.Infraestructure;

public class UrgencyRepository : IUrgencyRepository
{

    private readonly SafetyDB _safetyDb;

    public UrgencyRepository(SafetyDB safetyDb)
    {
        _safetyDb = safetyDb;
    }
    
    public async Task<List<Urgency>> getUrgencyforGuardianId(int GuardianId)
    {
        return await _safetyDb.Urgencies.Where(urgency=>urgency.IsActive == true)
            .ToListAsync();    }

    public async Task<Urgency> getUrgencyforId(int id)
    {
        return await _safetyDb.Urgencies
            .SingleOrDefaultAsync(urgency => urgency.id == id);        
    }

    public async Task<bool> postUrgency(Urgency urgency)
    {
        using (var transacction = await _safetyDb.Database.BeginTransactionAsync())
        {
            try
            {
                await _safetyDb.Urgencies.AddAsync(urgency);
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

    public async Task<bool> updateUrgency(int id, Urgency urgency)
    {
        using (var transacction = await _safetyDb.Database.BeginTransactionAsync())
        {
            try
            {
                var existingUrgency = await _safetyDb.Urgencies.FindAsync(id);
                //Console.WriteLine("ENCONTRE DATO: "+existingRoom.Name);

                existingUrgency.title = urgency.title;
                existingUrgency.summary = urgency.summary;
                existingUrgency.latitude = urgency.latitude;
                existingUrgency.longitude = urgency.longitude;
                existingUrgency.reportedAt = DateTime.Now;
                existingUrgency.DateUpdated = DateTime.Now;

                _safetyDb.Urgencies.Update(existingUrgency);
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

    public async Task<bool> deleteUrgency(int id)
    {
        using (var transacction = await _safetyDb.Database.BeginTransactionAsync())
        {
            try
            {
                var urgency = await _safetyDb.Urgencies.FindAsync(id);
                urgency.IsActive = false;
                urgency.DateUpdated = DateTime.Now;
                _safetyDb.Urgencies.Update(urgency);
                await _safetyDb.SaveChangesAsync();
                _safetyDb.Database.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                await _safetyDb.Database.RollbackTransactionAsync();
            }
        }

        return true;    }
}