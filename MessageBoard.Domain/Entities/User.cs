using System.Diagnostics.CodeAnalysis;

namespace MessageBoard.Domain.Entities
{
    [method: SetsRequiredMembers]
    public class User(string userName) : BaseEntity
    {
        public required string UserName { get; set; } = userName;

        public List<Project> Follows { get; set; } = [];
    }
}
