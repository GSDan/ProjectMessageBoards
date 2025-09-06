using MessageBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MessageBoard.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<User> Add(User newUser);
        Task<User?> Get(string userName);
    }

    public class UserRepository(IDbContextFactory<MessageBoardDbContext> contextFactory) : IUserRepository
    {
        public async Task<User> Add(User newUser)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            User? existing = await context.Users.FindAsync(newUser.NormalisedDisplayName);

            if (existing != null)
            {
                throw new ArgumentException("User with that username already exists", nameof(newUser));
            }

            context.Users.Add(newUser);
            await context.SaveChangesAsync();

            return newUser;
        }

        public async Task<User?> Get(string userName)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            return await context.Users.FindAsync(userName.ToUpperInvariant());
        }
    }
}
