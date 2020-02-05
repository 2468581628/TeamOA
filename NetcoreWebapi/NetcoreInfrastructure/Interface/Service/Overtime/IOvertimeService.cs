using NetcoreInfrastructure.Model;
using NetcoreInfrastructure.ViewModel.Overtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetcoreInfrastructure.Interface.Service.Overtime
{
    public interface IOvertimeService
    {
        int AddOvertime(AddOvertimeVM info,int userID);
        IEnumerable<OvertimeModel> GetOvertime(int UsetId);
    }
}
