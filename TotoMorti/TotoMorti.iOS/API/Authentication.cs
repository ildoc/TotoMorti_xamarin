using System;
using TotoMorti.Interfaces;

namespace TotoMorti.iOS.API
{
    internal class Authentication : IAuthentication
    {
        public string Username
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void DeleteCredentials()
        {
            throw new NotImplementedException();
        }

        public bool DoCredentialsExist()
        {
            throw new NotImplementedException();
        }

        public void SaveCredentials(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
