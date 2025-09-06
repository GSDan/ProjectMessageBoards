namespace MessageBoard.Domain.ValueObjects
{
    public class Follow
    {
        public required Guid UserId { get; set; }
        public required Guid ProjectId { get; set; }
    }
}
