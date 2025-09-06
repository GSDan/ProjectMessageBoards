namespace MessageBoard.Application.DTOs
{
    public class PostDTO
    {
        public required DateTime CreatedAt { get; set; }
        public required string PosterUserName { get; set; }
        public required string ProjectName { get; set; }
        public required string Message { get; set; }
    }
}
