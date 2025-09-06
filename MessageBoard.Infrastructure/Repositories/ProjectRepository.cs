using MessageBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MessageBoard.Infrastructure.Repositories
{
    public interface IProjectRepository
    {
        Task<Project> Add(Project newProject);
    }

    public class ProjectRepository(IDbContextFactory<MessageBoardDbContext> contextFactory) : IProjectRepository
    {
        public async Task<Project> Add(Project newProject)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            context.Projects.Add(newProject);
            await context.SaveChangesAsync();

            return newProject;
        }
    }
}
