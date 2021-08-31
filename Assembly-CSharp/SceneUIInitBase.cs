using System;
using System.Collections.Generic;
using PixelCrushers;
using UnityEngine;

public class SceneUIInitBase : MonoBehaviour
{
	public virtual void Start()
	{
		GlobalController instance = GlobalController.Instance;
		instance.OnLanguageChangedEvent = (Action<LanguageType>)Delegate.Combine(instance.OnLanguageChangedEvent, new Action<LanguageType>(this.OnLanguageChanged));
	}

	public virtual void OnLanguageChanged(LanguageType obj)
	{
	}

	public virtual void OnDestroy()
	{
		GlobalController instance = GlobalController.Instance;
		instance.OnLanguageChangedEvent = (Action<LanguageType>)Delegate.Remove(instance.OnLanguageChangedEvent, new Action<LanguageType>(this.OnLanguageChanged));
	}

	public List<UITextField> InitComponents;
}
