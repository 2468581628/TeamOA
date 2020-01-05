using NetcoreInfrastructure.Interface.Repository;
using NetcoreInfrastructure.Interface.Service.Check;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetcoreBll.Check
{
    public class CheckService: ICheckService
    {
        private readonly ICheckRepository _checkRepository;
        public CheckService(ICheckRepository checkRepository)
        {
            _checkRepository = checkRepository;
        }
    }
}
