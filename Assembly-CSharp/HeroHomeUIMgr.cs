using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroHomeUIMgr : MonoBehaviour
{
	private void Start()
	{
		this.InitPanel();
	}

	public void InitPanel()
	{
		List<CardData> list = new List<CardData>();
		foreach (CardData cardData in GameController.getInstance().CardDataModMap.Cards)
		{
			if (cardData.HasTag(TagMap.英雄) && !cardData.ModID.Equals("热心网友"))
			{
				list.Add(cardData);
			}
		}
		using (List<CardData>.Enumerator enumerator = list.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				CardData hero = enumerator.Current;
				Transform transform = UnityEngine.Object.Instantiate<Transform>(this.HeroNameDESC);
				transform.transform.SetParent(this.HeroNameDESC.parent);
				transform.localScale = this.HeroNameDESC.localScale;
				transform.localPosition = this.HeroNameDESC.localPosition;
				transform.localRotation = Quaternion.Euler(Vector3.zero);
				transform.GetChild(0).GetComponent<Text>().text = LocalizationMgr.Instance.GetLocalizationWord(hero.Name);
				transform.name = hero.Name;
				transform.transform.GetComponentInChildren<Button>().onClick.AddListener(delegate()
				{
					this.OnChangeHero(hero.ModID);
				});
				transform.gameObject.SetActive(true);
			}
		}
	}

	private void OnChangeHero(string modID)
	{
		AreaData ad = null;
		ad = GameController.getInstance().AreaDataModMap.getAreaDataByModID(modID + "之家");
		if (ad == null)
		{
			GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_47"), 1f, 2f, 1f, 1f);
			return;
		}
		UnityEngine.Object.Destroy(base.gameObject);
		GameController.ins.UIController.ShowBlackMask(delegate
		{
			GameController.ins.HeroHomeCurrentHeroModID = modID;
			GameController.getInstance().GameEventManager.EnterArea(ad.Name);
			GameController.getInstance().OnTableChange(ad, true);
			GameController.getInstance().MainCamera.SetActive(true);
		}, 0.5f);
	}

	public void OnClose()
	{
		UnityEngine.Object.Destroy(base.gameObject);
	}

	public Transform ContentCanvas;

	public Transform HeroNameDESC;
}
