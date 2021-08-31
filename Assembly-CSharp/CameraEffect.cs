using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraEffect : MonoBehaviour
{
	public IEnumerator ShowBoss()
	{
		int num;
		for (int i = 0; i < 50; i = num + 1)
		{
			this.PostProcessVolume.profile.GetSetting<ColorGrading>().temperature.value -= 1f;
			this.PostProcessVolume.profile.GetSetting<ColorGrading>().saturation.value -= 1f;
			yield return null;
			num = i;
		}
		yield return new WaitForSecondsRealtime(2f);
		for (int i = 0; i < 50; i = num + 1)
		{
			this.PostProcessVolume.profile.GetSetting<ColorGrading>().temperature.value += 1f;
			this.PostProcessVolume.profile.GetSetting<ColorGrading>().saturation.value += 1f;
			yield return null;
			num = i;
		}
		yield return null;
		yield break;
	}

	public IEnumerator GameOver()
	{
		int num;
		for (int i = 0; i < 10; i = num + 1)
		{
			new BoolParameter();
			this.PostProcessVolume.profile.GetSetting<Grain>().active = true;
			this.PostProcessVolume.profile.GetSetting<Grain>().enabled.value = true;
			this.PostProcessVolume.profile.GetSetting<Grain>().SetAllOverridesTo(true, true);
			this.PostProcessVolume.profile.GetSetting<Grain>().intensity.value += 0.1f;
			this.PostProcessVolume.profile.GetSetting<ColorGrading>().saturation.value -= 10f;
			yield return new WaitForSeconds(0.02f);
			num = i;
		}
		yield return new WaitForSecondsRealtime(2f);
		for (int i = 0; i < 10; i = num + 1)
		{
			this.PostProcessVolume.profile.GetSetting<ColorGrading>().saturation.value += 10f;
			this.PostProcessVolume.profile.GetSetting<Grain>().intensity.value -= 0.1f;
			this.PostProcessVolume.profile.GetSetting<Grain>().enabled.value = false;
			this.PostProcessVolume.profile.GetSetting<Grain>().active = false;
			yield return new WaitForSeconds(0.02f);
			num = i;
		}
		yield break;
	}

	public PostProcessVolume PostProcessVolume;

	public GameObject CameraUI;

	public TextMeshProUGUI NameText;

	public TextMeshProUGUI DescText;
}
