using CQRSAndMediatRDemo.Data;
using CQRSAndMediatRDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Numerics;

namespace CQRSAndMediatRDemo.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContextClass _dbContext;

        public UserRepository(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserDetails> AddUserAsync(UserDetails userDetails)
        {
            var result = _dbContext.Users.Add(userDetails);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteUserAsync(int Id)
        {
            var filteredData = _dbContext.Users.Where(x => x.Id == Id).FirstOrDefault();
            _dbContext.Users.Remove(filteredData);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<UserDetails> GetUserByIdAsync(int Id)
        {
            return await _dbContext.Users.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<List<UserDetails>> GetUserListAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<int> UpdateUserAsync(UserDetails userDetails)
        {
            _dbContext.Users.Update(userDetails);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
