using System.Collections.Generic;
using TotoMorti.Classes;
using TotoMorti.Models;

namespace TotoMorti.Extensions
{
    public static class UserExtensions
    {
        public static Group CreateNewGroup(this User u)
        {
            return new Group {GroupOwner = u, Users = new List<User> {u}};
        }
    }
}