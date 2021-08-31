using System;
using System.Collections;
using UnityEngine;

namespace EpicToonFX
{
	public class ETFXLoopScript : MonoBehaviour
	{
		private void Start()
		{
			this.PlayEffect();
		}

		public void PlayEffect()
		{
			base.StartCoroutine("EffectLoop");
		}

		private IEnumerator EffectLoop()
		{
			GameObject effectPlayer = UnityEngine.Object.Instantiate<GameObject>(this.chosenEffect, base.transform.position, base.transform.rotation);
			if (this.spawnWithoutLight = effectPlayer.GetComponent<Light>())
			{
				effectPlayer.GetComponent<Light>().enabled = false;
			}
			if (this.spawnWithoutSound = effectPlayer.GetComponent<AudioSource>())
			{
				effectPlayer.GetComponent<AudioSource>().enabled = false;
			}
			yield return new WaitForSeconds(this.loopTimeLimit);
			UnityEngine.Object.Destroy(effectPlayer);
			this.PlayEffect();
			yield break;
		}

		public GameObject chosenEffect;

		public float loopTimeLimit = 2f;

		[Header("Spawn without")]
		public bool spawnWithoutLight = true;

		public bool spawnWithoutSound = true;
	}
}
