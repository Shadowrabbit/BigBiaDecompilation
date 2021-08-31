using System;
using UnityEngine;

public class ParticlesModifier : MonoBehaviour
{
	public void ChangeColor(Color c)
	{
		this.obj.GetComponent<ParticleSystem>().main.startColor = c;
	}

	public GameObject obj;
}
