namespace MessageBoard.Domain.Entities
{
    public abstract class BaseEntity
    {
        public required Guid Id { get; set; }
        public required DateTime CreatedAt { get; set; }

        public BaseEntity()
        {

            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }
    }
}
