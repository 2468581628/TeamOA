using NetcoreInfrastructure.Interface.Repository;
using NetcoreInfrastructure.Interface.Service.Cost;
using NetcoreInfrastructure.Model.Cost;
using NetcoreInfrastructure.ViewModel.Cost;
using System.Collections.Generic;

namespace NetcoreBll.Cost
{
    public class CostService: ICostService
    {
        private readonly ICostRepository _costRepository;
        public CostService(ICostRepository costRepository)
        {
            _costRepository = costRepository;
        }

        public object AddCostData(int id, AddCostVM costInfo)
        {
            var data = this._costRepository.AddCostData(id, costInfo);
            return data;
        }

        public IEnumerable<CostModel> GetCostData(int id)
        {
            var data = this._costRepository.GetCostData(id);
            return data;
        }
    }
}
