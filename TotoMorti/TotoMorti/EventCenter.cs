using TotoMorti.Models;

namespace TotoMorti
{
    public static class EventCenter
    {
        public static event CelebrityEvent OnCelebrityFormSaved;
        public static event CelebrityEvent OnCelebrityPicked;
        public static event TotoListEvent OnTotoListFormSaved;
        public static event CategoryEvent OnCategoryFormSaved;

        public static void CelebrityFormSaved(Celebrity c)
        {
            OnCelebrityFormSaved?.Invoke(c);
        }

        public static void TotoListFormSaved(TotoList t)
        {
           OnTotoListFormSaved?.Invoke(t);
        }

        public static void CategoryFormSaved(Category c)
        {
            OnCategoryFormSaved?.Invoke(c);
        }

        public static void CelebrityPicked(Celebrity c)
        {
            OnCelebrityPicked?.Invoke(c);
        }
    }
}