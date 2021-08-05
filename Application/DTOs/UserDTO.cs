namespace Application.DTOs
{
    public record UserDTO(string Id, int TelegramUserId, string FirstName, string LastName, string PhoneNumber);
}