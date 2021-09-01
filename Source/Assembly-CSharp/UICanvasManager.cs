using System;
using UnityEngine;
using UnityEngine.UI;

public class UICanvasManager : MonoBehaviour
{
	private void Awake()
	{
		UICanvasManager.GlobalAccess = this;
	}

	private void Start()
	{
		if (this.PENameText != null)
		{
			this.PENameText.text = ParticleEffectsLibrary.GlobalAccess.GetCurrentPENameString();
		}
	}

	private void Update()
	{
		if (!this.MouseOverButton && Input.GetMouseButtonUp(0))
		{
			this.SpawnCurrentParticleEffect();
		}
		if (Input.GetKeyUp(KeyCode.A))
		{
			this.SelectPreviousPE();
		}
		if (Input.GetKeyUp(KeyCode.D))
		{
			this.SelectNextPE();
		}
	}

	public void UpdateToolTip(ButtonTypes toolTipType)
	{
		if (this.ToolTipText != null)
		{
			if (toolTipType == ButtonTypes.Previous)
			{
				this.ToolTipText.text = "Select Previous Particle Effect";
				return;
			}
			if (toolTipType == ButtonTypes.Next)
			{
				this.ToolTipText.text = "Select Next Particle Effect";
			}
		}
	}

	public void ClearToolTip()
	{
		if (this.ToolTipText != null)
		{
			this.ToolTipText.text = "";
		}
	}

	private void SelectPreviousPE()
	{
		ParticleEffectsLibrary.GlobalAccess.PreviousParticleEffect();
		if (this.PENameText != null)
		{
			this.PENameText.text = ParticleEffectsLibrary.GlobalAccess.GetCurrentPENameString();
		}
	}

	private void SelectNextPE()
	{
		ParticleEffectsLibrary.GlobalAccess.NextParticleEffect();
		if (this.PENameText != null)
		{
			this.PENameText.text = ParticleEffectsLibrary.GlobalAccess.GetCurrentPENameString();
		}
	}

	private void SpawnCurrentParticleEffect()
	{
		if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out this.rayHit))
		{
			ParticleEffectsLibrary.GlobalAccess.SpawnParticleEffect(this.rayHit.point);
		}
	}

	public void UIButtonClick(ButtonTypes buttonTypeClicked)
	{
		if (buttonTypeClicked == ButtonTypes.Previous)
		{
			this.SelectPreviousPE();
			return;
		}
		if (buttonTypeClicked != ButtonTypes.Next)
		{
			return;
		}
		this.SelectNextPE();
	}

	public static UICanvasManager GlobalAccess;

	public bool MouseOverButton;

	public Text PENameText;

	public Text ToolTipText;

	private RaycastHit rayHit;
}
