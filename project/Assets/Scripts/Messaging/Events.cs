using System;
using System.Collections.Generic;

namespace Sophie
{
	public delegate void EventDelegate(params object[] args);

	public static class Events
	{
		private static Dictionary<string,List<EventDelegate>> handlers = new Dictionary<string,List<EventDelegate>>();

		public static void Listen(string eventName, EventDelegate d)
		{
			if (!handlers.ContainsKey (eventName)) 
			{
				handlers[eventName] = new List<EventDelegate>();
			}
			handlers [eventName].Add (d);
		}

		public static void Cancel(string eventName, EventDelegate d)
		{
			if (handlers.ContainsKey (eventName)) 
			{
				handlers[eventName].Remove(d);
			}
		}

		public static void Trigger(string eventName, params object[] args)
		{
			if (!handlers.ContainsKey (eventName))
				return;
			foreach (EventDelegate d in handlers [eventName])
			{
				d.DynamicInvoke(args);
			}
		}
	}
}

