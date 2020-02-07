using NetcoreInfrastructure.Interface.Repository;
using NetcoreInfrastructure.Interface.Service.Check;
using NetcoreInfrastructure.Model.Check;
using NetcoreInfrastructure.ViewModel.Check;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetcoreBll.Check
{
    public class CheckService: ICheckService
    {
        private readonly ICheckRepository _checkRepository;
        public CheckService(ICheckRepository checkRepository)
        {
            _checkRepository = checkRepository;
        }

        public object GetData(int v)
        {
            switch (v)
            {
                case 1: { 
                        IEnumerable<CheckLeave> lsit = this._checkRepository.GetLeaveData();
                        return lsit;
                    }
                case 2: {
                        IEnumerable<CheckOvertime> list = this._checkRepository.GetOvertimeData();
                        return list;
                    }
                case 3: {
                        IEnumerable<CheckCost> list = this._checkRepository.GetCostData();
                        return list;
                    }
            }
            return null;
        }

        public int UpdateInfo(CheckStatus info)
        {
            int data = this._checkRepository.UpdateInfo(info);
            return data;
        }
    }
}
