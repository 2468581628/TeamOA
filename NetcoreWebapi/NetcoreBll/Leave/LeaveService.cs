using System;
using System.Collections.Generic;
using System.Text;
using NetcoreInfrastructure.Interface.Repository;
using NetcoreInfrastructure.Interface.Service.Leave;
using NetcoreInfrastructure.Model;
using NetcoreInfrastructure.ViewModel.Leave;

namespace NetcoreBll.Leave
{
    public class LeaveService: ILeaveService
    {
        private readonly ILeaveRepository _leaveRepository;
        public LeaveService(ILeaveRepository leaveRepository)
        {
            _leaveRepository = leaveRepository;
        }

        public int AddLeave(AddLeaveVM leaveModel, int id)
        {
            int code = this._leaveRepository.AddLeave(leaveModel,id);
            return code;
        }

        public IEnumerable<LeaveModel> GetLeaveData(int id)
        {
            List<LeaveModel> list = new List<LeaveModel>();
            list=this._leaveRepository.GetLeaveData(id);
            return list;
        }
    }
}
