using MediatR;
using MessageBoard.Application.Commands;
using MessageBoard.Domain.Entities;
using MessageBoard.Infrastructure.Repositories;

namespace MessageBoard.Application.Handlers.Users
{
    public class CreateUserHandler(IUserRepository userRepository) : IRequestHandler<CreateUserCommand, string>
    {
        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User newUser = new(request.Name);
            await userRepository.Add(newUser);
            return newUser.NormalisedDisplayName;
        }
    }
}
