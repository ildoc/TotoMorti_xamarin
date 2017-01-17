using TotoMorti.Models;

namespace TotoMorti
{
    public static class EventCenter
    {
        public static event CelebrityEvent OnAddedCelebrity;

        public static void CelebrityAdded(Celebrity c)
        {
            if (OnAddedCelebrity != null)
                OnAddedCelebrity(c);
        }
    }
}