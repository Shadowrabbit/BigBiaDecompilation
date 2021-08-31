using System;
using System.Collections;
using System.IO;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PaiPaiArea : MonoBehaviour
{
	public void Init()
	{
	}

	private void Start()
	{
		GameObject gameObject;
		if (string.IsNullOrEmpty(GameController.ins.GameData.PaiPaiBossModelPath))
		{
			gameObject = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/克苏鲁_拍扁用"));
		}
		else
		{
			gameObject = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>(GameController.ins.GameData.PaiPaiBossModelPath));
		}
		gameObject.transform.SetParent(this.Content, false);
		this.PaiPaiModel = gameObject.transform;
		base.StartCoroutine(this.Main());
	}

	private IEnumerator Pai()
	{
		this.PaiPaiQi.SetActive(true);
		this.Effect.Play();
		EffectAudioManager.Instance.PlayEffectAudio(29, null);
		this.PaiPaiModelParent.localScale = new Vector3(1f, 0.001f, 1f);
		this.PaiPaiModelParent.localPosition = new Vector3(-0.17f, 1.71f, 1.049f);
		yield return new WaitForSeconds(2f);
		yield return this.PaiPaiQi.transform.DOLocalJump(new Vector3(11f, 0f, 0f), 3f, 1, 2f, false).WaitForCompletion();
		yield return new WaitForSeconds(1f);
		yield return this.BackForm.DOLocalMoveX(60f, 1f, false).WaitForCompletion();
		this.PaiPaiModelParent.DOLocalRotate(new Vector3(30f, 0f, 0f), 1f, RotateMode.Fast);
		yield return this.PaiPaiModelParent.DOLocalMoveY(4f, 1f, false).WaitForCompletion();
		yield return this.PictureForm.DOLocalMove(new Vector3(0.13f, 1.56f, 0.32f), 1f, false).WaitForCompletion();
		this.PaiPaiModelParent.DOLocalRotate(new Vector3(0f, 0f, 0f), 1f, RotateMode.Fast);
		yield return this.PaiPaiModelParent.DOLocalMoveY(1.71f, 1f, false).WaitForCompletion();
		yield return this.CaptureScreen(GameController.ins.GameData.DungeonGUID);
		yield return new WaitForSeconds(2f);
		this.FullScreenCanvas.SetActive(true);
		yield return this.BlackMask.DOColor(Color.black, 2f).WaitForCompletion();
		yield return this.SubtitleText.rectTransform.DOLocalMoveY(0f, 0.5f, false).SetEase(Ease.InOutBack).WaitForCompletion();
		while (!Input.GetMouseButtonDown(0))
		{
			yield return null;
		}
		SceneManager.LoadScene("Main");
		yield break;
	}

	public IEnumerator Main()
	{
		yield return new WaitForSeconds(3f);
		while (!this.isDone)
		{
			if (Input.GetMouseButtonDown(0))
			{
				this.isDone = true;
				base.StartCoroutine(this.Pai());
			}
			this.HAnchor.Rotate(Vector3.up, Time.deltaTime * 20f);
			this.VAnchor.Rotate(Vector3.right, Time.deltaTime * 21f);
			yield return null;
		}
		yield break;
	}

	public IEnumerator CaptureScreen(string savePath)
	{
		yield return new WaitForEndOfFrame();
		Rect source = new Rect((float)Screen.width * 0.28f, (float)Screen.height * 0.2f, (float)Screen.width * 0.46f, (float)Screen.height * 0.62f);
		Texture2D texture2D = new Texture2D((int)source.width, (int)source.height, TextureFormat.RGB24, false);
		texture2D.filterMode = FilterMode.Point;
		texture2D.ReadPixels(source, 0, 0);
		texture2D.Apply();
		byte[] bytes = texture2D.EncodeToPNG();
		string text = Application.persistentDataPath + "/PaiPai/";
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		File.WriteAllBytes(text + savePath + ".png", bytes);
		yield break;
	}

	public Transform PaiPaiModelParent;

	public Transform HAnchor;

	public Transform VAnchor;

	public Transform PaiPaiModel;

	public Transform Content;

	public Transform PictureForm;

	public Transform BackForm;

	public GameObject FullScreenCanvas;

	public Image BlackMask;

	public TextMeshProUGUI SubtitleText;

	public GameObject PaiPaiQi;

	public ParticleSystem Effect;

	private bool isDone;
}
