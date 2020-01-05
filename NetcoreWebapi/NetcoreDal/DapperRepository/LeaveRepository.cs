using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;
using NetcoreInfrastructure.ConfigModel.SqlTemplate;
using NetcoreInfrastructure.Interface.Repository;
using NetcoreInfrastructure.Model;
using NetcoreInfrastructure.ViewModel.Leave;

namespace NetcoreDal.DapperRepository
{
    public class LeaveRepository: ILeaveRepository
    {
        private readonly string _connectionString;
        private readonly LeaveSqlTemplate _leaveSqlTemplate;

        public LeaveRepository(IConfiguration configuration, IOptions<LeaveSqlTemplate> sql)
        {
            _connectionString = configuration.GetConnectionString("MainConnection");
            _leaveSqlTemplate = sql.Value;
        }

        public int AddLeave(AddLeaveVM leaveModel, int id)
        {
            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    int result = connection.Execute(_leaveSqlTemplate.AddLeaveData,new { S_DATE=leaveModel.StartTime, E_DATE=leaveModel.EndTime, TYPE = leaveModel.Type,USER_ID=id, RAMARK = leaveModel.Remark, Status="未审核" });
                    return result;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                throw;
            }
        }

        public List<LeaveModel> GetLeaveData(int id)
        {
            List<LeaveModel> list = new List<LeaveModel>();
            try {
                using (var connection = new OracleConnection(_connectionString))
                {
                    list = connection.Query<LeaveModel>(_leaveSqlTemplate.GetLeaveData,new { USER_ID =id}).AsList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                throw;
            }
        }
    }
}
