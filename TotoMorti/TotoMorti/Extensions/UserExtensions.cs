using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotoMorti.Classes;

namespace TotoMorti.Extensions
{
    public static class UserExtensions
    {
        public static Group CreateNewGroup(this User u)
        {
            return new Group() {GroupOwner = u, Users = new List<User>() {u} };
        }
    }
}
