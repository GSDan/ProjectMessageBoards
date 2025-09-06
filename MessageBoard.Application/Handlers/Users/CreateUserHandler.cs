using MediatR;
using MessageBoard.Application.Commands;
using MessageBoard.Application.DTOs;
using MessageBoard.Domain.Entities;
using MessageBoard.Infrastructure.Repositories;

namespace MessageBoard.Application.Handlers.Users
{
    public class CreateUserHandler(IUserRepository userRepository) : IRequestHandler<CreateUserCommand, CommandResult<UserDTO>>
    {
        public async Task<CommandResult<UserDTO>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User newUser = new(request.Name);
            await userRepository.Add(newUser);

            return new CommandResult<UserDTO>
            {
                Success = true,
                Data = new UserDTO
                {
                    Name = newUser.DisplayName
                }
            };
        }
    }
}
