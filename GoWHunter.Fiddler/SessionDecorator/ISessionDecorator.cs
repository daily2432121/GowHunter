using GoWHunter.Fiddler.SessionTamper;

namespace GoWHunter.Fiddler.SessionDecorator
{
    public interface ISessionDecorator
    {
        void Decorate(ISessionTamper temper);
    }
}