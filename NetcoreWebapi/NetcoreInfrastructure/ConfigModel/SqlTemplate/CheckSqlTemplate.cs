using System;
using System.Collections.Generic;
using System.Text;

namespace NetcoreInfrastructure.ConfigModel.SqlTemplate
{
    public class CheckSqlTemplate
    {
        public string GetLeave { get; set; }

        public string GetOvertime { get; set; }

        public string GetCost { get; set; }

        public string UpdateLeave { get; set; }

        public string UpdateOvertime { get; set; }

        public string UpdateCost { get; set; }
    }
}
