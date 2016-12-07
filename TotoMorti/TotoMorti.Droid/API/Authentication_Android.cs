using System.Linq;
using Java.Lang;
using TotoMorti.Droid.API;
using TotoMorti.Interfaces;
using Xamarin.Auth;
using Xamarin.Forms;

[assembly: Dependency(typeof(Authentication_Android))]

namespace TotoMorti.Droid.API
{
    public class Authentication_Android : Object, IAuthentication
    {
        public string Username
        {
            get
            {
                var account = AccountStore.Create(Forms.Context).FindAccountsForService(App.AppName).FirstOrDefault();
                return account?.Username;
            }
        }

        public void SaveCredentials(string userName, string password)
        {
            if (!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(password))
            {
                var account = new Account
                {
                    Username = userName
                };
                account.Properties.Add("Password", password);
                AccountStore.Create(Forms.Context).Save(account, App.AppName);
            }
        }

        public void DeleteCredentials()
        {
            var account = AccountStore.Create(Forms.Context).FindAccountsForService(App.AppName).FirstOrDefault();
            if (account != null)
                AccountStore.Create(Forms.Context).Delete(account, App.AppName);
        }

        public bool DoCredentialsExist()
        {
            return AccountStore.Create(Forms.Context).FindAccountsForService(App.AppName).Any();
        }
    }
}