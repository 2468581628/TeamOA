using System;
using System.Collections.Generic;
using System.Text;
using NetcoreInfrastructure.Model;
using NetcoreInfrastructure.ViewModel.Leave;

namespace NetcoreInfrastructure.Interface.Service.Leave
{
    public interface ILeaveService
    {
        int AddLeave(AddLeaveVM leaveModel, int id);
        IEnumerable<LeaveModel> GetLeaveData(int id);
    }
}
