using System.ComponentModel.DataAnnotations;

namespace MessageBoard.Domain.Entities
{
    public class Post
    {
        [Key]
        public required Guid Id { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required string UserNormalisedDisplayName { get; set; }
        public virtual User User { get; set; }
        public required string ProjectNormalisedName { get; set; }
        public required string Message { get; set; }
    }
}
