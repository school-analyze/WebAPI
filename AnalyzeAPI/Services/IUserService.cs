using AnalyzeAPI.Data;
using AnalyzeAPI.Models;

namespace AnalyzeAPI.Services;

public interface IUserService
{
    public Task<List<UserModel>> GetAllUsers();
    public Task<UserModel?> GetUserById(int id);
    public Task<UserModel> AddUser(UserModel user);
    public Task DeleteUser(UserModel user);
    public Task<UserModel?> UpdateUser(int id, UserModel user);
}