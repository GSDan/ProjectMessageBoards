using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MessageBoard.Domain.Entities
{
    [method: SetsRequiredMembers]
    public class User(string displayName)
    {
        [Key]
        public required string NormalisedDisplayName { get; set; } = displayName.ToUpperInvariant();
        public required string DisplayName { get; set; } = displayName;
        public List<Project> Follows { get; set; } = [];
    }
}
