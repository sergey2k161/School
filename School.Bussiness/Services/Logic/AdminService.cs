using Microsoft.AspNetCore.Identity;
using School.Bussiness.Services.Interfaces;
using School.DataBase.Models.BaseModels;
using School.DataBase.Models.DTO;
using School.DataBase.Repositories.Interfaces;

namespace School.Bussiness.Services.Logic;

public class AdminService: IAdminService
{
    private readonly IAdminRepository _adminRepository;
    private readonly UserManager<CommonUser> _userManager;
    
    public AdminService(IAdminRepository adminRepository, UserManager<CommonUser> userManager)
    {
        _adminRepository = adminRepository;
        _userManager = userManager;
    }

    public async Task CreateAdminAsync(AdminDto model)
    {
        var user = new CommonUser
        {
            Email = model.Email,
            UserName = model.Email
        };

        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
        {
            throw new Exception($"Error creating user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }
        
        var roleResult = await _userManager.AddToRoleAsync(user, "Admin");
        if (!roleResult.Succeeded)
        {
            throw new Exception($"Error adding user to role: {string.Join(", ", roleResult.Errors.Select(e => e.Description))}");
        }
        
        // Создаём администратора без привязки к роли
        var admin = new Admin
        {
            Email = model.Email,
            Name = model.Name,
            CommonUserId = user.Id // Связываем Admin с CommonUser через CommonUserId
        };

        await _adminRepository.CreateAdmin(admin);

        // Связываем пользователя с администратором
        user.AdminId = admin.Id;
        await _userManager.UpdateAsync(user);
    }


    public async Task DeleteAdminAsync(int id)
    {
        await _adminRepository.RemoveAdmin(id);
    }
}