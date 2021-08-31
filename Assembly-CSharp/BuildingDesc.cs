using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingDesc : MonoBehaviour
{
	public void SetBuildingDesc(CardData data)
	{
		this.Data = data;
		this.StateGo.SetActive(false);
		if (data.HasTag(TagMap.玩具))
		{
			this.DescText.text = string.Concat(new string[]
			{
				LocalizationMgr.Instance.GetLocalizationWord("KP_N_" + this.Data.Name),
				"\n[<color=blue>",
				this.Data.Price.ToString(),
				"</color>]  [<color=yellow>",
				this.Data.ATK.ToString(),
				"</color>]"
			});
			return;
		}
		this.DescText.text = string.Concat(new string[]
		{
			LocalizationMgr.Instance.GetLocalizationWord(this.Data.Name),
			"\n[<color=blue>",
			this.Data.Price.ToString(),
			"</color>]  [<color=yellow>",
			this.Data.ATK.ToString(),
			"</color>]"
		});
	}

	public GameObject StateGo;

	public Button BuildingBtn;

	public TMP_Text DescText;

	public CardData Data;
}
