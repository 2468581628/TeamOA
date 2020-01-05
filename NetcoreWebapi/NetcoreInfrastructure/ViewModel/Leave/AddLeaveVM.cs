using System;
using System.Collections.Generic;
using System.Text;

namespace NetcoreInfrastructure.ViewModel.Leave
{
    public class AddLeaveVM
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Type { get; set; }

        public string Remark { get; set; }
    }
}
