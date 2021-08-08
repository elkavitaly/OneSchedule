namespace OneSchedule.Entities.DtoModels
{
    using Abstraction;

    public class DtoUser : DtoModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }
    }
}
