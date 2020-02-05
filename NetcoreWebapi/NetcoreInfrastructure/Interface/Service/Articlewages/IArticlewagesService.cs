using System;
using System.Collections.Generic;
using System.Text;

namespace NetcoreInfrastructure.Interface.Service.Articlewages
{
    public interface IArticlewagesService
    {
        int ReadExcel(string projectFileName);
    }
}
