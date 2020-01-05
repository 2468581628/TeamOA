using System;
using System.Collections.Generic;
using System.Text;

namespace NetcoreInfrastructure.ConfigModel.SqlTemplate
{
    public class MemberSqlTemplate
    {
        public string GetMemberData { get; set; }
        public string InsMemberData { get; set; }
        public string UpdMemberData { get; set; }
        public string UpdPassword { get; set; }
        public string UpdStatus { get; set; }
    }
}
