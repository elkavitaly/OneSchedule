using System;

namespace Application.Models
{

    public record EventEditModel(string Id, string UserId, int ChatId, string Title, string Description, DateTime Start, DateTime End);
}
