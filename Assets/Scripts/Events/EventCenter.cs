using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;

namespace Events
{
    //  TODO: If the total subscriber count becomes very high, consider dividing subscribers into arrays per interface they implement
    public class EventCenter
    {
        private static readonly EventCenter instance = new EventCenter();

        public interface IDisableable
        {
            bool ReceiveEvents { get; }
        }

        /// <summary>
        /// ////////////////////////////////////////////////ç*çççççççççççççççççççççççççççççççç
        /// </summary>
        /// <typeparam name="TEventHandler"></typeparam>
        public interface IAlwaysFire<TEventHandler> where TEventHandler :  IEventSystemHandler{ }


        // To contain the arguments we need some custom structure
        public struct TwoArguments<T1,T2>
        {
            public T1 Arg1;
            public T2 Arg2;
        }

        public struct ThreeArguments<T1, T2, T3>
        {
            public T1 Arg1;
            public T2 Arg2;
            public T3 Arg3;
        }

        public struct FourArguments<T1, T2, T3, T4>
        {
            public T1 Arg1;
            public T2 Arg2;
            public T3 Arg3;
            public T4 Arg4;
        }

        public struct FiveArguments<T1, T2, T3, T4, T5>
        {
            public T1 Arg1;
            public T2 Arg2;
            public T3 Arg3;
            public T4 Arg4;
            public T5 Arg5;
        }

        public delegate void EventFunction<in T1>(T1 handler);

        public delegate void EventFunction<in T1, in T2>(T1 handler, T2 argument);

        /// <summary>
        /// Enables the subscriber to recieve global events fired via the EventCenter.FireEvent.
        /// Always Call this on Awake. Subscriber will stay subscribed until destroyed.
        /// </summary>
        /// <parm name="subscriber"> The component that wishes to subscribe</parm>
        public static void AddSubscriber(Object subscriber)
        {
            instance.MAddSubscriber(subscriber);
        }

        /// <summary>
        /// DO NOT USE, WILL BE REMOVED.
        /// Removes a subscriber from the list, though this is also done automatically when a subscriber is destroyed.
        /// </summary>
        /// <param name="subscriber"></param>
        public static void RemoveSubscriber(Object subscriber)
        {
            instance.MRemoveSubscriber(subscriber);
        }

        /// <summary>
        /// Fires the event to all subscribers implementing the passed event interface (with no argument). 
        /// Should never be called on Awake.
        /// </summary>
        /// <typeparam name="TEventHandler">The type of event interface fired</typeparam>
        /// <param name="handler">The handler callback</param>
        public static void FireEvent<TEventHandler>(EventFunction<TEventHandler> handler) where TEventHandler : IEventSystemHandler
        {
            instance.MFireEvent(handler);
        }

        /// <summary>
        /// Fires the event to all subscribers implementing the passed event interface, with an argument.
        /// Should never be called on Awake.
        /// </summary>
        /// <typeparam name="TEventHandler">The type of event interface fired</typeparam>
        /// <typeparam name="TArgument">The argument type</typeparam>
        /// <param name="handler">The handler callback</param>
        /// <param name="argument">The argument</param>
        public static void FireEvent<TEventHandler, TArgument>(TArgument argument, EventFunction<TEventHandler, TArgument> handler) where TEventHandler : IEventSystemHandler
        {
            instance.MFireEvent(argument, handler);
        }

        /// <summary>
        /// Fires the event to all subscribers implementing the passed event interface, with a string argument
        /// Should never be called on Awake.
        /// </summary>
        /// <typeparam name="TEventHandler">The type of event interface fired</typeparam>
        /// <param name="handler">The handler callback</param>
        /// <param name="stringArgument">The string argument</param>
        public static void FireEvent<TEventHandler>(string stringArgument, EventFunction<TEventHandler, string> handler) where TEventHandler : IEventSystemHandler
        {
            instance.MFireEvent(stringArgument, handler);
        }

