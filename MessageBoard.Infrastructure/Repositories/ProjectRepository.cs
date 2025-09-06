using MessageBoard.Domain.Entities;

namespace MessageBoard.Infrastructure.Repositories
{
    public interface IProjectRepository
    {
        Task<Project> Add(Project newProject);
    }

    public class ProjectRepository : IProjectRepository
    {
        public async Task<Project> Add(Project newProject)
        {
            // add to db

            return newProject;
        }
    }
}
