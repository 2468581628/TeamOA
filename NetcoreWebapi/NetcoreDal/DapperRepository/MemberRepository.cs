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
using NetcoreInfrastructure.ViewModel.Member;

namespace NetcoreDal.DapperRepository
{
    public class MemberRepository:IMemberRepository
    {
        private readonly string _connectionString;
        private readonly MemberSqlTemplate _memberSqlTemplate;

        public MemberRepository(IConfiguration configuration, IOptions<MemberSqlTemplate> sql)
        {
            _connectionString = configuration.GetConnectionString("MainConnection");
            _memberSqlTemplate = sql.Value;
        }

        public IEnumerable<MemberModel> GetMemberData()
        {
            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    var result = connection.Query<MemberModel>(_memberSqlTemplate.GetMemberData);
                    return result;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                throw;
            }
        }

        public int UpdMemberData(UpdMemberVM updMember)
        {
            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    var result = connection.Execute(_memberSqlTemplate.UpdMemberData,new { USERNAME=updMember.USERNAME, TEL= updMember.TEL, ID = updMember.ID});
                    return result;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                throw;
            }
        }

        public int InsMemberData(InsMemberVM insMember)
        {
            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    var result = connection.Execute(_memberSqlTemplate.InsMemberData, new { USERNAME=insMember.USERNAME,PASSWORD = insMember.PASSWORD,ACCOUNT = insMember.ACCOUNT,TEL = insMember.TEL,STATUS = 1});
                    return result;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                throw;
            }
        }

        public int UpdPasswordData(UpdPasswordVM updPassword)
        {
            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    var result = connection.Execute(_memberSqlTemplate.UpdPassword, new { PASSWORD = updPassword.PASSWORD,ID= updPassword.ID});
                    return result;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                throw;
            }
        }

        public int UpdStatusData(UpdStatusVM updStatus)
        {
            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    var result = connection.Execute(_memberSqlTemplate.UpdStatus, new { ID = updStatus.ID, STATUS = updStatus.STATUS==true?1:0 });
                    return result;
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
