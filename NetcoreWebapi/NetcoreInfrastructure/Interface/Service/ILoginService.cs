using System;
using System.Collections.Generic;
using System.Text;
using NetcoreInfrastructure.Model;

namespace NetcoreInfrastructure.Interface.Service
{
    public interface ILoginService
    {
        IEnumerable<UserModel> UserLogin(string Account, string Password);
    }
}
