using System;
using UnityEngine;

public class StructureThumbnailPic : MonoBehaviour
{
	private void Start()
	{
		GameController.getInstance().GameEventManager.OnMakeListButtonClickEvent += this.MakeListButtonClick;
	}

	private void Update()
	{
		RaycastHit raycastHit;
		if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit) && raycastHit.collider == this.thumbnailCollider)
		{
			Vector3 vector = raycastHit.point - (this.thumbnailCollider.transform.position - new Vector3(this.thumbnailCollider.size.x / 2f, 0f, this.thumbnailCollider.size.y / 2f));
			int num = (int)(vector.x / this.thumbnailCollider.size.x * (float)this.cardData.StructWidth);
			int num2 = (int)(vector.z / this.thumbnailCollider.size.y * (float)this.cardData.StructHeight);
			if (this.cardData.Struct[num2 * this.cardData.StructWidth + num] != null)
			{
				GameUIController.Instance.OpenTipsByString(this.cardData.Struct[num2 * this.cardData.StructWidth + num], raycastHit.point);
			}
		}
	}

	private void OnGUI()
	{
		GameUIController.Instance.CloseTips();
	}

	public void UpdateThumbnail(CardData cardData)
	{
		this.cardData = cardData;
		if (cardData.StructTexture == null)
		{
			cardData.StructTexture = GameController.getInstance().CardDataModMap.getCardDataByModID(cardData.ModID).StructTexture;
		}
		if (cardData.StructTexture == null)
		{
			return;
		}
		this.thumbnailTexture2D = ImageTools.NormalizeTo256(cardData.StructTexture, new Color32[256], 0);
		Sprite sprite = Sprite.Create(this.thumbnailTexture2D, new Rect(0f, 0f, (float)this.thumbnailTexture2D.width, (float)this.thumbnailTexture2D.height), new Vector2(0.5f, 0.5f), 2f);
		this.ThunbnailSprite.sprite = sprite;
		base.GetComponent<ChartingAct>().TargetStructSprite = this.ThunbnailSprite;
	}

	private void MakeListButtonClick(CardData data)
	{
		this.DraftTableAudioSource.AudioSource.clip = this.DraftTableAudioSource.AudioClipList[5];
		this.DraftTableAudioSource.AudioSource.Play();
		this.UpdateThumbnail(data);
	}

	private void OnDestroy()
	{
		GameController.getInstance().GameEventManager.OnMakeListButtonClickEvent -= this.MakeListButtonClick;
	}

	public SpriteRenderer ThunbnailSprite;

	public SpriteMask ThunbnaiMask;

	public string CurrentCardName;

	public ChartingAct DraftTableAudioSource;

	private Texture2D thumbnailTexture2D;

	private BoxCollider thumbnailCollider;

	private CardData cardData;
}
