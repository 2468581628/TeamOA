using System;
using System.Collections.Generic;
using System.Text;
using NetcoreInfrastructure.Interface.Repository;
using NetcoreInfrastructure.Interface.Service;
using NetcoreInfrastructure.Model;

namespace NetcoreBll.Login
{
    public class Login: ILoginService
    {
        private readonly ILoginRepository _memberRepository;
        public Login(ILoginRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public IEnumerable<UserModel> UserLogin(string Account, string Password)
        {
            var UserInfo=_memberRepository.UserLogin(Account,Password);
            return UserInfo;
        }
    }
}
