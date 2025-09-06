using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MessageBoard.Domain.Entities
{
    [method: SetsRequiredMembers]
    public class Project(string displayName)
    {
        [Key]
        public required string NormalisedName { get; set; } = displayName.ToUpperInvariant();
        public required string DisplayName { get; set; } = displayName;
        public List<Post> Posts { get; set; } = [];
    }
}
