using MediatR;
using MessageBoard.Application.DTOs;

namespace MessageBoard.Application.Queries
{
    public record GetUserQuery(Guid Id) : IRequest<UserDTO?>;

}
