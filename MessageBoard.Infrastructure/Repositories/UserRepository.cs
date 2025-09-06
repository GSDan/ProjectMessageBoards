using MessageBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MessageBoard.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<User> Add(User newUser);
        Task<User?> Get(Guid id);
    }

    public class UserRepository(IDbContextFactory<MessageBoardDbContext> contextFactory) : IUserRepository
    {
        public async Task<User> Add(User newUser)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            User? existing = await context.Users.FindAsync(newUser.Id);

            if (existing != null)
            {
                throw new ArgumentException("User with that ID already exists", nameof(newUser));
            }

            context.Users.Add(newUser);
            await context.SaveChangesAsync();

            return newUser;
        }

        public async Task<User?> Get(Guid id)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            return await context.Users.FindAsync(id);
        }
    }
}
