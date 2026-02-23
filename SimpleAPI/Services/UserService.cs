using SimpleApi.Models;

namespace SimpleApi.Services;

public class UserService : IUserService
{
    private static readonly List<User> _users = new();
    private static int _id = 1;

    public Task<List<User>> GetAllAsync()
    {
        return Task.FromResult(_users);
    }

    public Task<User?> GetByIdAsync(int id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        return Task.FromResult(user);
    }

    public Task<User> CreateAsync(User user)
    {
        user.Id = _id++;
        _users.Add(user);
        return Task.FromResult(user);
    }

    public Task<bool> UpdateAsync(int id, User updatedUser)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user == null) return Task.FromResult(false);

        user.Name = updatedUser.Name;
        user.Email = updatedUser.Email;
        return Task.FromResult(true);
    }

    public Task<bool> DeleteAsync(int id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user == null) return Task.FromResult(false);

        _users.Remove(user);
        return Task.FromResult(true);
    }
}