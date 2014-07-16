using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimesheetApi.dto
{
    public class PostJobDto
    {
        public DateTime StartTime { get; set; }
        public DateTime StopTime { get; set; }
        public Guid JobId { get; set; }
        public Guid ClientId { get; set; }
        public string Comments { get; set; }
        public Guid WorkCodeId { get; set; }
        public Guid UserId { get; set; }
        public Guid UnitId { get; set; }
    }
}