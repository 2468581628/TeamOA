using NetcoreInfrastructure.Model.Articlewages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetcoreInfrastructure.Interface.Repository
{
    public interface IArticlewagesRepository
    {
        int AddArticlewagesInfo(List<ReadArticlewagesModel> data);
        IEnumerable<ReadArticlewagesModel> GetArticlewages(int userId);
    }
}
