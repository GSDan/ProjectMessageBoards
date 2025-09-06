using System.Diagnostics.CodeAnalysis;

namespace MessageBoard.Domain.Entities
{
    [method: SetsRequiredMembers]
    public class Post(Guid userId, Guid projectId, string message) : BaseEntity
    {
        public required Guid UserId { get; set; } = userId;

        public virtual User User { get; set; }

        public required Guid ProjectId { get; set; } = projectId;
        public required string Message { get; set; } = message;
    }
}
