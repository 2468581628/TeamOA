using System;
using System.Collections.Generic;
using System.Text;
using NetcoreInfrastructure.Interface.Service.Cost;
using NetcoreInfrastructure.Model.Cost;
using NetcoreInfrastructure.ViewModel.Cost;

namespace NetcoreInfrastructure.Interface.Repository
{
    public interface ICostRepository
    {
        object AddCostData(int id, AddCostVM costInfo);
        IEnumerable<CostModel> GetCostData(int id);
    }
}
