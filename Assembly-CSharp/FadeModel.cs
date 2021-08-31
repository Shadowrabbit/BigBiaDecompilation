using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FadeModel
{
	public FadeModel(GameObject model, float fadeTime = 2f)
	{
		this.model = model;
		this.fadeTime = fadeTime;
		MeshRenderer[] componentsInChildren = model.GetComponentsInChildren<MeshRenderer>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			foreach (Material item in componentsInChildren[i].materials)
			{
				if (!this.materials.Contains(item))
				{
					this.materials.Add(item);
				}
			}
		}
	}

	public void HideModel()
	{
		for (int i = 0; i < this.materials.Count; i++)
		{
			Material material = this.materials[i];
			if (material.HasProperty("_Color"))
			{
				Color color = material.color;
				material.color = new Color(color.r, color.g, color.b, 1f);
				this.setMaterialRenderingMode(material, FadeModel.RenderingMode.Fade);
				material.DOColor(new Color(color.r, color.g, color.b, 0f), this.fadeTime);
			}
		}
	}

	public void ShowModel()
	{
		for (int i = 0; i < this.materials.Count; i++)
		{
			Material material = this.materials[i];
			Color color = material.color;
			this.setMaterialRenderingMode(material, FadeModel.RenderingMode.Opaque);
		}
	}

	private void setMaterialRenderingMode(Material material, FadeModel.RenderingMode renderingMode)
	{
		switch (renderingMode)
		{
		case FadeModel.RenderingMode.Opaque:
			material.SetInt("_SrcBlend", 1);
			material.SetInt("_DstBlend", 0);
			material.SetInt("_ZWrite", 1);
			material.DisableKeyword("_ALPHATEST_ON");
			material.DisableKeyword("_ALPHABLEND_ON");
			material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
			material.renderQueue = -1;
			return;
		case FadeModel.RenderingMode.Cutout:
			material.SetInt("_SrcBlend", 1);
			material.SetInt("_DstBlend", 0);
			material.SetInt("_ZWrite", 1);
			material.EnableKeyword("_ALPHATEST_ON");
			material.DisableKeyword("_ALPHABLEND_ON");
			material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
			material.renderQueue = 2450;
			return;
		case FadeModel.RenderingMode.Fade:
			material.SetInt("_SrcBlend", 5);
			material.SetInt("_DstBlend", 10);
			material.SetInt("_ZWrite", 0);
			material.DisableKeyword("_ALPHATEST_ON");
			material.EnableKeyword("_ALPHABLEND_ON");
			material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
			material.renderQueue = 3000;
			return;
		case FadeModel.RenderingMode.Transparent:
			material.SetInt("_SrcBlend", 1);
			material.SetInt("_DstBlend", 10);
			material.SetInt("_ZWrite", 0);
			material.DisableKeyword("_ALPHATEST_ON");
			material.DisableKeyword("_ALPHABLEND_ON");
			material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
			material.renderQueue = 3000;
			return;
		default:
			return;
		}
	}

	private GameObject model;

	private float fadeTime = 2f;

	private List<Material> materials = new List<Material>();

	public enum RenderingMode
	{
		Opaque,
		Cutout,
		Fade,
		Transparent
	}
}
