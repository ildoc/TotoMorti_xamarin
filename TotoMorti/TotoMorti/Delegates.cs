using TotoMorti.Models;

namespace TotoMorti
{
    public delegate void VoidEvent();

    public delegate void CelebrityEvent(Celebrity c);

    public delegate void TotoListEvent(TotoList t);
    public delegate void CategoryEvent(Category c);
}