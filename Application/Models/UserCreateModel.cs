namespace Application.Models
{
    public record UserCreateModel(int TelegramUserId, string FirstName, string LastName, string PhoneNumber);
}
