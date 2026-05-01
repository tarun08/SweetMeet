namespace SweetMeet.API.Dto
{
    public class UserDto
    {
        public required Guid PublicId { get; set; }
        public required string DisplayName { get; set; }
        public required string Email { get; set; }
        public required string Token { get; set; }
        public string? ImageUrl { get; set; }
    }
}
