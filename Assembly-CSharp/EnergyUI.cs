using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class EnergyUI : MonoBehaviour
{
	public IEnumerator AddEnergy(EnergyUI.EnergyType type, Transform from)
	{
		SpriteRenderer energyIcon = ModelPoolManager.Instance.SpawnModel("UI/EnergyIcon").GameObject.GetComponent<SpriteRenderer>();
		energyIcon.transform.SetParent(base.transform, false);
		energyIcon.transform.position = from.transform.position;
		energyIcon.color = GameController.RowColor[(int)type];
		energyIcon.transform.DORotate(new Vector3(720f, 0f, 0f), 0.4f, RotateMode.WorldAxisAdd);
		yield return energyIcon.transform.DOJump(base.transform.position + Vector3.right * this.DeltaPosH * (float)GameController.ins.GameData.EnergyList.Count, 1f, 1, 0.2f, false).SetEase(Ease.InExpo).WaitForCompletion();
		this.Energys.Add(energyIcon);
		GameController.ins.GameData.EnergyList.Add((int)type);
		int num = (4 + GlobalController.Instance.AdvanceDataController.GetEWaiNengLiang() > 6) ? 6 : (4 + GlobalController.Instance.AdvanceDataController.GetEWaiNengLiang());
		if (GameController.ins.GameData.EnergyList.Count > num)
		{
			int num2 = GameController.ins.GameData.EnergyList.Count - num;
			for (int i = 0; i < num2; i++)
			{
				GameController.ins.GameData.EnergyList.RemoveAt(0);
				UnityEngine.Object.Destroy(this.Energys[0].gameObject);
				this.Energys.RemoveAt(0);
			}
			foreach (SpriteRenderer spriteRenderer in this.Energys)
			{
				spriteRenderer.transform.DOMoveX(spriteRenderer.transform.position.x - this.DeltaPosH * (float)num2, 0.1f, false).SetEase(Ease.InOutBack);
			}
			yield return new WaitForSeconds(0.05f);
		}
		yield break;
	}

	public void refreshEnery()
	{
		int num = 0;
		foreach (int num2 in GameController.ins.GameData.EnergyList)
		{
			SpriteRenderer component = ModelPoolManager.Instance.SpawnModel("UI/EnergyIcon").GameObject.GetComponent<SpriteRenderer>();
			component.transform.SetParent(base.transform, false);
			int num3 = num2;
			component.color = GameController.RowColor[num3];
			component.transform.position = base.transform.position + Vector3.right * this.DeltaPosH * (float)num++;
			this.Energys.Add(component);
		}
	}

	public IEnumerator RemoveEnergy(EnergyUI.EnergyType type)
	{
		int i = 0;
		while (i < GameController.ins.GameData.EnergyList.Count)
		{
			if (GameController.ins.GameData.EnergyList[i] == (int)type)
			{
				yield return this.Energys[i].transform.DOJump(this.Energys[i].transform.position, 0.3f, 1, 0.2f, false).WaitForCompletion();
				this.Energys[i].gameObject.SetActive(false);
				UnityEngine.Object.Destroy(this.Energys[i]);
				this.Energys.RemoveAt(i);
				List<int> energyList = GameController.ins.GameData.EnergyList;
				int num = i;
				i = num - 1;
				energyList.RemoveAt(num);
				if (i < this.Energys.Count)
				{
					for (int j = i; j < this.Energys.Count; j++)
					{
						this.Energys[j].transform.DOMoveX(this.Energys[j].transform.position.x - this.DeltaPosH, 0.1f, false).SetEase(Ease.InExpo);
					}
					break;
				}
				break;
			}
			else
			{
				int num = i;
				i = num + 1;
			}
		}
		yield return new WaitForSeconds(0.05f);
		yield break;
	}

	public IEnumerator RemoveEnergy(EnergyUI.EnergyType type, Transform transform)
	{
		int i = 0;
		while (i < GameController.ins.GameData.EnergyList.Count)
		{
			if (GameController.ins.GameData.EnergyList[i] == (int)type)
			{
				yield return this.Energys[i].transform.DOJump(transform.position, 0.3f, 1, 0.2f, false).WaitForCompletion();
				this.Energys[i].gameObject.SetActive(false);
				UnityEngine.Object.Destroy(this.Energys[i]);
				this.Energys.RemoveAt(i);
				GameController.ins.GameData.EnergyList.RemoveAt(i);
				if (i < this.Energys.Count)
				{
					for (int j = i; j < this.Energys.Count; j++)
					{
						this.Energys[j].transform.DOMoveX(this.Energys[j].transform.position.x - this.DeltaPosH, 0.1f, false).SetEase(Ease.InExpo);
					}
					yield return new WaitForSeconds(0.11f);
					break;
				}
				break;
			}
			else
			{
				int num = i;
				i = num + 1;
			}
		}
		yield break;
	}

	public int GetEnergyCount(EnergyUI.EnergyType type)
	{
		int num = 0;
		for (int i = 0; i < GameController.ins.GameData.EnergyList.Count; i++)
		{
			if (GameController.ins.GameData.EnergyList[i] == (int)type)
			{
				num++;
			}
		}
		return num;
	}

	private void Start()
	{
		if (GameController.ins.GameData.EnergyList == null)
		{
			GameController.ins.GameData.EnergyList = new List<int>();
		}
	}

	private void Update()
	{
	}

	public Dictionary<EnergyUI.EnergyType, SpriteRenderer> EnergyTypeStackMap = new Dictionary<EnergyUI.EnergyType, SpriteRenderer>();

	public List<SpriteRenderer> Energys = new List<SpriteRenderer>();

	public float DeltaPosH = 0.4f;

	public float DeltaPosV = 0.4f;

	public enum EnergyType
	{
		Yellow = 2,
		Red = 1,
		Blue = 0
	}
}
