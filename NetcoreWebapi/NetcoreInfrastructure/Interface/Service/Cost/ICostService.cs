using System;
using System.Collections.Generic;
using System.Text;
using NetcoreInfrastructure.Model.Cost;
using NetcoreInfrastructure.ViewModel.Cost;

namespace NetcoreInfrastructure.Interface.Service.Cost
{
    public interface ICostService
    {
        object AddCostData(int v, AddCostVM costInfo);
        IEnumerable<CostModel> GetCostData(int id);
    }
}
