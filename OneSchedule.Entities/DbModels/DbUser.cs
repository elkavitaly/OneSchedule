namespace OneSchedule.Entities.DbModels
{
    using Abstraction;

    public class DbUser : DbModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }
    }
}
