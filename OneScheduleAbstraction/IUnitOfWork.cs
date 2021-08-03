namespace OneScheduleAbstraction
{
    using System.Threading.Tasks;
    public interface IUnitOfWork
    {
        Task SaveAsync();
    }
}