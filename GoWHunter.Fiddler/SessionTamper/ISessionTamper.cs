using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fiddler;

namespace GoWHunter.Fiddler.SessionTamper
{
    public interface ISessionTamper
    {
        Action<Session> Tamp { get; set; }

    }
}
