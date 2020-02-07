using NetcoreInfrastructure.Model.Check;
using NetcoreInfrastructure.ViewModel.Check;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetcoreInfrastructure.Interface.Repository
{
    public interface ICheckRepository
    {
        IEnumerable<CheckLeave> GetLeaveData();

        IEnumerable<CheckOvertime> GetOvertimeData();

        IEnumerable<CheckCost> GetCostData();
        int UpdateInfo(CheckStatus info);
    }
}
