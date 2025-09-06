using MediatR;

namespace MessageBoard.Application.Commands
{
    public record CreateUserCommand(string Name) : IRequest<Guid>;
    public record CreateProjectCommand(string Name) : IRequest<Guid>;

}
