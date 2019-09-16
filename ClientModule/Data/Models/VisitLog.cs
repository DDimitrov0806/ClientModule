using System;
using System.Collections.Generic;

namespace ClientModule.Data
{
    public class VisitLog
    {
        public VisitLog()
        {
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public Client Client { get; set; }
        public DateTime LoginTime { get; set; }
    }
}