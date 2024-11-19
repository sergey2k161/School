using Microsoft.EntityFrameworkCore;
using School.DataBase.Models.BaseModels;
using School.DataBase.Models.DTO;
using School.DataBase.Repositories.Interfaces;

namespace School.DataBase.Repositories.DataAccessRepositories;

public class CabinetRepository : ICabinetRepository
{
    private readonly AppDbContext _context;
    
    public CabinetRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task CreateCabinet(Cabinet cabinet)
    {
        await _context.Cabinets.AddAsync(cabinet);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCabinet(int id, CabinetDto cabinet)
    {
        await _context.Cabinets
            .Where(x => x.Id == id)
            .ExecuteUpdateAsync(x => x
                .SetProperty(d => d.Name, cabinet.Name));
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCabinet(int id)
    {
        var cabinet = await _context.Cabinets
            .FirstOrDefaultAsync(s => s.Id == id);
        _context.Cabinets.Remove(cabinet);
        
        await _context.SaveChangesAsync();
    }

    public async Task<List<Cabinet>> GetAllCabinets()
    {
        return await _context.Cabinets.ToListAsync();
    }
}