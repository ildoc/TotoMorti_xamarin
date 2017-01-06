using Microsoft.Practices.ObjectBuilder2;
using TotoMorti.Classes;
using TotoMorti.Models;

namespace TotoMorti.Extensions
{
    public static class GroupExtensions
    {
        public static Session CreateNewSession(this Group g)
        {
            var newSession = new Session {GroupId = g.Id, IsActive = true};
            g.Sessions.ForEach(s => s.IsActive = false);
            g.Sessions.Add(newSession);
            return newSession;
        }
    }
}