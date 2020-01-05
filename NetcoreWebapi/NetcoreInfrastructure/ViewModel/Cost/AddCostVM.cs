using System;
using System.Collections.Generic;
using System.Text;
using NetcoreInfrastructure.Model.Cost;

namespace NetcoreInfrastructure.ViewModel.Cost
{
    public class AddCostVM
    {
        public string CostType { get; set; }

        public double CostCount { get; set; }

        public CostFileNameModel CostFileName { get; set; }
    }
}
