using System;
using UnityEngine;
using UnityEngine.Playables;

namespace Cinemachine.Examples
{
	public class GenericTrigger : MonoBehaviour
	{
		private void Start()
		{
			this.timeline = base.GetComponent<PlayableDirector>();
		}

		private void OnTriggerExit(Collider c)
		{
			if (c.gameObject.CompareTag("Player"))
			{
				this.timeline.time = 27.0;
			}
		}

		private void OnTriggerEnter(Collider c)
		{
			if (c.gameObject.CompareTag("Player"))
			{
				this.timeline.Stop();
				this.timeline.Play();
			}
		}

		public PlayableDirector timeline;
	}
}
