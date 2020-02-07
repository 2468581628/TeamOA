using System;
using System.Collections.Generic;
using System.Text;

namespace NetcoreInfrastructure.ViewModel.Check
{
    public class CheckCost
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public DateTime DateTime { get; set; }

        public double CostCount { get; set; }

        public string Type { get; set; }

        public string Status { get; set; }
    }
}
