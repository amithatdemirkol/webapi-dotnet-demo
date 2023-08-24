using CQRSAndMediatRDemo.Models;

namespace CQRSAndMediatRDemo.Repositories
{
    public interface IUserRepository
    {
        public Task<List<UserDetails>> GetUserListAsync();
        public Task<UserDetails> GetUserByIdAsync(int Id);
        public Task<UserDetails> AddUserAsync(UserDetails userDetails);
        public Task<int> UpdateUserAsync(UserDetails userDetails);
        public Task<int> DeleteUserAsync(int Id);
    }
}
