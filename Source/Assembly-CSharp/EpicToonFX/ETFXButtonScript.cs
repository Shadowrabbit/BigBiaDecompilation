using System;
using UnityEngine;
using UnityEngine.UI;

namespace EpicToonFX
{
	public class ETFXButtonScript : MonoBehaviour
	{
		private void Start()
		{
			this.effectScript = GameObject.Find("ETFXFireProjectile").GetComponent<ETFXFireProjectile>();
			this.getProjectileNames();
			this.MyButtonText = this.Button.transform.Find("Text").GetComponent<Text>();
			this.MyButtonText.text = this.projectileParticleName;
		}

		private void Update()
		{
			this.MyButtonText.text = this.projectileParticleName;
		}

		public void getProjectileNames()
		{
			this.projectileScript = this.effectScript.projectiles[this.effectScript.currentProjectile].GetComponent<ETFXProjectileScript>();
			this.projectileParticleName = this.projectileScript.projectileParticle.name;
		}

		public bool overButton()
		{
			Rect rect = new Rect(this.buttonsX, this.buttonsY, this.buttonsSizeX, this.buttonsSizeY);
			Rect rect2 = new Rect(this.buttonsX + this.buttonsDistance, this.buttonsY, this.buttonsSizeX, this.buttonsSizeY);
			return rect.Contains(new Vector2(Input.mousePosition.x, (float)Screen.height - Input.mousePosition.y)) || rect2.Contains(new Vector2(Input.mousePosition.x, (float)Screen.height - Input.mousePosition.y));
		}

		public GameObject Button;

		private Text MyButtonText;

		private string projectileParticleName;

		private ETFXFireProjectile effectScript;

		private ETFXProjectileScript projectileScript;

		public float buttonsX;

		public float buttonsY;

		public float buttonsSizeX;

		public float buttonsSizeY;

		public float buttonsDistance;
	}
}
