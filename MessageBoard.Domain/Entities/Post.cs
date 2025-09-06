namespace MessageBoard.Domain.Entities
{
    public class Post : BaseEntity
    {
        public required Guid UserId { get; set; }
        public required Guid ProjectId { get; set; }
        public required string Message { get; set; }
    }
}
