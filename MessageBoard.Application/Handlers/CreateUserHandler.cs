using MediatR;
using MessageBoard.Application.Commands;
using MessageBoard.Domain.Entities;
using MessageBoard.Infrastructure.Repositories;

namespace MessageBoard.Application.Handlers
{
    public class CreateUserHandler(IUserRepository userRepository) : IRequestHandler<CreateUserCommand, Guid>
    {
        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User newUser = new(request.Name);

            await userRepository.Add(newUser);

            return newUser.Id;
        }
    }
}
