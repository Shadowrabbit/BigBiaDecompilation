using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewspaperController : MonoBehaviour
{
	private void Start()
	{
		this.LastPageObject = base.GetComponentInChildren<LastPage>().gameObject;
		base.GetComponentInChildren<LastPage>().NewspaperController = this;
		this.NextPageObject = base.GetComponentInChildren<NextPage>().gameObject;
		base.GetComponentInChildren<NextPage>().NewspaperController = this;
		this.ExitPageObject = base.GetComponentInChildren<ExitPageBtn>().gameObject;
		base.GetComponentInChildren<ExitPageBtn>().NewspaperController = this;
		this.LastPageObject.gameObject.SetActive(false);
		this.ExitPageObject.gameObject.SetActive(false);
		int num = 0;
		if (this.Newspapers.Count == 1)
		{
			this.NextPageObject.gameObject.SetActive(false);
			this.LastPageObject.gameObject.SetActive(false);
			this.ExitPageObject.gameObject.SetActive(true);
		}
		else
		{
			foreach (GameObject gameObject in this.Newspapers)
			{
				if (num != 0)
				{
					gameObject.SetActive(false);
				}
				else
				{
					gameObject.SetActive(true);
				}
				num++;
			}
		}
		this.Mask = UnityEngine.Object.Instantiate<GameObject>(ResourceManager.Instance.LoadResource("Newspaper/Mask"));
		this.Mask.transform.SetParent(base.transform, true);
	}

	public void LastPage()
	{
		if (this.CurrentPage != 0)
		{
			base.StartCoroutine(this.LastPageAni(this.CurrentPage - 1));
		}
	}

	public void NextPage()
	{
		if (this.CurrentPage != this.Newspapers.Count - 1)
		{
			base.StartCoroutine(this.NextPageAni(this.CurrentPage + 1));
		}
	}

	private IEnumerator LastPageAni(int changeto)
	{
		this.LastPageObject.gameObject.SetActive(false);
		this.NextPageObject.gameObject.SetActive(false);
		this.ExitPageObject.gameObject.SetActive(false);
		this.Newspapers[changeto].transform.position = this.LastTrans.position;
		this.Newspapers[changeto].transform.rotation = this.LastTrans.rotation;
		this.Newspapers[changeto].SetActive(true);
		int num;
		for (int i = 1; i <= 10; i = num + 1)
		{
			this.Newspapers[changeto].transform.position = Vector3.Lerp(this.LastTrans.position, this.Trans.transform.position, (float)i / 10f);
			this.Newspapers[changeto].transform.rotation = Quaternion.Lerp(this.LastTrans.rotation, this.Trans.transform.rotation, (float)i / 10f);
			this.Newspapers[this.CurrentPage].transform.Translate(0f, -0.1f, 0.1f);
			yield return new WaitForSeconds(0.02f);
			num = i;
		}
		if (changeto != 0)
		{
			this.LastPageObject.gameObject.SetActive(true);
		}
		if (changeto != this.Newspapers.Count - 1)
		{
			this.NextPageObject.gameObject.SetActive(true);
		}
		else
		{
			this.ExitPageObject.gameObject.SetActive(true);
		}
		this.Newspapers[this.CurrentPage].SetActive(false);
		this.Newspapers[this.CurrentPage].transform.position = this.Trans.transform.position;
		this.Newspapers[this.CurrentPage].transform.rotation = this.Trans.transform.rotation;
		this.CurrentPage = changeto;
		yield break;
	}

	private IEnumerator NextPageAni(int changeto)
	{
		this.LastPageObject.gameObject.SetActive(false);
		this.NextPageObject.gameObject.SetActive(false);
		this.ExitPageObject.gameObject.SetActive(false);
		this.Newspapers[changeto].transform.Translate(0f, -1f, 1f);
		this.Newspapers[changeto].SetActive(true);
		int num;
		for (int i = 1; i <= 10; i = num + 1)
		{
			this.Newspapers[this.CurrentPage].transform.Translate(-1.5f, 0f, 0f);
			this.Newspapers[this.CurrentPage].transform.Rotate(0f, 0f, 3f);
			this.Newspapers[changeto].transform.Translate(0f, 0.1f, -0.1f);
			yield return new WaitForSeconds(0.02f);
			num = i;
		}
		if (changeto != 0)
		{
			this.LastPageObject.gameObject.SetActive(true);
		}
		if (changeto != this.Newspapers.Count - 1)
		{
			this.NextPageObject.gameObject.SetActive(true);
		}
		else
		{
			this.ExitPageObject.gameObject.SetActive(true);
		}
		this.Newspapers[this.CurrentPage].SetActive(false);
		this.Newspapers[this.CurrentPage].transform.position = this.Trans.transform.position;
		this.Newspapers[this.CurrentPage].transform.rotation = this.Trans.transform.rotation;
		this.CurrentPage = changeto;
		yield break;
	}

	public static string NewspaperID;

	public List<GameObject> Newspapers;

	public GameObject LastPageObject;

	public GameObject NextPageObject;

	public GameObject ExitPageObject;

	public Transform Trans;

	public Transform LastTrans;

	public int CurrentPage;

	public GameObject Mask;
}
