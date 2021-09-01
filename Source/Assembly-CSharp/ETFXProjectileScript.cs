using System;
using UnityEngine;

public class ETFXProjectileScript : MonoBehaviour
{
	private void Start()
	{
		this.projectileParticle = UnityEngine.Object.Instantiate<GameObject>(this.projectileParticle, base.transform.position, base.transform.rotation);
		this.projectileParticle.transform.parent = base.transform;
		if (this.muzzleParticle)
		{
			this.muzzleParticle = UnityEngine.Object.Instantiate<GameObject>(this.muzzleParticle, base.transform.position, base.transform.rotation);
			UnityEngine.Object.Destroy(this.muzzleParticle, 1.5f);
		}
	}

	private void OnCollisionEnter(Collision hit)
	{
		if (!this.hasCollided)
		{
			this.hasCollided = true;
			this.impactParticle = UnityEngine.Object.Instantiate<GameObject>(this.impactParticle, base.transform.position, Quaternion.FromToRotation(Vector3.up, this.impactNormal));
			if (hit.gameObject.tag == "Destructible")
			{
				UnityEngine.Object.Destroy(hit.gameObject);
			}
			foreach (GameObject gameObject in this.trailParticles)
			{
				GameObject gameObject2 = base.transform.Find(this.projectileParticle.name + "/" + gameObject.name).gameObject;
				gameObject2.transform.parent = null;
				UnityEngine.Object.Destroy(gameObject2, 3f);
			}
			UnityEngine.Object.Destroy(this.projectileParticle, 3f);
			UnityEngine.Object.Destroy(this.impactParticle, 5f);
			UnityEngine.Object.Destroy(base.gameObject);
			ParticleSystem[] componentsInChildren = base.GetComponentsInChildren<ParticleSystem>();
			for (int j = 1; j < componentsInChildren.Length; j++)
			{
				ParticleSystem particleSystem = componentsInChildren[j];
				if (particleSystem.gameObject.name.Contains("Trail"))
				{
					particleSystem.transform.SetParent(null);
					UnityEngine.Object.Destroy(particleSystem.gameObject, 2f);
				}
			}
		}
	}

	public GameObject impactParticle;

	public GameObject projectileParticle;

	public GameObject muzzleParticle;

	public GameObject[] trailParticles;

	[HideInInspector]
	public Vector3 impactNormal;

	private bool hasCollided;
}
