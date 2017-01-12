namespace TotoMorti
{
    public static class EventCenter
    {
        public static event VoidEvent OnCelebrityFormClosed;

        public static void CelebrityFormClosed()
        {
            OnCelebrityFormClosed?.Invoke();
        }
    }
}