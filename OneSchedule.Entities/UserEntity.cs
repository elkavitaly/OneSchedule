using OneSchedule.Attributes;

namespace OneSchedule.Entities
{
    [CollectionName("Users")]
    public class UserEntity : BaseEntityModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }
    }
}
