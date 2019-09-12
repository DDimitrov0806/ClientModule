using System;

namespace ClientModule.Data
{
    public class ActivityLog
    {
        public System.Guid Id { get; set; }
        public System.Guid UserId { get; set; }

        public DateTime LoginTime { get; set; }
    }
}