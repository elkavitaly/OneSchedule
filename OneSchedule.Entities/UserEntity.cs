using OneSchedule.Helpers;

namespace OneSchedule.Entities
{
    [CollectionName("Events")]
    public class UserEntity : BaseEntityModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }
    }
}
