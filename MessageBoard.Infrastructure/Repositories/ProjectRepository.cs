using MessageBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MessageBoard.Infrastructure.Repositories
{
    public interface IProjectRepository
    {
        Task<Project> Add(Project newProject);
        Task<Project?> Get(string projectName);
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

        public async Task<Project?> Get(string projectName)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            return await context.Projects.FindAsync(projectName);
        }
    }
}
