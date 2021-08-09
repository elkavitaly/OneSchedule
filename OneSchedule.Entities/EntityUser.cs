using OneSchedule.Entities.Abstraction;

namespace OneSchedule.Entities
{
    public class EntityUser : EntityModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }
    }
}
