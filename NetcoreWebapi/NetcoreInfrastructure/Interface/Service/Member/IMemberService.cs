using System;
using System.Collections.Generic;
using System.Text;
using NetcoreInfrastructure.Model;
using NetcoreInfrastructure.ViewModel.Member;

namespace NetcoreInfrastructure.Interface.Service.Member
{
    public interface IMemberService
    {
        IEnumerable<MemberModel> GetMemberData();

        int UpdMemberData(UpdMemberVM updMember);

        int InsMemberData(InsMemberVM insMember);

        int UpdPasswordData(UpdPasswordVM updPassword);

        int UpdStatusData(UpdStatusVM updStatus);
    }
}
