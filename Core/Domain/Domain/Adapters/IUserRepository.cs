using Domain.Entities;

namespace Domain.Adapters
{
    public interface IUserRepository : IAsyncRepository<User>
    {
    }
}