        /// <summary>
        /// Fires the event to all subscribers implementing the passed event interface, with two arguments.
        /// Should never be called on Awake.
        /// </summary>
        /// <typeparam name="TEventHandler">The type of event interface fired</typeparam>
        /// <typeparam name="TArgument1">The first argument type</typeparam>
        /// <typeparam name="TArgument2">The second argument type</typeparam>
        /// <param name="handler">The handler callback</param>
        /// <param name="argument1">The first argument</param>
        /// <param name="argument2">The second argument</param>
        public static void FireEvent<TEventHandler, TArgument1, TArgument2>(TArgument1 argument1, TArgument2 argument2, EventFunction<TEventHandler, TwoArguments<TArgument1, TArgument2>> handler) where TEventHandler : IEventSystemHandler
        {
            instance.MFireEvent(new TwoArguments<TArgument1, TArgument2> { Arg1 = argument1, Arg2 = argument2 }, handler);
        }

        /// <summary>
        /// Fires the event to all subscribers implementing the passed event interface, with three arguments.
        /// Should never be called on Awake.
        /// </summary>
        /// <typeparam name="TEventHandler">The type of event interface fired</typeparam>
        /// <typeparam name="TArgument1">The first argument type</typeparam>
        /// <typeparam name="TArgument2">The second argument type</typeparam>
        /// <typeparam name="TArgument3">The third argument type</typeparam>
        /// <param name="handler">The handler callback</param>
        /// <param name="argument1">The first argument</param>
        /// <param name="argument2">The second argument</param>
        /// <param name="argument3">The third argument</param>
        public static void FireEvent<TEventHandler, TArgument1, TArgument2, TArgument3>(TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, EventFunction<TEventHandler, ThreeArguments<TArgument1, TArgument2, TArgument3>> handler) where TEventHandler : IEventSystemHandler
        {
            instance.MFireEvent(new ThreeArguments<TArgument1, TArgument2, TArgument3> { Arg1 = argument1, Arg2 = argument2, Arg3 = argument3 }, handler);
        }

        /// <summary>
        /// Fires the event to all subscribers implementing the passed event interface, with four arguments.
        /// Should never be called on Awake.
        /// </summary>
        /// <typeparam name="TEventHandler">The type of event interface fired</typeparam>
        /// <typeparam name="TArgument1">The first argument type</typeparam>
        /// <typeparam name="TArgument2">The second argument type</typeparam>
        /// <typeparam name="TArgument3">The third argument type</typeparam>
        /// <typeparam name="TArgument4">The fourth argument type</typeparam>
        /// <param name="handler">The handler callback</param>
        /// <param name="argument1">The first argument</param>
        /// <param name="argument2">The second argument</param>
        /// <param name="argument3">The third argument</param>
        /// <param name="argument4">The fourth argument</param>
        public static void FireEvent<TEventHandler, TArgument1, TArgument2, TArgument3, TArgument4>(TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, EventFunction<TEventHandler, FourArguments<TArgument1, TArgument2, TArgument3, TArgument4>> handler) where TEventHandler : IEventSystemHandler
        {
            instance.MFireEvent(new FourArguments<TArgument1, TArgument2, TArgument3, TArgument4> { Arg1 = argument1, Arg2 = argument2, Arg3 = argument3, Arg4 = argument4 }, handler);
        }

        /// <summary>
        /// Fires the event to all subscribers implementing the passed event interface, with four arguments.
        /// Should never be called on Awake.
        /// </summary>
        /// <typeparam name="TEventHandler">The type of event interface fired</typeparam>
        /// <typeparam name="TArgument1">The first argument type</typeparam>
        /// <typeparam name="TArgument2">The second argument type</typeparam>
        /// <typeparam name="TArgument3">The third argument type</typeparam>
        /// <typeparam name="TArgument4">The fourth argument type</typeparam>
        /// <typeparam name="TArgument5">The fifth argument type</typeparam>
        /// <param name="handler">The handler callback</param>
        /// <param name="argument1">The first argument</param>
        /// <param name="argument2">The second argument</param>
        /// <param name="argument3">The third argument</param>
        /// <param name="argument4">The fourth argument</param>
        /// <param name="argument5">The fifth argument</param>
        public static void FireEvent<TEventHandler, TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>(TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, EventFunction<TEventHandler, FiveArguments<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>> handler) where TEventHandler : IEventSystemHandler
        {
            instance.MFireEvent(new FiveArguments<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5> { Arg1 = argument1, Arg2 = argument2, Arg3 = argument3, Arg4 = argument4, Arg5 = argument5 }, handler);
        }

