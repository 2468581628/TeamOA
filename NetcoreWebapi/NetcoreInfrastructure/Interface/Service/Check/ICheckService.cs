using NetcoreInfrastructure.ViewModel.Check;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetcoreInfrastructure.Interface.Service.Check
{
    public interface ICheckService
    {
        object GetData(int v);
        int UpdateInfo(CheckStatus info);
    }
}
