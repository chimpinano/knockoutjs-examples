using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnockoutJSTest.Models
{
    public class AuthenticatedUsers
    {
        private static List<User> _users = new List<User>
        {
            new User("admin", "admin", null, new List<string> { "::1" } )
        };
        public static List<User> Users { get { return _users; } }
    }
}