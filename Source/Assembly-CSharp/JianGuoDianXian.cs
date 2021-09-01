using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JianGuoDianXian : MonoBehaviour
{
	private void Start()
	{
		this.JianGuo.OnTileMoveEvent += this.OnTileMove;
		this.CheckConnected();
	}

	private void OnDestroy()
	{
		this.JianGuo.OnTileMoveEvent -= this.OnTileMove;
	}

	private void OnTileMove(Transform tar)
	{
		if (base.transform.parent == tar && !tar.name.Equals("Model_2"))
		{
			this.IsPower = false;
		}
		if (tar.name.Equals("Model_2") && !base.transform.parent.name.Equals("Model_2"))
		{
			this.IsPower = false;
		}
		base.StartCoroutine(this.YieldCheck());
	}

	private void Update()
	{
	}

	private void CheckConnected()
	{
		bool flag = false;
		bool flag2 = false;
		if (this.Left.Count > 0)
		{
			foreach (Transform transform in this.Left)
			{
				if ((int)transform.parent.localPosition.z == (int)base.transform.parent.localPosition.z && transform.parent.localPosition.x < base.transform.parent.localPosition.x && base.transform.parent.localPosition.x - transform.parent.localPosition.x < 4f)
				{
					base.transform.GetComponent<Renderer>().material.color = new Color(0.77f, 0.77f, 0.02f);
					transform.transform.GetComponent<Renderer>().material.color = new Color(0.77f, 0.77f, 0.02f);
					if (transform.GetComponent<JianGuoDianXian>().IsPower)
					{
						this.IsPower = true;
						base.transform.GetComponent<Renderer>().material.color = new Color(0.024f, 0.878f, 0f);
					}
					if (this.IsPower)
					{
						base.transform.GetComponent<Renderer>().material.color = new Color(0.024f, 0.878f, 0f);
						transform.GetComponent<JianGuoDianXian>().IsPower = true;
						transform.transform.GetComponent<Renderer>().material.color = new Color(0.024f, 0.878f, 0f);
					}
					if (transform.GetComponent<JianGuoDianXian>().DiZuo != null)
					{
						transform.GetComponent<JianGuoDianXian>().DiZuo.transform.GetComponent<Renderer>().material.color = base.transform.GetComponent<Renderer>().material.color;
						transform.GetComponent<JianGuoDianXian>().DiZuo.IsPower = this.IsPower;
					}
					flag = true;
				}
			}
		}
		if (this.Right.Count > 0)
		{
			foreach (Transform transform2 in this.Right)
			{
				if ((int)transform2.parent.localPosition.z == (int)base.transform.parent.localPosition.z && transform2.parent.localPosition.x > base.transform.parent.localPosition.x && transform2.parent.localPosition.x - base.transform.parent.localPosition.x < 4f)
				{
					base.transform.GetComponent<Renderer>().material.color = new Color(0.77f, 0.77f, 0.02f);
					transform2.transform.GetComponent<Renderer>().material.color = new Color(0.77f, 0.77f, 0.02f);
					if (transform2.GetComponent<JianGuoDianXian>().IsPower)
					{
						this.IsPower = true;
						base.transform.GetComponent<Renderer>().material.color = new Color(0.024f, 0.878f, 0f);
					}
					if (this.IsPower)
					{
						base.transform.GetComponent<Renderer>().material.color = new Color(0.024f, 0.878f, 0f);
						transform2.GetComponent<JianGuoDianXian>().IsPower = true;
						transform2.transform.GetComponent<Renderer>().material.color = new Color(0.024f, 0.878f, 0f);
					}
					if (transform2.GetComponent<JianGuoDianXian>().DiZuo != null)
					{
						transform2.GetComponent<JianGuoDianXian>().DiZuo.transform.GetComponent<Renderer>().material.color = base.transform.GetComponent<Renderer>().material.color;
						transform2.GetComponent<JianGuoDianXian>().DiZuo.IsPower = this.IsPower;
					}
					flag = true;
				}
			}
		}
		if (this.Top.Count > 0)
		{
			foreach (Transform transform3 in this.Top)
			{
				if ((int)transform3.parent.localPosition.x == (int)base.transform.parent.localPosition.x && transform3.parent.localPosition.z > base.transform.parent.localPosition.z && transform3.parent.localPosition.z - base.transform.parent.localPosition.z < 4f)
				{
					base.transform.GetComponent<Renderer>().material.color = new Color(0.77f, 0.77f, 0.02f);
					transform3.transform.GetComponent<Renderer>().material.color = new Color(0.77f, 0.77f, 0.02f);
					if (transform3.GetComponent<JianGuoDianXian>().IsPower)
					{
						this.IsPower = true;
						base.transform.GetComponent<Renderer>().material.color = new Color(0.024f, 0.878f, 0f);
					}
					if (this.IsPower)
					{
						base.transform.GetComponent<Renderer>().material.color = new Color(0.024f, 0.878f, 0f);
						transform3.GetComponent<JianGuoDianXian>().IsPower = true;
						transform3.transform.GetComponent<Renderer>().material.color = new Color(0.024f, 0.878f, 0f);
					}
					if (transform3.GetComponent<JianGuoDianXian>().DiZuo != null)
					{
						transform3.GetComponent<JianGuoDianXian>().DiZuo.transform.GetComponent<Renderer>().material.color = base.transform.GetComponent<Renderer>().material.color;
						transform3.GetComponent<JianGuoDianXian>().DiZuo.IsPower = this.IsPower;
					}
					flag = true;
				}
			}
		}
		if (this.Down.Count > 0)
		{
			foreach (Transform transform4 in this.Down)
			{
				if ((int)transform4.parent.localPosition.x == (int)base.transform.parent.localPosition.x && transform4.parent.localPosition.z < base.transform.parent.localPosition.z && base.transform.parent.localPosition.z - transform4.parent.localPosition.z < 4f)
				{
					base.transform.GetComponent<Renderer>().material.color = new Color(0.77f, 0.77f, 0.02f);
					transform4.transform.GetComponent<Renderer>().material.color = new Color(0.77f, 0.77f, 0.02f);
					if (transform4.GetComponent<JianGuoDianXian>().IsPower)
					{
						this.IsPower = true;
						base.transform.GetComponent<Renderer>().material.color = new Color(0.024f, 0.878f, 0f);
					}
					if (this.IsPower)
					{
						base.transform.GetComponent<Renderer>().material.color = new Color(0.024f, 0.878f, 0f);
						transform4.GetComponent<JianGuoDianXian>().IsPower = true;
						transform4.transform.GetComponent<Renderer>().material.color = new Color(0.024f, 0.878f, 0f);
					}
					if (transform4.GetComponent<JianGuoDianXian>().DiZuo != null)
					{
						transform4.GetComponent<JianGuoDianXian>().DiZuo.transform.GetComponent<Renderer>().material.color = base.transform.GetComponent<Renderer>().material.color;
						transform4.GetComponent<JianGuoDianXian>().DiZuo.IsPower = this.IsPower;
					}
					flag2 = true;
					flag = true;
				}
			}
		}
		if (base.transform.name.Equals("Model 80") && !flag2)
		{
			foreach (Transform transform5 in this.Right)
			{
				if ((int)transform5.parent.localPosition.z == (int)base.transform.parent.localPosition.z && transform5.parent.localPosition.x > base.transform.parent.localPosition.x && transform5.parent.localPosition.x - base.transform.parent.localPosition.x < 4f)
				{
					this.IsPower = false;
					base.transform.GetComponent<Renderer>().material.color = new Color(0.77f, 0.77f, 0.02f);
					transform5.transform.GetComponent<Renderer>().material.color = new Color(0.77f, 0.77f, 0.02f);
					transform5.GetComponent<JianGuoDianXian>().IsPower = this.IsPower;
					if (transform5.GetComponent<JianGuoDianXian>().DiZuo != null)
					{
						transform5.GetComponent<JianGuoDianXian>().DiZuo.transform.GetComponent<Renderer>().material.color = base.transform.GetComponent<Renderer>().material.color;
						transform5.GetComponent<JianGuoDianXian>().DiZuo.IsPower = this.IsPower;
					}
					flag = true;
				}
			}
		}
		if (!flag)
		{
			if (base.transform.parent.name.Equals("Model_2"))
			{
				base.transform.GetComponent<Renderer>().material.color = new Color(0.024f, 0.878f, 0f);
			}
			else
			{
				base.transform.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);
				this.IsPower = false;
			}
		}
		if (this.DiZuo != null)
		{
			this.DiZuo.transform.GetComponent<Renderer>().material.color = base.transform.GetComponent<Renderer>().material.color;
			this.DiZuo.IsPower = this.IsPower;
		}
	}

	private IEnumerator YieldCheck()
	{
		yield return new WaitForSeconds(0.1f);
		this.CheckConnected();
		yield return 1;
		this.CheckConnected();
		yield break;
	}

	public bool IsPower;

	public List<Transform> Left;

	public List<Transform> Right;

	public List<Transform> Top;

	public List<Transform> Down;

	public JianGuoDiZuo DiZuo;

	public JianGuo JianGuo;
}
