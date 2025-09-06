using MediatR;
using MessageBoard.Application.Commands;
using MessageBoard.Application.DTOs;
using MessageBoard.Domain.Entities;
using MessageBoard.Infrastructure.Repositories;

namespace MessageBoard.Application.Handlers.Posts
{
    public class CreatePostHandler(IUserRepository userRepository, IProjectRepository projectRepository, IPostRepository postRepository) : IRequestHandler<CreatePostCommand, CommandResult<PostDTO>>
    {
        public async Task<CommandResult<PostDTO>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Create user if they don't exist
                User? poster = await userRepository.Get(request.Username);

                if (poster == null)
                {
                    poster = await userRepository.Add(new User(request.Username));
                }

                // Create project if it doesn't exist
                Project? project = await projectRepository.Get(request.ProjectName);

                if (project == null)
                {
                    project = await projectRepository.Add(new Project(request.ProjectName));
                }

                // Create post and return success
                Post newPost = new()
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.UtcNow,
                    ProjectNormalisedName = project.NormalisedName,
                    UserNormalisedDisplayName = poster.NormalisedDisplayName,
                    Message = request.Message
                };

                await postRepository.Add(newPost);

                return new CommandResult<PostDTO>
                {
                    Success = true,
                    Data = new PostDTO
                    {
                        CreatedAt = newPost.CreatedAt,
                        Message = newPost.Message,
                        PosterUserName = poster.DisplayName,
                        ProjectName = project.DisplayName
                    }
                };
            }
            catch (Exception ex)
            {
                return new CommandResult<PostDTO>
                {
                    Success = false,
                    Error = ex.Message
                };
            }

        }
    }
}
