using System;
using System.Collections.Generic;
using System.Text;

namespace NetcoreInfrastructure.ViewModel.Check
{
    public class CheckOvertime
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime DateTime { get; set; }

        public string InputValue { get; set; }

        public string Status { get; set; }
    }
}
