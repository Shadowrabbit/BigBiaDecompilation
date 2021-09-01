using System;
using UnityEngine;
using UnityEngine.UI;

public class SliderHandler : MonoBehaviour
{
	private void Start()
	{
		base.transform.GetComponent<Slider>().onValueChanged.AddListener(delegate(float value)
		{
			this.OnSliderValueChanged(value);
		});
	}

	private void OnSliderValueChanged(float value)
	{
		this.TargetScrollbar.value = value;
	}

	public Scrollbar TargetScrollbar;
}
