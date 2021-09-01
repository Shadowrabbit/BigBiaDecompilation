using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTableTextLabel : MonoBehaviour
{
	private void Start()
	{
	}

	private IEnumerator RefreshText(Text target, int start, int end, int max, Image bar)
	{
		int cur = start;
		while (cur != end)
		{
			if (cur > end)
			{
				int num = cur;
				cur = num - 1;
				target.text = cur.ToString() + "/" + max.ToString();
			}
			else
			{
				int num = cur;
				cur = num + 1;
				target.text = cur.ToString() + "/" + max.ToString();
			}
			bar.fillAmount = (float)cur / (float)max;
			yield return new WaitForSeconds(0.05f);
		}
		target.color = Color.black;
		target.text = end.ToString() + "/" + max.ToString();
		yield return null;
		yield break;
	}

	private void Update()
	{
		if (!GameController.getInstance().GameData.isInDungeon)
		{
			return;
		}
		this.Money.text = GameController.getInstance().GameData.Money.ToString();
		this.FloorLevel.text = GameController.ins.GameData.TorchNum.ToString();
		this.KeyNum.text = GameController.ins.GameData.KeyNum.ToString();
	}

	public void PlayHpParticle()
	{
		string name = "Effect/StateBar_hp";
		ParticlePoolManager.Instance.Spawn(name, 3f).transform.position = this.Money.transform.position + new Vector3(0f, 0.3f, 0f);
	}

	public void PlayMpParticle()
	{
		string name = "Effect/StateBar_mp";
		ParticlePoolManager.Instance.Spawn(name, 3f).transform.position = this.TavernLevel.transform.position + new Vector3(0f, 0.3f, 0f);
	}

	public void PlayAtkParticle()
	{
		string name = "Effect/StateBar_atk";
		ParticlePoolManager.Instance.Spawn(name, 3f).transform.position = this.FloorLevel.transform.position + new Vector3(0f, 0.3f, 0f);
	}

	public void PlayExpParticle()
	{
		string name = "Effect/StateBar_exp";
		ParticlePoolManager.Instance.Spawn(name, 3f).transform.position = this.FloorLevel.transform.position + new Vector3(0f, 0.3f, 0f);
	}

	public Text Name;

	public Text Money;

	public Text TavernLevel;

	public Text FloorLevel;

	public Text KeyNum;
}
