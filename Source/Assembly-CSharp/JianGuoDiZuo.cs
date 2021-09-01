using System;
using UnityEngine;

public class JianGuoDiZuo : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
		if (this.IsPower)
		{
			if (base.transform.childCount > 0 && base.transform.GetChild(0).GetComponent<JianGuoDianQi>())
			{
				base.transform.GetChild(0).GetComponent<JianGuoDianQi>().IsPower = true;
				if (base.transform.GetChild(0).GetComponent<Animator>())
				{
					base.transform.GetChild(0).GetComponent<Animator>().SetBool("play", true);
				}
				if (base.transform.GetChild(0).name.Equals("电视"))
				{
					this.Jianguo.StartDianShiIe();
				}
				if (base.transform.GetChild(0).GetComponent<JianGuoDianQi>().name.Contains("字母"))
				{
					base.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material.color = new Color(0.08f, 0.69f, 1f);
					return;
				}
			}
		}
		else if (base.transform.childCount > 0 && base.transform.GetChild(0).GetComponent<JianGuoDianQi>())
		{
			base.transform.GetChild(0).GetComponent<JianGuoDianQi>().IsPower = false;
			if (base.transform.GetChild(0).GetComponent<Animator>())
			{
				base.transform.GetChild(0).GetComponent<Animator>().SetBool("play", false);
			}
			if (base.transform.GetChild(0).name.Equals("电视"))
			{
				this.Jianguo.EndDianShiIe();
			}
			if (base.transform.GetChild(0).GetComponent<JianGuoDianQi>().name.Contains("字母"))
			{
				base.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);
			}
		}
	}

	public bool IsPower;

	public bool IsWeiZhi;

	public JianGuo Jianguo;
}
