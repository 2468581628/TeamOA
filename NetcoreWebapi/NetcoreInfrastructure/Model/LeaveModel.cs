using System;
using System.Collections.Generic;
using System.Text;

namespace NetcoreInfrastructure.Model
{
    public class LeaveModel
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Type { get; set; }

        public string Status { get; set; }

        public string Remark { get; set; }

        public int ID { get; set; }
    }
}
