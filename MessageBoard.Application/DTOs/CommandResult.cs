namespace MessageBoard.Application.DTOs
{
    public record CommandResult<T>
    {
        public required bool Success { get; set; }
        public string? Error { get; set; }
        public T? Data { get; set; }
    }
}
