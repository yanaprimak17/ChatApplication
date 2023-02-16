using System.Linq;
using ChatApplication.Data.Entities;
using ChatApplication.Data.Interfaces;

namespace ChatApplication.Data.Repositories
{
    public class MessageRepository : BaseRepository<MessageEntity>, IMessageRepository
    {
        public MessageRepository(Context context) : base(context)
        {
            CollectionWithIncludes = context.Messages;
        }

        protected override IQueryable<MessageEntity> CollectionWithIncludes { get; set; }
    }
}