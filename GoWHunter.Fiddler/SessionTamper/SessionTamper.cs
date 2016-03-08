using System;
using Fiddler;
using GoWHunter.Fiddler.SessionDecorator;


namespace GoWHunter.Fiddler.SessionTamper
{
    public class SessionTamper : ISessionTamper
    {
        public Action<Session> Tamp { get; set; }

        public SessionTamper(params ISessionDecorator[] decorators)
        {
            Tamp = TampFunc;
            foreach (var decorator in decorators)
            {
                decorator.Decorate(this);
            }
        }

        private void TampFunc(Session session)
        {
            
        }
    }
}