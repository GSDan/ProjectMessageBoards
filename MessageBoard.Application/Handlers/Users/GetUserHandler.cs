using MediatR;
using MessageBoard.Application.DTOs;
using MessageBoard.Application.Queries;
using MessageBoard.Domain.Entities;
using MessageBoard.Infrastructure.Repositories;

namespace MessageBoard.Application.Handlers.Users
{
    internal class GetUserHandler(IUserRepository userRepository) : IRequestHandler<GetUserQuery, UserDTO?>
    {
        public async Task<UserDTO?> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            User? res = await userRepository.Get(request.Id);

            if (res == null) return null;

            return new UserDTO
            {
                Id = res.Id,
                Name = res.UserName
            };
        }
    }
}
