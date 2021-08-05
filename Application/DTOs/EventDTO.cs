using System;

namespace Application.DTOs
{
    public record EventDTO(string Id, int ChatId, string Title, string Description, DateTime Start, DateTime End);
}
