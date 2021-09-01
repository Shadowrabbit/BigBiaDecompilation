using System;
using UnityEngine;
using UnityEngine.Events;

namespace Cinemachine.Examples
{
	public class InvokeEventFromInspector : MonoBehaviour
	{
		public void Invoke()
		{
			this.Event.Invoke();
		}

		public UnityEvent Event = new UnityEvent();
	}
}
