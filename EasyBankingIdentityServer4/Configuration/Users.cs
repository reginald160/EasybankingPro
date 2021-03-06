using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBankingIdentityServer4.Configuration
{
	public static class Users
	{

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                     SubjectId = "1",
                     Username = "alice",
                     Password = "password"
                },
                new TestUser
                {
                     SubjectId = "2",
                     Username = "bob",
                     Password = "password"
                 }
             };
        }
    }
}
