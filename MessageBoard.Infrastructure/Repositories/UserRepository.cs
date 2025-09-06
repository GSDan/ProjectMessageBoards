using MessageBoard.Domain.Entities;

namespace MessageBoard.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<User> Add(User newUser);
    }

    public class UserRepository : IUserRepository
    {
        public async Task<User> Add(User newUser)
        {
            // add to db

            return newUser;
        }
    }
}
