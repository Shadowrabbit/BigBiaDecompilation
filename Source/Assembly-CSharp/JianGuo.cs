using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using HighlightingSystem;
using PixelCrushers.DialogueSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JianGuo : MonoBehaviour
{
	private void Start()
	{
		base.StartCoroutine(this.HpThread());
		base.StartCoroutine(this.StartThread());
		base.StartCoroutine("TarTalk");
	}

	private IEnumerator StartThread()
	{
		yield return new WaitForSeconds(1f);
		DialogueManager.StartConversation("牢房前置");
		yield break;
	}

	private void Update()
	{
		if (!this.isCanTrans)
		{
			return;
		}
		this.CheckDianShi();
		this.CheckZiMu();
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Input.GetMouseButtonDown(0))
		{
			if (this.dragTrans != null)
			{
				this.dragTrans.GetComponent<Highlighter>().constant = false;
			}
			RaycastHit raycastHit;
			if (Physics.Raycast(ray, out raycastHit))
			{
				Collider hittedButton = raycastHit.collider;
				if (!hittedButton.enabled)
				{
					return;
				}
				if (hittedButton == this.Zhentou.GetComponent<Collider>() && !this.isZhenTou)
				{
					this.Zhentou.DOLocalJump(new Vector3(0.3f, 0.26f, 0.251f), 1f, 1, 1f, false);
					this.Zhentou.DORotate(new Vector3(0f, 23.227f, 0f), 1f, RotateMode.Fast).OnComplete(delegate
					{
						this.isZhenTou = true;
					});
				}
				else if (hittedButton == this.YuGang.GetComponent<Collider>())
				{
					if (this.dragTrans == this.Chuizi)
					{
						this.YuGangQueKou.gameObject.SetActive(false);
						this.YuGangQueKou.position = Vector3.one * 10000f;
						this.YuGangYeTi.DOLocalMoveY(-0.072f, 1f, false);
					}
					else
					{
						this.Tip.text = "这太脏了，我不想用手去拿！";
						this.Tip.transform.parent.parent.gameObject.SetActive(true);
					}
				}
				else if (hittedButton == this.ChuangTouGui.GetComponent<Collider>() && !this.isChuangTouGui)
				{
					if (this.dragTrans == this.YaoShi)
					{
						this.YaoShi.SetParent(this.ChuangTouGui);
						this.YaoShi.DORotate(new Vector3(90f, -186.404f, -276.405f), 0.5f, RotateMode.Fast);
						this.YaoShi.DOLocalJump(new Vector3(-0.022f, 0.206f, -0.383f), 0.5f, 1, 0.5f, false).OnComplete(delegate
						{
							this.YaoShi.gameObject.SetActive(false);
							this.ChuangTouGui.DOLocalMove(new Vector3(-0.527f, 0.121f, 0.881f), 0.3f, false).OnComplete(delegate
							{
								this.isChuangTouGui = true;
							});
						});
					}
					else
					{
						this.Tip.text = "锁住了。";
						this.Tip.transform.parent.parent.gameObject.SetActive(true);
					}
				}
				else if (hittedButton == this.GuiZi.GetComponent<Collider>() && !this.isGuiZi)
				{
					this.GuiZi.DORotate(new Vector3(0f, -124.554f, 0f), 0.3f, RotateMode.Fast).OnComplete(delegate
					{
						this.isGuiZi = true;
					});
				}
				else if (hittedButton == this.ZhiTiao.GetComponent<Collider>())
				{
					this.ShowUI.Tip.SetActive(true);
					this.ShowUI.End.SetActive(false);
					this.ShowUI.gameObject.SetActive(true);
				}
				else if (hittedButton == this.ShenQingShu.GetComponent<Collider>())
				{
					this.ShowUI.Tip.SetActive(false);
					this.ShowUI.End.SetActive(true);
					this.ShowUI.gameObject.SetActive(true);
				}
				else if (hittedButton == this.BaoXianMen.GetComponent<Collider>() && this.isBaoXianGuiOpen == 4)
				{
					this.BaoXianMen.DORotate(new Vector3(0f, -114.662f, 0f), 0.3f, RotateMode.Fast).OnComplete(delegate
					{
						this.isBingXiang = true;
					});
				}
				else if (hittedButton == this.BingXiang.GetComponent<Collider>() && !this.isBingXiang)
				{
					if (this.BingXiang.GetComponent<JianGuoDianQi>().IsPower)
					{
						this.BingXiang.DORotate(new Vector3(0f, -70.916f, 0f), 0.3f, RotateMode.Fast).OnComplete(delegate
						{
							this.isBingXiang = true;
						});
					}
				}
				else if (hittedButton == this.BingXiangTi.GetComponent<Collider>() && this.isBingXiang)
				{
					if (this.BingXiang.GetComponent<JianGuoDianQi>().IsPower)
					{
						if (this.dragTrans == this.ShuiTong)
						{
							this.ShuiTong.SetParent(this.BingXiangTi.parent);
							this.ShuiTong.DOLocalJump(this.BingXiangTi.localPosition, 1f, 1, 0.5f, false).OnComplete(delegate
							{
								this.BingXiang.DORotate(new Vector3(0f, 0f, 0f), 0.3f, RotateMode.Fast).OnComplete(delegate
								{
									this.isBingXiang = false;
									this.ShuiTong.gameObject.SetActive(false);
									this.BingKuaiXiao.gameObject.SetActive(true);
								});
							});
						}
						else
						{
							this.BingXiang.DORotate(new Vector3(0f, 0f, 0f), 0.3f, RotateMode.Fast).OnComplete(delegate
							{
								this.isBingXiang = false;
							});
						}
					}
				}
				else if (hittedButton == this.ChengZhongQi.GetComponent<Collider>())
				{
					if (this.dragTrans == this.ShuiTong)
					{
						this.ShuiTong.SetParent(this.ChengZhongQi.transform);
						this.ShuiTong.DOLocalJump(new Vector3(0f, 0.076f, 0f), 0.5f, 1, 0.5f, false);
						base.StartCoroutine("StartTimer");
					}
					else if (this.dragTrans == this.BingKuaiXiao)
					{
						this.BingKuaiXiao.SetParent(this.ChengZhongQi.transform);
						this.BingKuaiXiao.DOLocalJump(new Vector3(0f, 0.076f, 0f), 0.5f, 1, 0.5f, false).OnComplete(delegate
						{
							this.isChengZhongQi = true;
							base.StartCoroutine("StartChengZhong");
						});
					}
					else
					{
						this.Tip.text = "这是一个称重器。";
						this.Tip.transform.parent.parent.gameObject.SetActive(true);
					}
				}
				else if (this.DiZuoList.Contains(hittedButton.transform))
				{
					if (this.dragTrans != null)
					{
						if (hittedButton.transform.childCount == 0)
						{
							this.dragTrans.SetParent(hittedButton.transform);
							this.dragTrans.DOLocalJump(new Vector3(0f, 0.06200001f, 0f), 0.5f, 1, 0.5f, false);
						}
					}
					else if (hittedButton.transform.childCount > 0)
					{
						hittedButton.transform.DORotate(new Vector3(0f, 180f, 0f), 0.5f, RotateMode.Fast).OnComplete(delegate
						{
							if (hittedButton.transform == this.DiZuoList[3] && hittedButton.transform.GetChild(0) == this.DianShi && this.DiZuoList[3].GetComponent<JianGuoDiZuo>().IsPower)
							{
								this.isGanGuang = true;
								this.GanGuangDeng.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);
							}
							hittedButton.transform.DORotate(new Vector3(0f, 0f, 0f), 0.5f, RotateMode.Fast);
						});
					}
					else if (this.dragTrans == null)
					{
						hittedButton.transform.DORotate(new Vector3(0f, 180f, 0f), 0.5f, RotateMode.Fast).OnComplete(delegate
						{
							hittedButton.transform.DORotate(new Vector3(0f, 0f, 0f), 0.5f, RotateMode.Fast);
						});
					}
				}
				else if (hittedButton == this.GanGuangXiang.GetComponent<Collider>())
				{
					if (this.isGanGuang)
					{
						this.GanGuangXiang.DORotate(new Vector3(0f, -136.944f, 0f), 0.5f, RotateMode.Fast).OnComplete(delegate
						{
							this.isGanGuangOpen = true;
						});
					}
					else
					{
						this.Tip.text = "这是一个感光门。";
						this.Tip.transform.parent.parent.gameObject.SetActive(true);
					}
				}
				else if (hittedButton == this.Character.GetComponent<Collider>() && (this.dragTrans == this.XiaoDuYe1 || this.dragTrans == this.XiaoDuYe2 || this.dragTrans == this.XiaoDuYe3))
				{
					GameObject temp = this.dragTrans.gameObject;
					this.dragTrans.DORotate(new Vector3(0f, 132.143f, 13.783f), 0.5f, RotateMode.Fast);
					this.dragTrans.DOJump(this.Character.position + new Vector3(-0.32f, 0f, -0.32f), 0.5f, 1, 0.5f, false).OnComplete(delegate
					{
						this.Character.GetComponent<Animator>().SetTrigger("pain");
						this.Hp += 100;
						this.Hp = ((this.Hp > 100) ? 100 : this.Hp);
						temp.transform.SetParent(this.transform);
						temp.SetActive(false);
						this.dragTrans = null;
					});
				}
				else if (hittedButton == this.Chuizi.GetComponent<Collider>())
				{
					if (this.Bags.Contains(this.Chuizi.parent))
					{
						this.dragTrans = this.Chuizi;
						this.Chuizi.GetComponent<Highlighter>().constant = true;
						this.Tip.text = "一把锤子，很难想象这个东西是怎么带进牢房里来的。";
						this.Tip.transform.parent.parent.gameObject.SetActive(true);
						return;
					}
					this.Chuizi.SetParent(this.GetEmptyBag());
					this.Chuizi.DOLocalJump(Vector3.zero, 1f, 1, 0.5f, false);
					this.Chuizi.DORotate(Vector3.zero, 1f, RotateMode.Fast);
				}
				else if (hittedButton == this.DianShi.GetComponent<Collider>())
				{
					if (this.Bags.Contains(this.DianShi.parent))
					{
						this.dragTrans = this.DianShi;
						this.DianShi.GetComponent<Highlighter>().constant = true;
						this.Tip.text = "一台电视机。";
						this.Tip.transform.parent.parent.gameObject.SetActive(true);
						return;
					}
					if (this.DianShi.parent.name.Equals("底座"))
					{
						this.DianShi.GetComponent<JianGuoDianQi>().IsPower = false;
						if (this.DianShi.GetComponent<Animator>())
						{
							this.DianShi.GetComponent<Animator>().SetBool("play", false);
						}
						this.EndDianShiIe();
					}
					this.DianShi.SetParent(this.GetEmptyBag());
					this.DianShi.DOLocalJump(Vector3.zero, 1f, 1, 0.5f, false);
					this.DianShi.DORotate(Vector3.zero, 1f, RotateMode.Fast);
				}
				else if (hittedButton == this.FengShan.GetComponent<Collider>())
				{
					if (this.Bags.Contains(this.FengShan.parent))
					{
						this.dragTrans = this.FengShan;
						this.FengShan.GetComponent<Highlighter>().constant = true;
						this.Tip.text = "一个电风扇。";
						this.Tip.transform.parent.parent.gameObject.SetActive(true);
						return;
					}
					if (this.FengShan.parent.name.Equals("底座"))
					{
						this.FengShan.GetComponent<JianGuoDianQi>().IsPower = false;
						if (this.FengShan.GetComponent<Animator>())
						{
							this.FengShan.GetComponent<Animator>().SetBool("play", false);
						}
					}
					this.FengShan.SetParent(this.GetEmptyBag());
					this.FengShan.DOLocalJump(Vector3.zero, 1f, 1, 0.5f, false);
					this.FengShan.DORotate(Vector3.zero, 1f, RotateMode.Fast);
				}
				else if (hittedButton == this.ZiMuM.GetComponent<Collider>())
				{
					if (this.Bags.Contains(this.ZiMuM.parent))
					{
						this.dragTrans = this.ZiMuM;
						this.ZiMuM.GetComponent<Highlighter>().constant = true;
						this.Tip.text = "字母M。";
						this.Tip.transform.parent.parent.gameObject.SetActive(true);
						return;
					}
					if (this.ZiMuM.parent.name.Equals("底座"))
					{
						this.ZiMuM.GetComponent<JianGuoDianQi>().IsPower = false;
						this.ZiMuM.GetChild(0).GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);
					}
					this.ZiMuM.SetParent(this.GetEmptyBag());
					this.ZiMuM.DOLocalJump(Vector3.zero, 1f, 1, 0.5f, false);
					this.ZiMuM.DOScale(Vector3.one, 0.5f);
					this.ZiMuM.DORotate(Vector3.zero, 1f, RotateMode.Fast);
				}
				else if (hittedButton == this.ZiMuO.GetComponent<Collider>())
				{
					if (this.Bags.Contains(this.ZiMuO.parent))
					{
						this.dragTrans = this.ZiMuO;
						this.ZiMuO.GetComponent<Highlighter>().constant = true;
						this.Tip.text = "字母O。";
						this.Tip.transform.parent.parent.gameObject.SetActive(true);
						return;
					}
					if (this.ZiMuO.parent.name.Equals("底座"))
					{
						this.ZiMuO.GetComponent<JianGuoDianQi>().IsPower = false;
						this.ZiMuO.GetChild(0).GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);
					}
					this.ZiMuO.SetParent(this.GetEmptyBag());
					this.ZiMuO.DOLocalJump(Vector3.zero, 1f, 1, 0.5f, false);
					this.ZiMuO.DOScale(Vector3.one, 0.5f);
					this.ZiMuO.DORotate(Vector3.zero, 1f, RotateMode.Fast);
				}
				else if (hittedButton == this.ZiMuN.GetComponent<Collider>())
				{
					if (this.Bags.Contains(this.ZiMuN.parent))
					{
						this.dragTrans = this.ZiMuN;
						this.ZiMuN.GetComponent<Highlighter>().constant = true;
						this.Tip.text = "字母N。";
						this.Tip.transform.parent.parent.gameObject.SetActive(true);
						return;
					}
					if (this.ZiMuN.parent.name.Equals("底座"))
					{
						this.ZiMuN.GetComponent<JianGuoDianQi>().IsPower = false;
						this.ZiMuN.GetChild(0).GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);
					}
					this.ZiMuN.SetParent(this.GetEmptyBag());
					this.ZiMuN.DOLocalJump(Vector3.zero, 1f, 1, 0.5f, false);
					this.ZiMuN.DORotate(Vector3.zero, 1f, RotateMode.Fast);
				}
				else if (hittedButton == this.ZiMuR.GetComponent<Collider>())
				{
					if (this.Bags.Contains(this.ZiMuR.parent))
					{
						this.dragTrans = this.ZiMuR;
						this.ZiMuR.GetComponent<Highlighter>().constant = true;
						this.Tip.text = "字母B。";
						this.Tip.transform.parent.parent.gameObject.SetActive(true);
						return;
					}
					if (this.ZiMuR.parent.name.Equals("底座"))
					{
						this.ZiMuR.GetComponent<JianGuoDianQi>().IsPower = false;
						this.ZiMuR.GetChild(0).GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);
					}
					this.ZiMuR.SetParent(this.GetEmptyBag());
					this.ZiMuR.DOLocalJump(Vector3.zero, 1f, 1, 0.5f, false);
					this.ZiMuR.DORotate(Vector3.zero, 1f, RotateMode.Fast);
				}
				else if (hittedButton == this.WeiZhi.GetComponent<Collider>())
				{
					if (this.Bags.Contains(this.WeiZhi.parent))
					{
						this.dragTrans = this.WeiZhi;
						this.WeiZhi.GetComponent<Highlighter>().constant = true;
						this.Tip.text = "这是一个风动装置。";
						this.Tip.transform.parent.parent.gameObject.SetActive(true);
						return;
					}
					if (this.dragTrans != null)
					{
						if (this.dragTrans.name.Contains("字母"))
						{
							this.dragTrans.SetParent(this.WeiZhi.parent);
							this.dragTrans.SetAsFirstSibling();
							this.dragTrans.DOJump(this.WeiZhi.position + new Vector3(0f, 0f, 0f), 1f, 1, 0.5f, false);
						}
						else
						{
							this.Tip.text = "应该不是这个东西。";
						}
					}
					else
					{
						if (this.WeiZhi.childCount > 0)
						{
							return;
						}
						this.WeiZhi.SetParent(this.GetEmptyBag());
						this.WeiZhi.DOLocalJump(Vector3.zero, 1f, 1, 0.5f, false);
						this.WeiZhi.DORotate(Vector3.zero, 1f, RotateMode.Fast);
					}
				}
				else if (hittedButton == this.ShuiTong.GetComponent<Collider>())
				{
					if (this.Bags.Contains(this.ShuiTong.parent))
					{
						this.dragTrans = this.ShuiTong;
						this.ShuiTong.GetComponent<Highlighter>().constant = true;
						this.Tip.text = "一个水桶。";
						this.Tip.transform.parent.parent.gameObject.SetActive(true);
						return;
					}
					if (this.ShuiTong.parent.name.Equals("称重器"))
					{
						base.StopCoroutine("StartTimer");
						this.ChengZhongQiText.text = "";
					}
					this.ShuiTong.SetParent(this.GetEmptyBag());
					this.ShuiTong.DOLocalJump(Vector3.zero, 1f, 1, 0.5f, false);
					this.ShuiTong.DORotate(Vector3.zero, 1f, RotateMode.Fast);
				}
				else if (hittedButton == this.BingKuaiXiao.GetComponent<Collider>())
				{
					if (this.Bags.Contains(this.BingKuaiXiao.parent))
					{
						this.dragTrans = this.BingKuaiXiao;
						this.BingKuaiXiao.GetComponent<Highlighter>().constant = true;
						this.Tip.text = "一块小冰块。";
						this.Tip.transform.parent.parent.gameObject.SetActive(true);
						return;
					}
					if (this.BingKuaiXiao.parent.name.Equals("称重器"))
					{
						base.StopCoroutine("StartChengZhong");
						this.ChengZhongQiText.text = "";
						this.isChengZhongQi = false;
					}
					this.BingKuaiXiao.SetParent(this.GetEmptyBag());
					this.BingKuaiXiao.DOLocalJump(Vector3.zero, 1f, 1, 0.5f, false);
					this.BingKuaiXiao.DORotate(Vector3.zero, 1f, RotateMode.Fast);
				}
				else if (hittedButton == this.BingKuaiDa.GetComponent<Collider>())
				{
					if (this.Bags.Contains(this.BingKuaiDa.parent))
					{
						this.dragTrans = this.BingKuaiDa;
						this.BingKuaiDa.GetComponent<Highlighter>().constant = true;
						this.Tip.text = "一块大冰块。";
						this.Tip.transform.parent.parent.gameObject.SetActive(true);
						return;
					}
					this.BingKuaiDa.SetParent(this.GetEmptyBag());
					this.BingKuaiDa.DOLocalJump(Vector3.zero, 1f, 1, 0.5f, false);
					this.BingKuaiDa.DORotate(Vector3.zero, 1f, RotateMode.Fast);
				}
				else if (hittedButton == this.YaoShi.GetComponent<Collider>())
				{
					if (this.Bags.Contains(this.YaoShi.parent))
					{
						this.dragTrans = this.YaoShi;
						this.YaoShi.GetComponent<Highlighter>().constant = true;
						this.Tip.text = "一把钥匙。";
						this.Tip.transform.parent.parent.gameObject.SetActive(true);
						return;
					}
					this.YaoShi.SetParent(this.GetEmptyBag());
					this.YaoShi.DOLocalJump(Vector3.zero, 1f, 1, 0.5f, false);
					this.YaoShi.DORotate(Vector3.zero, 1f, RotateMode.Fast);
				}
				else if (hittedButton == this.DianCiLu.GetComponent<Collider>())
				{
					if (this.Bags.Contains(this.DianCiLu.parent))
					{
						this.dragTrans = this.DianCiLu;
						this.DianCiLu.GetComponent<Highlighter>().constant = true;
						this.Tip.text = "一个电磁炉。";
						this.Tip.transform.parent.parent.gameObject.SetActive(true);
						return;
					}
					if (this.dragTrans == this.BingKuaiDa)
					{
						this.BingKuaiDa.DOJump(this.DianCiLu.position + new Vector3(0f, 0.15f, 0f), 1f, 1, 0.5f, false).OnComplete(delegate
						{
							this.BingKuaiDa.SetParent(this.DianCiLu.GetChild(0));
						});
					}
					else
					{
						if (this.DianCiLu.GetChild(0).childCount > 0)
						{
							return;
						}
						if (this.DianCiLu.parent.name.Equals("底座"))
						{
							this.DianCiLu.GetComponent<JianGuoDianQi>().IsPower = false;
							if (this.DianCiLu.GetComponent<Animator>())
							{
								this.DianCiLu.GetComponent<Animator>().SetBool("play", false);
							}
						}
						this.DianCiLu.SetParent(this.GetEmptyBag());
						this.DianCiLu.DOLocalJump(Vector3.zero, 1f, 1, 0.5f, false);
						this.DianCiLu.DORotate(Vector3.zero, 1f, RotateMode.Fast);
					}
				}
				else if (hittedButton == this.XiaoDuYe1.GetComponent<Collider>())
				{
					if (this.Bags.Contains(this.XiaoDuYe1.parent))
					{
						this.dragTrans = this.XiaoDuYe1;
						this.XiaoDuYe1.GetComponent<Highlighter>().constant = true;
						this.Tip.text = "一支消毒针剂。";
						this.Tip.transform.parent.parent.gameObject.SetActive(true);
						return;
					}
					this.XiaoDuYe1.SetParent(this.GetEmptyBag());
					this.XiaoDuYe1.DOLocalJump(Vector3.zero, 1f, 1, 0.5f, false);
					this.XiaoDuYe1.DOScale(Vector3.one, 0.3f);
					this.XiaoDuYe1.DORotate(Vector3.zero, 1f, RotateMode.Fast);
				}
				else if (hittedButton == this.XiaoDuYe2.GetComponent<Collider>())
				{
					if (this.Bags.Contains(this.XiaoDuYe2.parent))
					{
						this.dragTrans = this.XiaoDuYe2;
						this.XiaoDuYe2.GetComponent<Highlighter>().constant = true;
						this.Tip.text = "一支消毒针剂。";
						this.Tip.transform.parent.parent.gameObject.SetActive(true);
						return;
					}
					this.XiaoDuYe2.SetParent(this.GetEmptyBag());
					this.XiaoDuYe2.DOLocalJump(Vector3.zero, 1f, 1, 0.5f, false);
					this.XiaoDuYe2.DOScale(Vector3.one, 0.3f);
					this.XiaoDuYe2.DORotate(Vector3.zero, 1f, RotateMode.Fast);
				}
				else if (hittedButton == this.XiaoDuYe3.GetComponent<Collider>())
				{
					if (this.Bags.Contains(this.XiaoDuYe3.parent))
					{
						this.dragTrans = this.XiaoDuYe3;
						this.XiaoDuYe3.GetComponent<Highlighter>().constant = true;
						this.Tip.text = "一支消毒针剂。";
						this.Tip.transform.parent.parent.gameObject.SetActive(true);
						return;
					}
					this.XiaoDuYe3.SetParent(this.GetEmptyBag());
					this.XiaoDuYe3.DOLocalJump(Vector3.zero, 1f, 1, 0.5f, false);
					this.XiaoDuYe3.DOScale(Vector3.one, 0.3f);
					this.XiaoDuYe3.DORotate(Vector3.zero, 1f, RotateMode.Fast);
				}
				else if (this.Buttons.Contains(hittedButton.transform))
				{
					this.OnTileMove(hittedButton.transform.parent);
				}
				if (this.dragTrans != null)
				{
					this.dragTrans.GetComponent<Highlighter>().constant = false;
					this.dragTrans = null;
					this.Tip.text = "";
					this.Tip.transform.parent.parent.gameObject.SetActive(false);
				}
			}
		}
	}

	private Transform GetEmptyBag()
	{
		foreach (Transform transform in this.Bags)
		{
			if (transform.childCount == 0)
			{
				return transform;
			}
		}
		return null;
	}

	private IEnumerator EndThread()
	{
		yield return new WaitForSeconds(2f);
		DialogueManager.StartConversation("密室结束");
		yield break;
	}

	private IEnumerator TarTalk()
	{
		for (;;)
		{
			if (!this.isTalk)
			{
				yield return new WaitForSeconds(10f);
				this.isTalk = true;
				if (this.Hp > 50)
				{
					this.Talk.text = this.TalkList1[UnityEngine.Random.Range(0, this.TalkList1.Count - 1)];
				}
				else
				{
					this.Talk.text = this.TalkList1[this.TalkList1.Count - 1];
				}
				this.Talk.transform.parent.parent.gameObject.SetActive(true);
				yield return new WaitForSeconds(6f);
				this.Talk.transform.parent.parent.gameObject.SetActive(false);
				this.Talk.text = "";
				this.isTalk = false;
			}
		}
		yield break;
	}

	private void OnTileMove(Transform tile)
	{
		this.isCanTrans = false;
		Vector3 vector = Vector3.zero;
		for (int i = 0; i < this.tileMapVec.Count; i++)
		{
			if (this.tileMapVec[i] == tile.localPosition)
			{
				List<int> indexs = this.neighborDic[i];
				vector = this.CheckEmptyTile(indexs);
				break;
			}
		}
		if (vector != Vector3.zero)
		{
			tile.DOLocalMove(vector, 1f, false).OnComplete(delegate
			{
				this.isCanTrans = true;
				this.TileMoveEvent(tile);
			});
			return;
		}
		this.isCanTrans = true;
	}

	private Vector3 CheckEmptyTile(List<int> indexs)
	{
		Vector3 vector = Vector3.zero;
		foreach (int index in indexs)
		{
			foreach (Transform transform in this.Buttons)
			{
				if (this.tileMapVec[index] == transform.parent.localPosition)
				{
					vector = Vector3.zero;
					break;
				}
				vector = this.tileMapVec[index];
			}
			if (vector != Vector3.zero)
			{
				return vector;
			}
		}
		return vector;
	}

	public event Action<Transform> OnTileMoveEvent;

	public void TileMoveEvent(Transform tar)
	{
		Action<Transform> onTileMoveEvent = this.OnTileMoveEvent;
		if (onTileMoveEvent == null)
		{
			return;
		}
		onTileMoveEvent(tar);
	}

	private IEnumerator StartTimer()
	{
		int num2;
		for (int i = 0; i < 13; i = num2 + 1)
		{
			int num = i % 13;
			if (num < 11)
			{
				this.ChengZhongQiText.text = "<color=green>" + num.ToString() + "</color>";
			}
			else
			{
				this.ChengZhongQiText.text = "<color=red>" + num.ToString() + "</color>";
			}
			yield return new WaitForSeconds(0.1f);
			num2 = i;
		}
		yield break;
	}

	private IEnumerator StartChengZhong()
	{
		int num2;
		for (int i = 0; i < 11; i = num2 + 1)
		{
			int num = i % 11;
			if (num < 11)
			{
				this.ChengZhongQiText.text = "<color=green>" + num.ToString() + "</color>";
			}
			yield return new WaitForSeconds(0.1f);
			num2 = i;
		}
		this.ChengZhongQiMen.DORotate(new Vector3(0f, -91.135f, 0f), 0.5f, RotateMode.Fast);
		yield break;
	}

	private IEnumerator StartDianshi()
	{
		if (this.isDianshi)
		{
			yield break;
		}
		int i = 0;
		this.isDianshi = true;
		for (;;)
		{
			this.DianShiQiText.text = this.answers[i % this.answers.Count];
			yield return new WaitForSeconds(0.8f);
			int num = i;
			i = num + 1;
		}
		yield break;
	}

	private void CheckDianShi()
	{
		if (this.DiZuoList[3].childCount > 0)
		{
			if (this.DiZuoList[3].GetChild(0).name.Equals("电扇") && this.DiZuoList[3].GetComponent<JianGuoDiZuo>().IsPower)
			{
				if (this.DiZuoList[4].childCount <= 1)
				{
					this.DiZuoList[4].DORotate(new Vector3(0f, 0f, 0f), 0.5f, RotateMode.Fast);
					return;
				}
				if (this.DiZuoList[4].GetChild(1).name.Equals("未知装置"))
				{
					this.DiZuoList[4].DORotate(new Vector3(0f, 180f, 0f), 0.5f, RotateMode.Fast).OnComplete(delegate
					{
						if (this.DiZuoList[4].GetChild(0).name.Contains("字母"))
						{
							this.DiZuoList[4].GetChild(0).GetComponent<JianGuoDianQi>().IsPower = true;
						}
						if (this.DiZuoList[4].GetChild(0).name.Equals("字母M") && this.DiZuoList[4].GetComponent<JianGuoDiZuo>().IsPower)
						{
							this.isW = true;
						}
					});
					return;
				}
			}
		}
		else
		{
			this.DiZuoList[4].DORotate(new Vector3(0f, 0f, 0f), 0.5f, RotateMode.Fast);
			this.isW = false;
		}
	}

	private void CheckZiMu()
	{
		if (this.ZiMuList[1].IsPower && this.ZiMuList[3].IsPower && this.ZiMuList[6].IsPower && !this.isFirst)
		{
			this.isFirst = true;
			this.BaoXianGui(0);
		}
		if (this.ZiMuList[0].IsPower && this.ZiMuList[1].IsPower && this.ZiMuList[2].IsPower && !this.isSecond)
		{
			this.isSecond = true;
			this.BaoXianGui(1);
		}
		if (this.ZiMuList[4].IsPower && this.ZiMuList[5].IsPower && !this.isThird)
		{
			this.isThird = true;
			this.BaoXianGui(2);
		}
		if (this.ZiMuList[2].IsPower && this.isW && !this.isFour)
		{
			this.isFour = true;
			this.BaoXianGui(3);
		}
	}

	private void BaoXianGui(int index)
	{
		TweenCallback <>9__3;
		TweenCallback <>9__2;
		TweenCallback <>9__1;
		this.DengList[0].GetComponent<Renderer>().material.DOColor(new Color(1f, 1f, 1f), 1f).OnComplete(delegate
		{
			TweenerCore<Color, Color, ColorOptions> t = this.DengList[1].GetComponent<Renderer>().material.DOColor(new Color(1f, 1f, 1f), 1f);
			TweenCallback action;
			if ((action = <>9__1) == null)
			{
				action = (<>9__1 = delegate()
				{
					TweenerCore<Color, Color, ColorOptions> t2 = this.DengList[2].GetComponent<Renderer>().material.DOColor(new Color(1f, 1f, 1f), 1f);
					TweenCallback action2;
					if ((action2 = <>9__2) == null)
					{
						action2 = (<>9__2 = delegate()
						{
							TweenerCore<Quaternion, Vector3, QuaternionOptions> t3 = this.FeTiaoList[index].DORotate(new Vector3(0f, 111.936f, 0f), 0.5f, RotateMode.Fast);
							TweenCallback action3;
							if ((action3 = <>9__3) == null)
							{
								action3 = (<>9__3 = delegate()
								{
									this.DengList[0].GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f);
									this.DengList[1].GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f);
									this.DengList[2].GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f);
								});
							}
							t3.OnComplete(action3);
							this.isBaoXianGuiOpen++;
						});
					}
					t2.OnComplete(action2);
				});
			}
			t.OnComplete(action);
		});
	}

	public void StartDianShiIe()
	{
		base.StartCoroutine("StartDianshi");
	}

	public void EndDianShiIe()
	{
		base.StopCoroutine("StartDianshi");
		this.isDianshi = false;
		this.DianShiQiText.text = "";
	}

	private IEnumerator HpThread()
	{
		while (this.Hp > 0)
		{
			if (this.Hp < 50)
			{
				this.Character.GetComponent<Animator>().SetBool("beDying", true);
			}
			else
			{
				this.Character.GetComponent<Animator>().SetBool("beDying", false);
			}
			this.HpImage.fillAmount = (float)this.Hp / 100f;
			this.HpText.text = this.Hp.ToString() + "/100";
			yield return new WaitForSeconds(3f);
			this.Hp--;
		}
		Debug.Log("Game Over!");
		base.StopCoroutine("TarTalk");
		yield break;
	}

	public List<Transform> Bags;

	public Transform DianShi;

	public TMP_Text DianShiQiText;

	public Transform FengShan;

	public Transform ZiMuM;

	public Transform ZiMuO;

	public Transform ZiMuN;

	public Transform ZiMuR;

	public Transform WeiZhi;

	public Transform ShuiTong;

	public Transform BingKuaiXiao;

	public Transform BingKuaiDa;

	public Transform YaoShi;

	public Transform DianCiLu;

	public Transform XiaoDuYe1;

	public Transform XiaoDuYe2;

	public Transform XiaoDuYe3;

	public Transform Chuizi;

	public Transform Zhentou;

	private bool isZhenTou;

	public Transform YuGang;

	public Transform YuGangQueKou;

	public Transform YuGangYeTi;

	public Transform ChuangTouGui;

	private bool isChuangTouGui;

	public Transform BingXiang;

	private bool isBingXiang;

	public Transform BingXiangTi;

	public Transform GuiZi;

	private bool isGuiZi;

	public Transform GanGuangXiang;

	public Transform GanGuangDeng;

	public Transform ZhiTiao;

	public Transform ShenQingShu;

	public Transform ChengZhongQi;

	public TMP_Text ChengZhongQiText;

	private bool isChengZhongQi;

	public Transform ChengZhongQiMen;

	public List<Transform> DiZuoList;

	public List<Transform> Buttons;

	public Transform Character;

	public List<JianGuoDianQi> ZiMuList;

	private bool isW;

	private bool isFirst;

	private bool isSecond;

	private bool isThird;

	private bool isFour;

	public List<Transform> DengList;

	public List<Transform> FeTiaoList;

	private int isBaoXianGuiOpen;

	public Transform BaoXianMen;

	public TMP_Text Tip;

	public TMP_Text Talk;

	public JianGuoUI ShowUI;

	public Image HpImage;

	public TMP_Text HpText;

	private int Hp = 100;

	private List<Vector3> tileMapVec = new List<Vector3>
	{
		new Vector3(-2.418f, 0.31f, 2.046f),
		new Vector3(1.054f, 0.31f, 2.046f),
		new Vector3(4.526f, 0.31f, 2.046f),
		new Vector3(-2.418f, 0.31f, -1.426f),
		new Vector3(1.054f, 0.31f, -1.426f),
		new Vector3(4.526f, 0.31f, -1.426f)
	};

	private Dictionary<int, List<int>> neighborDic = new Dictionary<int, List<int>>
	{
		{
			0,
			new List<int>
			{
				1,
				3
			}
		},
		{
			1,
			new List<int>
			{
				0,
				2,
				4
			}
		},
		{
			2,
			new List<int>
			{
				1,
				5
			}
		},
		{
			3,
			new List<int>
			{
				0,
				4
			}
		},
		{
			4,
			new List<int>
			{
				5,
				3,
				1
			}
		},
		{
			5,
			new List<int>
			{
				4,
				2
			}
		}
	};

	private Transform dragTrans;

	private bool isCanTrans = true;

	private bool isGanGuang;

	private bool isGanGuangOpen;

	private List<string> TalkList1 = new List<string>
	{
		"你真应该看看我的电视，也许能看到我的风采。",
		"我习惯把记不住的东西记在小本本上，但是我忘了它在哪了，好像在客厅里？",
		"浴缸的水太脏了，你最好别下手去捞里面的东西，我都已经好几天没有洗澡了。",
		"你在干什么呢！快点！",
		"用点子智慧！",
		"不要问我保险箱里为什么有奇怪的东西，我也不知道！",
		"给我装修的工人肯定不是专业的，看看这糟糕的排线。",
		"唉~",
		"我觉得我快要感染了，我需要一针消毒液！快给我打一针消毒液！"
	};

	private List<string> TalkList2 = new List<string>
	{
		"好好看！",
		"好好学！",
		"睁大眼睛！",
		"看清楚了！",
		"这都不知道？"
	};

	private bool isTalk;

	private List<string> answers = new List<string>
	{
		"!",
		"",
		"",
		"",
		"63",
		"52",
		"54",
		"",
		"",
		"",
		"24",
		"54",
		"23",
		"",
		"",
		"",
		"73",
		"12",
		"",
		"",
		"",
		"31",
		"23",
		"",
		"",
		""
	};

	public bool isDianshi;
}
