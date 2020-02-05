using System;
using System.Collections.Generic;
using System.Text;

namespace NetcoreInfrastructure.Model
{
    public class OvertimeModel
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string InputValue { get; set; }

        public int UserId { get; set; }

        public DateTime DateTime { get; set; }

        public string Status { get; set; }
    }
}
