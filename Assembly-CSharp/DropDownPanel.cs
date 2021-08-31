using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownPanel : UIControlBase
{
	public ScrollRect scrollRect;

	public RectTransform content;

	public PxButton button;

	public List<PxButton> Buttons;

	public Transform buttonParent;
}
