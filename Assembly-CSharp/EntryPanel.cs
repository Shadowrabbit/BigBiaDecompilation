using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EntryPanel : MonoBehaviour
{
	public Image EntryBgImage;

	public TMP_Text EntryName;

	public TMP_Text EntryDesc;

	[NonSerialized]
	public CardData EntryData;
}
