using AnalyzeAPI.Data;
using AnalyzeAPI.Models;

namespace AnalyzeAPI.Services;

public interface IUserService
{
    public Task<UserModel?> GetUserById(int id);
    public Task<UserModel> AddUser(UserModel user);
    public Task DeleteUser(int id);
    public Task<UserModel?> UpdateUser(int id, UserModel user);
}