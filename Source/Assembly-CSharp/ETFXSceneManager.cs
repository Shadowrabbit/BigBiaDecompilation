using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ETFXSceneManager : MonoBehaviour
{
	public void LoadScene1()
	{
		SceneManager.LoadScene("etfx_explosions");
	}

	public void LoadScene2()
	{
		SceneManager.LoadScene("etfx_explosions2");
	}

	public void LoadScene3()
	{
		SceneManager.LoadScene("etfx_portals");
	}

	public void LoadScene4()
	{
		SceneManager.LoadScene("etfx_magic");
	}

	public void LoadScene5()
	{
		SceneManager.LoadScene("etfx_emojis");
	}

	public void LoadScene6()
	{
		SceneManager.LoadScene("etfx_sparkles");
	}

	public void LoadScene7()
	{
		SceneManager.LoadScene("etfx_fireworks");
	}

	public void LoadScene8()
	{
		SceneManager.LoadScene("etfx_powerups");
	}

	public void LoadScene9()
	{
		SceneManager.LoadScene("etfx_swordcombat");
	}

	public void LoadScene10()
	{
		SceneManager.LoadScene("etfx_maindemo");
	}

	public void LoadScene11()
	{
		SceneManager.LoadScene("etfx_combat");
	}

	public void LoadScene12()
	{
		SceneManager.LoadScene("etfx_2ddemo");
	}

	public void LoadScene13()
	{
		SceneManager.LoadScene("etfx_missiles");
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.L))
		{
			this.GUIHide = !this.GUIHide;
			if (this.GUIHide)
			{
				GameObject.Find("CanvasSceneSelect").GetComponent<Canvas>().enabled = false;
			}
			else
			{
				GameObject.Find("CanvasSceneSelect").GetComponent<Canvas>().enabled = true;
			}
		}
		if (Input.GetKeyDown(KeyCode.J))
		{
			this.GUIHide2 = !this.GUIHide2;
			if (this.GUIHide2)
			{
				GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;
			}
			else
			{
				GameObject.Find("Canvas").GetComponent<Canvas>().enabled = true;
			}
		}
		if (Input.GetKeyDown(KeyCode.H))
		{
			this.GUIHide3 = !this.GUIHide3;
			if (this.GUIHide3)
			{
				GameObject.Find("ParticleSysDisplayCanvas").GetComponent<Canvas>().enabled = false;
				return;
			}
			GameObject.Find("ParticleSysDisplayCanvas").GetComponent<Canvas>().enabled = true;
		}
	}

	public bool GUIHide;

	public bool GUIHide2;

	public bool GUIHide3;
}
