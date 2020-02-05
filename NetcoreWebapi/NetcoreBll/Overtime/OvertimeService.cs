using NetcoreInfrastructure.Interface.Repository;
using NetcoreInfrastructure.Interface.Service.Overtime;
using NetcoreInfrastructure.Model;
using NetcoreInfrastructure.ViewModel.Overtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetcoreBll.Overtime
{
    public class OvertimeService: IOvertimeService
    {
        private readonly IOvertimeRepository _overtimeRepository;
        public OvertimeService(IOvertimeRepository overtimeRepository)
        {
            _overtimeRepository = overtimeRepository;
        }

        public int AddOvertime(AddOvertimeVM info, int userID) 
        {
            int data = this._overtimeRepository.AddOvertime(info,userID);
            return data;
        }

        public IEnumerable<OvertimeModel> GetOvertime(int UserId)
        {
            var data = this._overtimeRepository.GetOvertime(UserId);
            return data;
        }

    }
}