        private Object[] subscribers = new Object[0];

        private readonly List<Object> _pendingAdd = new List<Object>(2000);

        private readonly List<Object> _pendingRemove = new List<Object>(2000);

        private void MAddSubscriber(Object subscriber)
        {
            if (!(subscriber is IEventSystemHandler) || subscribers.Contains(subscriber)) return;

            _pendingAdd.Add(subscriber);
        }

        private void MRemoveSubscriber(Object subscriber)
        {
            if (!(subscriber is IEventSystemHandler)) return;

            _pendingRemove.Add(subscriber);
        }

        private void MFireEvent<TEventHandler>(EventFunction<TEventHandler> handler) where TEventHandler : IEventSystemHandler
        {
            if (_pendingAdd.Count > 0)
            {
                subscribers = subscribers.Concat(_pendingAdd).ToArray();
                _pendingAdd.Clear();
            }
            if (_pendingRemove.Count > 0 )
            {
                subscribers = subscribers.Except(_pendingRemove).ToArray();
                _pendingRemove.Clear();

            }

            bool hasNull = false;
            var tempSubscribers = subscribers;

            for(int i =0; i<tempSubscribers.Length;i++)
            {
                var subscriber = tempSubscribers[i];
                if(!subscriber)
                {
                    hasNull = true;
                    continue;
                }
                if(!CanFire<TEventHandler>(subscriber))
                {
                    continue;
                }
                var eventSystemHandler = (IEventSystemHandler)tempSubscribers[i];
                handler((TEventHandler)eventSystemHandler);
            }
            if (hasNull)
                RemoveDestroyedSubscribers();

        }

        private void MFireEvent<TEventHandler, TArgument>(TArgument argument, EventFunction<TEventHandler, TArgument> handler) where TEventHandler : IEventSystemHandler
        {

            if (_pendingAdd.Count > 0)
            {
                subscribers = subscribers.Concat(_pendingAdd).ToArray();
                _pendingAdd.Clear();
            }
            if (_pendingRemove.Count > 0)
            {
                subscribers = subscribers.Except(_pendingRemove).ToArray();
                _pendingRemove.Clear();
            }

            bool hasNull = false;
            var tempSubscribers = subscribers;

            for (int i = 0; i < tempSubscribers.Length; i++)
            {
                var subscriber = tempSubscribers[i];
                if (!subscriber)
                {
                    hasNull = true;
                    continue;
                }
                if (!CanFire<TEventHandler>(subscriber))
                {
                    continue;
                }
                var eventSystemHandler = (IEventSystemHandler)tempSubscribers[i];
                handler((TEventHandler)eventSystemHandler,argument);
            }
            if (hasNull)
                RemoveDestroyedSubscribers();
        }

        private static bool CanFire<TEventHandler>(Object component) where TEventHandler : IEventSystemHandler
        {
            if (!(component is TEventHandler))
                return false;
            if(component is IDisableable && !(component as IDisableable).ReceiveEvents)
            {
                return (component is IAlwaysFire<TEventHandler>); // what's this for
            }
            return true;
        }

        private void RemoveDestroyedSubscribers()
        {
            subscribers = subscribers.Where(s => s).ToArray();
#if DEBUG
            Debug.LogWarning(string.Format("Removed destroyed subscribers. New subscriber count: {0}", subscribers.Length));
#endif
        }

#if UNITY_EDITOR
        /// <summary>
        /// The current number of subscribers.
        /// Only exists in the Unity Editor
        /// </summary>
	    public static int SubscriberCount
        {
            get
            {
                int count = 0;
                foreach (var s in instance.subscribers)
                    if (s) count++;
                return count;
            }
        }
#endif
    }
}

