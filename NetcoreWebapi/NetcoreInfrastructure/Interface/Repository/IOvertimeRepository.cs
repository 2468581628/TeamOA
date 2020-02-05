using NetcoreInfrastructure.Model;
using NetcoreInfrastructure.ViewModel.Overtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetcoreInfrastructure.Interface.Repository
{
    public interface IOvertimeRepository
    {
        int AddOvertime(AddOvertimeVM addOvertimeVM, int userID);
        IEnumerable<OvertimeModel> GetOvertime(int userId);
    }
}
