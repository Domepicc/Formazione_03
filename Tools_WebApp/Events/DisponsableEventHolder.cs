using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tools_WebApp.Events
{
    public sealed class DisposableEventsHolder
            : IDisposable
    {
        private readonly IEnumerable<IEventHandler> _handlers;
        private readonly IDisposable _disposable;

        public DisposableEventsHolder(IEnumerable<IEventHandler> handlers, IDisposable disposable = null)
        {
            if (handlers == null)
            {
                throw new ArgumentNullException("Event");
            }

            _handlers = handlers;
            _disposable = disposable;
        }

        public IEnumerable<IEventHandler> Handlers
        {
            get { return _handlers; }
        }

        public void Dispose()
        {
            if (_disposable != null)
            {
                _disposable.Dispose();
            }
        }
    }
}