using AnalyzeAPI.Models;

namespace AnalyzeAPI.Services;

public interface IUserService
{
    public Task<UserModel> GetUser(int id);
    public Task<UserModel> AddUser(UserModel user);
    public Task<UserModel> DeleteUser(int id);
    public Task<UserModel> UpdateUser(int id, UserModel user);
}