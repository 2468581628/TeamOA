using System;
using System.Collections.Generic;
using System.Text;

namespace NetcoreInfrastructure.Model.Check
{
    public class CheckLeave
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Type { get; set; }

        public string Status { get; set; }
    }
}
