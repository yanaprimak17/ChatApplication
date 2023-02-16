using System;

namespace ChatApplication.Data.Entities
{
    public class MessageEntity : BaseEntity
    {
        public Guid SenderId { get; set; }
        
        public string Message { get; set; }
        
        public DateTimeOffset SendDate { get; set; }
        
        public bool IsEdited { get; set; }
    }
}