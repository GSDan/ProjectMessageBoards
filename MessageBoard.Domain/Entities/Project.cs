using System.Diagnostics.CodeAnalysis;

namespace MessageBoard.Domain.Entities
{
    [method: SetsRequiredMembers]
    public class Project(string name) : BaseEntity
    {
        public required string Name { get; set; } = name;

        public List<Post> Posts { get; set; } = [];
    }
}
