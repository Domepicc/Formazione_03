using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace Tools_WebApp.Events
{
    public static class Events
    {
        /// <summary>
        /// Get or set the trace source used to send traces from events
        /// </summary>
        public static TraceSource TraceSource { get; set; }




        static Func<IEvent, DisposableEventsHolder> _handlersFunction;
 

        /// <summary>
        /// Register the handlers function.
        /// </summary>
        /// <param name="handlersFunction">The 'handlers' function.</param>
        public static void Register(Func<IEvent, DisposableEventsHolder> handlersFunction)
        {
            _handlersFunction = handlersFunction;
        }

        /// <summary>
        /// Publish a new event in the system.
        /// </summary>
        /// <typeparam name="TEvent">The type of event published.</typeparam>
        /// <param name="event">The event instance published.</param>
        public static void Publish<TEvent>(TEvent @event)
            where TEvent : class, IEvent
        {
            if (@event == null)
            {

                throw new ArgumentNullException("Event");
            }

            if (_handlersFunction != null)
            {
                using (var eventsScope = _handlersFunction(@event))
                {
                    foreach (var item in eventsScope.Handlers)
                    {
                        Execute<TEvent>(@event, item);
                    }
                }
            }
            //else
            //{
            //    if (TraceSource != null)
            //    {
            //        TraceSource.TraceEvent(TraceEventType.Warning, 0, Strings.NoEventHandlersRegistered);
            //    }
            //    else
            //        Trace.WriteLine(Strings.NoEventHandlersRegistered);
            //}

        }

        static void Execute<TEvent>(TEvent @event, IEventHandler consumer)
            where TEvent : class, IEvent
        {
            if (TraceSource != null)
            {
               // TraceSource.TraceEvent(TraceEventType.Information, 0, Strings.ExecutingConsumer(consumer.GetType().Name, typeof(TEvent).Name));

                ((IEventHandler<TEvent>)consumer).Handle(@event);

               // TraceSource.TraceEvent(TraceEventType.Information, 0, Strings.ExecutedConsumer(consumer.GetType().Name));
            }
            else
            {
               // Trace.WriteLine((string)Strings.ExecutingConsumer(consumer.GetType().Name, typeof(TEvent).Name));

                ((IEventHandler<TEvent>)consumer).Handle(@event);

               // Trace.WriteLine((string)Strings.ExecutedConsumer(consumer.GetType().Name));
            }
        }
    }
}
