using MediatR;
using MessageBoard.Application.DTOs;

namespace MessageBoard.Application.Commands
{
    public record CreateUserCommand(string Name) : IRequest<CommandResult<UserDTO>>;
    public record CreatePostCommand(string Username, string ProjectName, string Message) : IRequest<CommandResult<PostDTO>>;
    public record CreateProjectCommand(string Name) : IRequest<CommandResult<ProjectDTO>>;

}
