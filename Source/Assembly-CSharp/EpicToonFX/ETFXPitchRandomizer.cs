using System;
using UnityEngine;

namespace EpicToonFX
{
	public class ETFXPitchRandomizer : MonoBehaviour
	{
		private void Start()
		{
			base.transform.GetComponent<AudioSource>().pitch *= 1f + UnityEngine.Random.Range(-this.randomPercent / 100f, this.randomPercent / 100f);
		}

		public float randomPercent = 10f;
	}
}
