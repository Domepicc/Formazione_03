using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools_WebApp.Events
{
    public interface IEventHandler<TEvent>
       : IEventHandler
       where TEvent : IEvent
    {
        void Handle(TEvent @event);
    }

    /// <summary>
    /// Marker class
    /// </summary>
    public interface IEventHandler
    {

    }
}
