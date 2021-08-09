using OneSchedule.DomainModels.Abstraction;

namespace OneSchedule.DomainModels
{
    public class DomainUser : DomainModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }
    }
}
