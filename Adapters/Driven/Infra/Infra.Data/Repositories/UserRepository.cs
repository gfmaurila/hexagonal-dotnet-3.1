using Domain.Adapters;
using Domain.Entities;
using Infra.Data.Context;

namespace Infra.Data.Repositories
{
    public class UserRepository : AsyncRepository<User>, IUserRepository
    {
        private new readonly ContextDb _context;
        public UserRepository(ContextDb Context)
            : base(Context)
        {
            _context = Context;
        }
    }
}
