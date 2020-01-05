using System;
using System.Collections.Generic;
using System.Text;
using NetcoreInfrastructure.Interface.Repository;
using NetcoreInfrastructure.Interface.Service.Member;
using NetcoreInfrastructure.Model;
using NetcoreInfrastructure.ViewModel.Member;

namespace NetcoreBll.Member
{
    public class MemberService:IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public IEnumerable<MemberModel> GetMemberData()
        {
            var data = this._memberRepository.GetMemberData();
            return data;
        }

        public int UpdMemberData(UpdMemberVM updMember) 
        {
            var data = this._memberRepository.UpdMemberData(updMember);
            return data;
        }

        public int InsMemberData(InsMemberVM insMember)
        {
            var data = this._memberRepository.InsMemberData(insMember);
            return data;
        }

        public int UpdPasswordData(UpdPasswordVM updPassword)
        {
            var data = this._memberRepository.UpdPasswordData(updPassword);
            return data;
        }

        public int UpdStatusData(UpdStatusVM updStatus)
        {
            var data = this._memberRepository.UpdStatusData(updStatus);
            return data;
        }
    }
}
