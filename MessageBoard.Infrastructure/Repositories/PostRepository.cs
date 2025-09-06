using MessageBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MessageBoard.Infrastructure.Repositories
{
    public interface IPostRepository
    {
        Task<Post> Add(Post post);
    }

    public class PostRepository(IDbContextFactory<MessageBoardDbContext> contextFactory) : IPostRepository
    {
        public async Task<Post> Add(Post post)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            context.Posts.Add(post);
            await context.SaveChangesAsync();

            return post;
        }
    }
}
