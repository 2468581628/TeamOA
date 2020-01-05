using System;
using System.Collections.Generic;
using System.Text;
using NetcoreInfrastructure.Model;
using NetcoreInfrastructure.ViewModel.Leave;

namespace NetcoreInfrastructure.Interface.Repository
{
    public interface ILeaveRepository
    {
        int AddLeave(AddLeaveVM leaveModel, int id);
        List<LeaveModel> GetLeaveData(int id);
    }
}
