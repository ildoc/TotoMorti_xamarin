namespace TotoMorti.Interfaces
{
    public interface IAuthentication
    {
        string Username { get; }

        void SaveCredentials(string userName, string password);

        void DeleteCredentials();

        bool DoCredentialsExist();
    }
}
