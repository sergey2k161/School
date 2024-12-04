using Microsoft.EntityFrameworkCore;
using School.DataBase.Models.BaseModels;
using School.DataBase.Repositories.Interfaces;

namespace School.DataBase.Repositories.DataAccessRepositories;

public class AdminRepository : IAdminRepository
{
    private readonly AppDbContext _context;

    public AdminRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task CreateAdmin(Admin admin)
    {
        await _context.Admins.AddAsync(admin);
        await _context.SaveChangesAsync();
    }
    
    public async Task RemoveAdmin(int adminId)
    {
        var admin = await _context.Admins
            .FirstOrDefaultAsync(a => a.Id == adminId);

        _context.Admins.Remove(admin);
        
        var commonUser = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == admin.CommonUserId);

        if (commonUser != null)
        {
            _context.Users.Remove(commonUser);
        }

        await _context.SaveChangesAsync();
    }
    
}