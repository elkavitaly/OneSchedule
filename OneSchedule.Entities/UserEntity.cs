using OneSchedule.Entities.Abstraction;

namespace OneSchedule.Entities
{
    public class UserEntity : BaseEntityModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }
    }
}
