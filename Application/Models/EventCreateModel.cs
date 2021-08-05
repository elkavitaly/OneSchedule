using System;

namespace Application.Models
{

    public record EventCreateModel(string UserId, int ChatId, string Title, string Description, DateTime Start, DateTime End);
}
