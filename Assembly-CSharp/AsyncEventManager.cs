using System;
using System.Collections.Generic;
using System.Threading;

public class AsyncEventManager
{
	public AsyncEventManager()
	{
		this.m_EventQueue = new Queue<AsyncEvent>();
	}

	public void AddEvent(Action action, string name)
	{
		AsyncEvent item = new AsyncEvent
		{
			action = action,
			name = name
		};
		this.m_EventQueue.Enqueue(item);
	}

	public void Update()
	{
		if (this.m_CurrentEvent != null)
		{
			this.UpdateCurrentEvent();
		}
		if (this.m_CurrentEvent == null && this.m_EventQueue.Count > 0)
		{
			this.m_CurrentEvent = this.m_EventQueue.Dequeue();
		}
	}

	private void UpdateCurrentEvent()
	{
		if (this.thread == null)
		{
			this.thread = new Thread(new ThreadStart(this.m_CurrentEvent.action.Invoke));
			this.thread.Start();
			return;
		}
		if (!this.thread.IsAlive)
		{
			this.m_CurrentEvent = null;
			this.thread = null;
		}
	}

	private Queue<AsyncEvent> m_EventQueue;

	private AsyncEvent m_CurrentEvent;

	private Thread thread;
}
