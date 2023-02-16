using System.Linq;
using ChatApplication.Data.Entities;
using ChatApplication.Data.Interfaces;

namespace ChatApplication.Data.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {
            CollectionWithIncludes = context.Users;
        }

        protected override IQueryable<UserEntity> CollectionWithIncludes { get; set; }
    }
}