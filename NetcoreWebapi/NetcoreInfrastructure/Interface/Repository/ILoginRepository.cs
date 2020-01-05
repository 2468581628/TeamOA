using System;
using System.Collections.Generic;
using System.Text;
using NetcoreInfrastructure.Model;

namespace NetcoreInfrastructure.Interface.Repository
{
    public interface ILoginRepository
    {
        IEnumerable<UserModel> UserLogin(string Account, string Password);
    }
}
