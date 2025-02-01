using AnalyzeAPI.Data;
using AnalyzeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AnalyzeAPI.Services;

public class UserService(AppDbContext db) : IUserService
{
    private readonly AppDbContext _db = db;

    public async Task<List<UserModel>> GetAllUsers()
    {
        return await _db.Users.ToListAsync();
    }

    public async Task<UserModel?> GetUserById(int id)
    {
        return await _db.Users.FindAsync(id);
    }

    public async Task<List<GradeModel>> GetUserGrades(int id)
    {
        return await _db.Grades.Where(g => g.UserId == id).ToListAsync(); 
    }

    public async Task<UserModel> AddUser(UserModel user)
    {
        _db.Users.Add(user);
        await _db.SaveChangesAsync();
        return user;
    }

    public async Task DeleteUser(UserModel user)
    {
        _db.Users.Remove(user);
        await _db.SaveChangesAsync();
    }

    public async Task<UserModel?> UpdateUser(int id, UserModel user)
    {
        var existingUser = await _db.Users.FindAsync(id);
        if (existingUser == null)
        {
            return null;
        }
        existingUser.UserName = user.UserName;
        existingUser.PasswordHash = user.PasswordHash;
        
        await _db.SaveChangesAsync();
        return existingUser;
    }
}